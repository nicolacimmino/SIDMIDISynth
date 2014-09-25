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
            this.checkBoxPlayOnStart = new System.Windows.Forms.CheckBox();
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
            // checkBoxPlayOnStart
            // 
            this.checkBoxPlayOnStart.AutoSize = true;
            this.checkBoxPlayOnStart.Checked = true;
            this.checkBoxPlayOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlayOnStart.Location = new System.Drawing.Point(41, 138);
            this.checkBoxPlayOnStart.Name = "checkBoxPlayOnStart";
            this.checkBoxPlayOnStart.Size = new System.Drawing.Size(177, 24);
            this.checkBoxPlayOnStart.TabIndex = 1;
            this.checkBoxPlayOnStart.Text = "On start play last file";
            this.checkBoxPlayOnStart.UseVisualStyleBackColor = true;
            this.checkBoxPlayOnStart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 207);
            this.Controls.Add(this.checkBoxPlayOnStart);
            this.Controls.Add(this.comboSerialPort);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSerialPort;
        private System.Windows.Forms.Timer timerPopulateSerialsCombo;
        private System.Windows.Forms.CheckBox checkBoxPlayOnStart;
    }
}