namespace SerialSequencer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboSerialPort = new System.Windows.Forms.ComboBox();
            this.timerPopulateSerialsCombo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboSerialPort
            // 
            this.comboSerialPort.FormattingEnabled = true;
            this.comboSerialPort.Location = new System.Drawing.Point(289, 26);
            this.comboSerialPort.Name = "comboSerialPort";
            this.comboSerialPort.Size = new System.Drawing.Size(121, 28);
            this.comboSerialPort.TabIndex = 0;
            this.comboSerialPort.DropDown += new System.EventHandler(this.comboSerialPort_DropDown);
            this.comboSerialPort.DropDownClosed += new System.EventHandler(this.comboSerialPort_DropDownClosed);
            this.comboSerialPort.SelectedValueChanged += new System.EventHandler(this.comboSerialPort_SelectedValueChanged);
            // 
            // timerPopulateSerialsCombo
            // 
            this.timerPopulateSerialsCombo.Enabled = true;
            this.timerPopulateSerialsCombo.Interval = 1000;
            this.timerPopulateSerialsCombo.Tick += new System.EventHandler(this.timerPopulateSerialsCombo_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 207);
            this.Controls.Add(this.comboSerialPort);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSerialPort;
        private System.Windows.Forms.Timer timerPopulateSerialsCombo;
    }
}