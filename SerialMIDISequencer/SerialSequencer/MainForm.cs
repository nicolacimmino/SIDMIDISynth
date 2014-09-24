﻿// SerialMIDISequencer is a MIDI sequencer with output on serial port.
//  Copyright (C) 2014 Nicola Cimmino
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/.
//
// We make use of the C# MIDI toolkit by Leslie Sanford jabberdabber@hotmail.com
//  available at: http://www.codeproject.com/Articles/6228/C-MIDI-Toolkit
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanford.Multimedia.Midi;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SerialSequencer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private Sequencer sequencer = new Sequencer();
        private Sequence sequence = new Sequence();
        private SerialPort serialPort = null;

        private String lastPlayedFile = "";

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        void sequencer_ChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            if (serialPort == null)
            {
                return;
            }

            try
            {
                List<byte> dataBuffer = new List<byte>();

                if (e.Message.Command == ChannelCommand.NoteOn || e.Message.Command == ChannelCommand.NoteOff)
                {
                    dataBuffer.Add((byte)(e.Message.Command));
                    dataBuffer.Add((byte)e.Message.Data1);
                    dataBuffer.Add((byte)e.Message.Data2);
                }
                else if (e.Message.Command == ChannelCommand.Controller)
                {
                    // Control change command
                    dataBuffer.Add((byte)(e.Message.Command));
                    dataBuffer.Add((byte)e.Message.Data1);
                    dataBuffer.Add((byte)e.Message.Data2);
                }

                foreach (byte data in dataBuffer)
                {
                    Console.Write(data.ToString("X2"));
                    Console.Write(".");
                }
                serialPort.Write(dataBuffer.ToArray<byte>(), 0, dataBuffer.Count);
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                serialPort = null;
            }
        }

        private void populateSerialPortsCombo()
        {
            object selectedItem = comboSerialPort.SelectedItem;

            foreach (String serialPortName in SerialPort.GetPortNames())
            {
                if (!comboSerialPort.Items.Contains(serialPortName))
                {
                    comboSerialPort.Items.Add(serialPortName);
                }
            }

            bool oneRemoved = false;

            do
            {
                oneRemoved = false;
                foreach (object serialPortName in comboSerialPort.Items)
                {
                    if (!SerialPort.GetPortNames().Contains<String>((String)serialPortName))
                    {
                        comboSerialPort.Items.Remove(serialPortName);
                        oneRemoved = true;
                        break;
                    }
                }
            } while (oneRemoved);

            if(!SerialPort.GetPortNames().Contains<String>((String)selectedItem))
            {
                selectedItem = null;
                comboSerialPort.Text = "";
            }

            if (selectedItem != null && comboSerialPort.Items.Contains(selectedItem))
            {
                comboSerialPort.SelectedItem = selectedItem;
            }

        }

        private void timerPopulateSerialsCombo_Tick(object sender, EventArgs e)
        {
            populateSerialPortsCombo();
        }

        private void comboSerialPort_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort = new SerialPort(comboSerialPort.Text);
            serialPort.BaudRate = 115200;
            serialPort.Close();
            serialPort.Open();

        }


        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                sequence.Load(files[0]);
                sequencer.Sequence = sequence;
                sequencer.ChannelMessagePlayed += new EventHandler<ChannelMessageEventArgs>(sequencer_ChannelMessagePlayed);
                sequencer.Start();
                lastPlayedFile = files[0];
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void comboSerialPort_DropDown(object sender, EventArgs e)
        {
            timerPopulateSerialsCombo.Enabled = false;
        }

        private void comboSerialPort_DropDownClosed(object sender, EventArgs e)
        {
            timerPopulateSerialsCombo.Enabled = true;
        }
    }
}