namespace SIDMIDISynthController
{
    partial class ControlForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.registerEditor1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorFreqLo1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorPWHI1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorFreqHi1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorNoise = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorPwLo1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorPulse = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorGate1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorSaw1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorSync1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorTri1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorRing1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorTest1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorVolume = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorD1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorA1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorS1 = new SIDMIDISynthController.RegisterEditor();
            this.registerEditorR1 = new SIDMIDISynthController.RegisterEditor();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 503);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.registerEditorS1);
            this.tabPage1.Controls.Add(this.registerEditorR1);
            this.tabPage1.Controls.Add(this.registerEditorA1);
            this.tabPage1.Controls.Add(this.registerEditorD1);
            this.tabPage1.Controls.Add(this.registerEditor1);
            this.tabPage1.Controls.Add(this.registerEditorFreqLo1);
            this.tabPage1.Controls.Add(this.registerEditorPWHI1);
            this.tabPage1.Controls.Add(this.registerEditorFreqHi1);
            this.tabPage1.Controls.Add(this.registerEditorNoise);
            this.tabPage1.Controls.Add(this.registerEditorPwLo1);
            this.tabPage1.Controls.Add(this.registerEditorPulse);
            this.tabPage1.Controls.Add(this.registerEditorGate1);
            this.tabPage1.Controls.Add(this.registerEditorSaw1);
            this.tabPage1.Controls.Add(this.registerEditorSync1);
            this.tabPage1.Controls.Add(this.registerEditorTri1);
            this.tabPage1.Controls.Add(this.registerEditorRing1);
            this.tabPage1.Controls.Add(this.registerEditorTest1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Voice 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Voice 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(721, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Voice 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.registerEditorVolume);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(721, 470);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Common";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // registerEditor1
            // 
            this.registerEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditor1.Enabled = false;
            this.registerEditor1.Location = new System.Drawing.Point(74, 193);
            this.registerEditor1.Name = "registerEditor1";
            this.registerEditor1.RegisterName = "UNUSED";
            this.registerEditor1.RegisterNumber = 0;
            this.registerEditor1.RegisterOffset = 0;
            this.registerEditor1.RegisterValue = 0;
            this.registerEditor1.RegisterWidth = 0;
            this.registerEditor1.Size = new System.Drawing.Size(278, 50);
            this.registerEditor1.TabIndex = 12;
            this.registerEditor1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorFreqLo1
            // 
            this.registerEditorFreqLo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorFreqLo1.Location = new System.Drawing.Point(74, 25);
            this.registerEditorFreqLo1.Name = "registerEditorFreqLo1";
            this.registerEditorFreqLo1.RegisterName = "FREQLO1";
            this.registerEditorFreqLo1.RegisterNumber = 0;
            this.registerEditorFreqLo1.RegisterOffset = 0;
            this.registerEditorFreqLo1.RegisterValue = 0;
            this.registerEditorFreqLo1.RegisterWidth = 8;
            this.registerEditorFreqLo1.Size = new System.Drawing.Size(562, 50);
            this.registerEditorFreqLo1.TabIndex = 0;
            this.registerEditorFreqLo1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorPWHI1
            // 
            this.registerEditorPWHI1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorPWHI1.Location = new System.Drawing.Point(358, 193);
            this.registerEditorPWHI1.Name = "registerEditorPWHI1";
            this.registerEditorPWHI1.RegisterName = "PWHI1";
            this.registerEditorPWHI1.RegisterNumber = 3;
            this.registerEditorPWHI1.RegisterOffset = 0;
            this.registerEditorPWHI1.RegisterValue = 0;
            this.registerEditorPWHI1.RegisterWidth = 4;
            this.registerEditorPWHI1.Size = new System.Drawing.Size(278, 50);
            this.registerEditorPWHI1.TabIndex = 11;
            this.registerEditorPWHI1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorFreqHi1
            // 
            this.registerEditorFreqHi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorFreqHi1.Location = new System.Drawing.Point(74, 81);
            this.registerEditorFreqHi1.Name = "registerEditorFreqHi1";
            this.registerEditorFreqHi1.RegisterName = "FREQHI1";
            this.registerEditorFreqHi1.RegisterNumber = 1;
            this.registerEditorFreqHi1.RegisterOffset = 0;
            this.registerEditorFreqHi1.RegisterValue = 0;
            this.registerEditorFreqHi1.RegisterWidth = 8;
            this.registerEditorFreqHi1.Size = new System.Drawing.Size(562, 50);
            this.registerEditorFreqHi1.TabIndex = 1;
            this.registerEditorFreqHi1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorNoise
            // 
            this.registerEditorNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorNoise.Location = new System.Drawing.Point(74, 249);
            this.registerEditorNoise.Name = "registerEditorNoise";
            this.registerEditorNoise.RegisterName = "NOISE";
            this.registerEditorNoise.RegisterNumber = 4;
            this.registerEditorNoise.RegisterOffset = 7;
            this.registerEditorNoise.RegisterValue = 0;
            this.registerEditorNoise.RegisterWidth = 1;
            this.registerEditorNoise.Size = new System.Drawing.Size(65, 50);
            this.registerEditorNoise.TabIndex = 10;
            this.registerEditorNoise.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorPwLo1
            // 
            this.registerEditorPwLo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorPwLo1.Location = new System.Drawing.Point(74, 137);
            this.registerEditorPwLo1.Name = "registerEditorPwLo1";
            this.registerEditorPwLo1.RegisterName = "PWLO1";
            this.registerEditorPwLo1.RegisterNumber = 2;
            this.registerEditorPwLo1.RegisterOffset = 0;
            this.registerEditorPwLo1.RegisterValue = 0;
            this.registerEditorPwLo1.RegisterWidth = 8;
            this.registerEditorPwLo1.Size = new System.Drawing.Size(562, 50);
            this.registerEditorPwLo1.TabIndex = 2;
            this.registerEditorPwLo1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorPulse
            // 
            this.registerEditorPulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorPulse.Location = new System.Drawing.Point(145, 249);
            this.registerEditorPulse.Name = "registerEditorPulse";
            this.registerEditorPulse.RegisterName = "PULSE";
            this.registerEditorPulse.RegisterNumber = 4;
            this.registerEditorPulse.RegisterOffset = 6;
            this.registerEditorPulse.RegisterValue = 0;
            this.registerEditorPulse.RegisterWidth = 1;
            this.registerEditorPulse.Size = new System.Drawing.Size(65, 50);
            this.registerEditorPulse.TabIndex = 9;
            this.registerEditorPulse.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorGate1
            // 
            this.registerEditorGate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorGate1.Location = new System.Drawing.Point(571, 249);
            this.registerEditorGate1.Name = "registerEditorGate1";
            this.registerEditorGate1.RegisterName = "GATE";
            this.registerEditorGate1.RegisterNumber = 4;
            this.registerEditorGate1.RegisterOffset = 0;
            this.registerEditorGate1.RegisterValue = 0;
            this.registerEditorGate1.RegisterWidth = 1;
            this.registerEditorGate1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorGate1.TabIndex = 3;
            this.registerEditorGate1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorSaw1
            // 
            this.registerEditorSaw1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorSaw1.Location = new System.Drawing.Point(216, 249);
            this.registerEditorSaw1.Name = "registerEditorSaw1";
            this.registerEditorSaw1.RegisterName = "SAW";
            this.registerEditorSaw1.RegisterNumber = 4;
            this.registerEditorSaw1.RegisterOffset = 5;
            this.registerEditorSaw1.RegisterValue = 0;
            this.registerEditorSaw1.RegisterWidth = 1;
            this.registerEditorSaw1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorSaw1.TabIndex = 8;
            this.registerEditorSaw1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorSync1
            // 
            this.registerEditorSync1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorSync1.Location = new System.Drawing.Point(500, 249);
            this.registerEditorSync1.Name = "registerEditorSync1";
            this.registerEditorSync1.RegisterName = "SYNC";
            this.registerEditorSync1.RegisterNumber = 4;
            this.registerEditorSync1.RegisterOffset = 1;
            this.registerEditorSync1.RegisterValue = 0;
            this.registerEditorSync1.RegisterWidth = 1;
            this.registerEditorSync1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorSync1.TabIndex = 4;
            this.registerEditorSync1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorTri1
            // 
            this.registerEditorTri1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorTri1.Location = new System.Drawing.Point(287, 249);
            this.registerEditorTri1.Name = "registerEditorTri1";
            this.registerEditorTri1.RegisterName = "TRI";
            this.registerEditorTri1.RegisterNumber = 4;
            this.registerEditorTri1.RegisterOffset = 4;
            this.registerEditorTri1.RegisterValue = 0;
            this.registerEditorTri1.RegisterWidth = 1;
            this.registerEditorTri1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorTri1.TabIndex = 7;
            this.registerEditorTri1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorRing1
            // 
            this.registerEditorRing1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorRing1.Location = new System.Drawing.Point(429, 249);
            this.registerEditorRing1.Name = "registerEditorRing1";
            this.registerEditorRing1.RegisterName = "RING";
            this.registerEditorRing1.RegisterNumber = 4;
            this.registerEditorRing1.RegisterOffset = 2;
            this.registerEditorRing1.RegisterValue = 0;
            this.registerEditorRing1.RegisterWidth = 1;
            this.registerEditorRing1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorRing1.TabIndex = 5;
            this.registerEditorRing1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorTest1
            // 
            this.registerEditorTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorTest1.Location = new System.Drawing.Point(358, 249);
            this.registerEditorTest1.Name = "registerEditorTest1";
            this.registerEditorTest1.RegisterName = "TEST";
            this.registerEditorTest1.RegisterNumber = 4;
            this.registerEditorTest1.RegisterOffset = 3;
            this.registerEditorTest1.RegisterValue = 0;
            this.registerEditorTest1.RegisterWidth = 1;
            this.registerEditorTest1.Size = new System.Drawing.Size(65, 50);
            this.registerEditorTest1.TabIndex = 6;
            this.registerEditorTest1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorVolume
            // 
            this.registerEditorVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorVolume.Location = new System.Drawing.Point(152, 80);
            this.registerEditorVolume.Name = "registerEditorVolume";
            this.registerEditorVolume.RegisterName = "Volume";
            this.registerEditorVolume.RegisterNumber = 24;
            this.registerEditorVolume.RegisterOffset = 0;
            this.registerEditorVolume.RegisterValue = 0;
            this.registerEditorVolume.RegisterWidth = 4;
            this.registerEditorVolume.Size = new System.Drawing.Size(278, 50);
            this.registerEditorVolume.TabIndex = 12;
            this.registerEditorVolume.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorD1
            // 
            this.registerEditorD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorD1.Location = new System.Drawing.Point(358, 305);
            this.registerEditorD1.Name = "registerEditorD1";
            this.registerEditorD1.RegisterName = "D1";
            this.registerEditorD1.RegisterNumber = 5;
            this.registerEditorD1.RegisterOffset = 0;
            this.registerEditorD1.RegisterValue = 0;
            this.registerEditorD1.RegisterWidth = 4;
            this.registerEditorD1.Size = new System.Drawing.Size(278, 50);
            this.registerEditorD1.TabIndex = 13;
            this.registerEditorD1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorA1
            // 
            this.registerEditorA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorA1.Location = new System.Drawing.Point(74, 305);
            this.registerEditorA1.Name = "registerEditorA1";
            this.registerEditorA1.RegisterName = "A1";
            this.registerEditorA1.RegisterNumber = 5;
            this.registerEditorA1.RegisterOffset = 4;
            this.registerEditorA1.RegisterValue = 0;
            this.registerEditorA1.RegisterWidth = 4;
            this.registerEditorA1.Size = new System.Drawing.Size(278, 50);
            this.registerEditorA1.TabIndex = 14;
            this.registerEditorA1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorS1
            // 
            this.registerEditorS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorS1.Location = new System.Drawing.Point(74, 361);
            this.registerEditorS1.Name = "registerEditorS1";
            this.registerEditorS1.RegisterName = "S1";
            this.registerEditorS1.RegisterNumber = 6;
            this.registerEditorS1.RegisterOffset = 4;
            this.registerEditorS1.RegisterValue = 0;
            this.registerEditorS1.RegisterWidth = 4;
            this.registerEditorS1.Size = new System.Drawing.Size(278, 50);
            this.registerEditorS1.TabIndex = 16;
            this.registerEditorS1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // registerEditorR1
            // 
            this.registerEditorR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registerEditorR1.Location = new System.Drawing.Point(358, 361);
            this.registerEditorR1.Name = "registerEditorR1";
            this.registerEditorR1.RegisterName = "R1";
            this.registerEditorR1.RegisterNumber = 6;
            this.registerEditorR1.RegisterOffset = 0;
            this.registerEditorR1.RegisterValue = 0;
            this.registerEditorR1.RegisterWidth = 4;
            this.registerEditorR1.Size = new System.Drawing.Size(278, 50);
            this.registerEditorR1.TabIndex = 15;
            this.registerEditorR1.Changed += new SIDMIDISynthController.RegisterEditor.ChangedEventHandler(this.register_Changed);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 515);
            this.Controls.Add(this.tabControl1);
            this.Name = "ControlForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RegisterEditor registerEditorFreqLo1;
        private RegisterEditor registerEditorFreqHi1;
        private RegisterEditor registerEditorPwLo1;
        private RegisterEditor registerEditorGate1;
        private RegisterEditor registerEditorSync1;
        private RegisterEditor registerEditorRing1;
        private RegisterEditor registerEditorTest1;
        private RegisterEditor registerEditorNoise;
        private RegisterEditor registerEditorPulse;
        private RegisterEditor registerEditorSaw1;
        private RegisterEditor registerEditorTri1;
        private RegisterEditor registerEditorPWHI1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RegisterEditor registerEditor1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private RegisterEditor registerEditorVolume;
        private RegisterEditor registerEditorS1;
        private RegisterEditor registerEditorR1;
        private RegisterEditor registerEditorA1;
        private RegisterEditor registerEditorD1;

    }
}

