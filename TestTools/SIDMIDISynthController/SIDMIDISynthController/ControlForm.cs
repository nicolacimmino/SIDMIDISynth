using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SIDMIDISynthController
{
    public partial class ControlForm : Form
    {
        private static SerialPort serialPort = new SerialPort("COM3");
        Dictionary<int, byte> registerValues = new Dictionary<int, byte>();

        public ControlForm()
        {
            InitializeComponent();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            serialPort.BaudRate = 115200;
            serialPort.Open();            
        }

        private void registerEditorFreqLo1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditor1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorFreqHi1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorNoise_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorPwLo1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorPulse_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorGate1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorSaw1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorSync1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorTri1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorRing1_Load(object sender, EventArgs e)
        {

        }

        private void registerEditorTest1_Load(object sender, EventArgs e)
        {

        }

        private void register_Changed(object sender)
        {
            RegisterEditor editor = (RegisterEditor)sender;
            if(!registerValues.ContainsKey(editor.RegisterNumber))
            {
                registerValues.Add(editor.RegisterNumber, 0);
            }
            byte lastKnownValue = registerValues[editor.RegisterNumber];
            byte newValue = (byte)editor.RegisterValue;

            // Mask register width bits
            newValue = (byte) (newValue & (byte)(Math.Pow(2, editor.RegisterWidth) - 1));

            // Move register bits to where they belong
            newValue = (byte)(newValue << editor.RegisterOffset);

            // Create a mask to zero the bits that need to take the new value
            byte mask = (byte)(Math.Pow(2, editor.RegisterWidth) - 1);
            mask = (byte)~(byte)(mask << editor.RegisterOffset);

            newValue = (byte)((byte)(lastKnownValue & mask) | newValue);

            registerValues[editor.RegisterNumber] = newValue;

            byte[] midiCommand = { 0xF0, 0x3B, 0x01, (byte)editor.RegisterNumber, newValue, 0xF7 };
            serialPort.Write(midiCommand, 0, 6);
        }

 
    }
}
