namespace SIDMIDISynthController
{
    partial class RegisterEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.textregisterValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelRegisterName
            // 
            this.labelRegisterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelRegisterName.Location = new System.Drawing.Point(0, 0);
            this.labelRegisterName.Name = "labelRegisterName";
            this.labelRegisterName.Size = new System.Drawing.Size(260, 20);
            this.labelRegisterName.TabIndex = 0;
            this.labelRegisterName.Text = "label1";
            // 
            // textregisterValue
            // 
            this.textregisterValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textregisterValue.Location = new System.Drawing.Point(0, 24);
            this.textregisterValue.Name = "textregisterValue";
            this.textregisterValue.Size = new System.Drawing.Size(260, 26);
            this.textregisterValue.TabIndex = 1;
            this.textregisterValue.TextChanged += new System.EventHandler(this.textregisterValue_TextChanged);
            this.textregisterValue.Leave += new System.EventHandler(this.textregisterValue_Leave);
            // 
            // RegisterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textregisterValue);
            this.Controls.Add(this.labelRegisterName);
            this.Name = "RegisterEditor";
            this.Size = new System.Drawing.Size(260, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegisterName;
        private System.Windows.Forms.TextBox textregisterValue;
    }
}
