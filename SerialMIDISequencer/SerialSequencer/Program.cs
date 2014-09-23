// SerialMIDISequencer is a MIDI sequencer with output on serial port.
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

namespace SerialSequencer
{
    class Program
    {
        private static Sequencer sequencer = new Sequencer();
        private static Sequence sequence = new Sequence();
        private static SerialPort serialPort = new SerialPort("COM3");
        static void Main(string[] args)
        {
            serialPort.BaudRate = 115200;
            serialPort.Open();
  
            //String filename = @"C:\Users\nicola\Documents\furelise.mid";
            String filename = @"C:\Users\nicola\Documents\4stagioni.mid";
            //String filename = @"C:\Users\nicola\Documents\c-major-scale-on-bass-clef.mid";            

            sequence.Load(filename);
            sequencer.Sequence = sequence;
            sequencer.ChannelMessagePlayed += new EventHandler<ChannelMessageEventArgs>(sequencer_ChannelMessagePlayed);
            sequencer.Start();
            while (true)
            {
            }
        }

        static void sequencer_ChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            //Console.WriteLine(e.Message.MidiChannel + " " + ((int)(e.Message.Command)).ToString("X2") + " " + e.Message.Data1 + " " + e.Message.Data2);

            List<byte> dataBuffer = new List<byte>();

            if (e.Message.Command == ChannelCommand.NoteOn || e.Message.Command == ChannelCommand.NoteOff)
            {
                dataBuffer.Add((byte)(e.Message.Command ));
                dataBuffer.Add((byte)e.Message.Data1);
                dataBuffer.Add((byte) e.Message.Data2);                
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
            serialPort.Write(dataBuffer.ToArray<byte>(),0, dataBuffer.Count);
            Console.WriteLine("");


        }
    }
}
