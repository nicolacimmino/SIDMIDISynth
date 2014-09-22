using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SIDMIDISynthController
{
    public partial class RegisterEditor : UserControl
    {
        public RegisterEditor()
        {
            InitializeComponent();
        }

        private String registerName;

        public String RegisterName
        {
            get { return registerName; }
            set 
            { 
                registerName = value;                
                this.Refresh();
            }
        }

        private int registerValue;

        public int RegisterValue
        {
            get { return registerValue; }
            set { registerValue = value; }
        }

        private int registerNumber;

        public int RegisterNumber
        {
            get { return registerNumber; }
            set { registerNumber = value; }
        }

        private int registerOffset;

        public int RegisterOffset
        {
            get { return registerOffset; }
            set { registerOffset = value; }
        }

        private int registerWidth;

        public int RegisterWidth
        {
            get { return registerWidth; }
            set { registerWidth = value; }
        }
        
        public override void Refresh()
        {
            // Ensure we are running in the GUI thread.
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate { Refresh();});
                return;
            }

            labelRegisterName.Text = registerName;
            textregisterValue.Text = registerValue.ToString(CultureInfo.InvariantCulture);

            labelRegisterName.Enabled = this.Enabled;
            textregisterValue.Enabled = this.Enabled;
            base.Refresh();

        }


        // Delegate for our value changed event
        public delegate void ChangedEventHandler(object sender);

        // Event informing that the register value has changed.
        [Category("Action")]
        [Description("Fires when the register value is changed")]
        public event ChangedEventHandler Changed;
        
        private void onChanged()
        {
            if(Changed != null)
            {
                Changed(this);
            }
        }

        private void textregisterValue_Leave(object sender, EventArgs e)
        {
            try
            {
                registerValue = int.Parse(textregisterValue.Text, CultureInfo.InvariantCulture);
                onChanged();
            }
            catch (FormatException ex)
            {
                // User entered text that cannot be parsed to a number, reject the input
                //  by restoring the last known good value.
                textregisterValue.Text = registerValue.ToString(CultureInfo.InvariantCulture);
            }
           
        }
    }
}
