namespace DeepLSampler
{
    partial class DeepLSamplerProviderConfDialog
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
            this.grpDeepLconn = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_translate = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grpConnError = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSpiderParams = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShowAdvanced = new System.Windows.Forms.Button();
            this.grpDeepLconn.SuspendLayout();
            this.grpConnError.SuspendLayout();
            this.grpSpiderParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDeepLconn
            // 
            this.grpDeepLconn.Controls.Add(this.label2);
            this.grpDeepLconn.Controls.Add(this.label1);
            this.grpDeepLconn.Controls.Add(this.textBox2);
            this.grpDeepLconn.Controls.Add(this.textBox1);
            this.grpDeepLconn.Controls.Add(this.btn_translate);
            this.grpDeepLconn.Location = new System.Drawing.Point(30, 12);
            this.grpDeepLconn.Name = "grpDeepLconn";
            this.grpDeepLconn.Size = new System.Drawing.Size(551, 128);
            this.grpDeepLconn.TabIndex = 0;
            this.grpDeepLconn.TabStop = false;
            this.grpDeepLconn.Text = "Test DeepL connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target text:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source text:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(457, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(458, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btn_translate
            // 
            this.btn_translate.Location = new System.Drawing.Point(13, 88);
            this.btn_translate.Name = "btn_translate";
            this.btn_translate.Size = new System.Drawing.Size(164, 23);
            this.btn_translate.TabIndex = 0;
            this.btn_translate.Text = "Translate source (DE-EN)";
            this.btn_translate.UseVisualStyleBackColor = true;
            this.btn_translate.Click += new System.EventHandler(this.btn_translate_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(409, 567);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(506, 567);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // grpConnError
            // 
            this.grpConnError.Controls.Add(this.textBox3);
            this.grpConnError.Controls.Add(this.label3);
            this.grpConnError.Location = new System.Drawing.Point(30, 156);
            this.grpConnError.Name = "grpConnError";
            this.grpConnError.Size = new System.Drawing.Size(551, 65);
            this.grpConnError.TabIndex = 3;
            this.grpConnError.TabStop = false;
            this.grpConnError.Text = "Connection error status";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(77, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(457, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current error:";
            // 
            // grpSpiderParams
            // 
            this.grpSpiderParams.Controls.Add(this.checkBox1);
            this.grpSpiderParams.Controls.Add(this.textBox8);
            this.grpSpiderParams.Controls.Add(this.label8);
            this.grpSpiderParams.Controls.Add(this.btnRestoreDefaults);
            this.grpSpiderParams.Controls.Add(this.btnSaveSettings);
            this.grpSpiderParams.Controls.Add(this.textBox7);
            this.grpSpiderParams.Controls.Add(this.label7);
            this.grpSpiderParams.Controls.Add(this.textBox6);
            this.grpSpiderParams.Controls.Add(this.textBox5);
            this.grpSpiderParams.Controls.Add(this.textBox4);
            this.grpSpiderParams.Controls.Add(this.label6);
            this.grpSpiderParams.Controls.Add(this.label5);
            this.grpSpiderParams.Controls.Add(this.label4);
            this.grpSpiderParams.Location = new System.Drawing.Point(30, 270);
            this.grpSpiderParams.Name = "grpSpiderParams";
            this.grpSpiderParams.Size = new System.Drawing.Size(551, 262);
            this.grpSpiderParams.TabIndex = 4;
            this.grpSpiderParams.TabStop = false;
            this.grpSpiderParams.Text = "Spider parameters";
            this.grpSpiderParams.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(13, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Delays enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(126, 56);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(71, 20);
            this.textBox8.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Min. target characters:";
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Location = new System.Drawing.Point(166, 226);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(137, 23);
            this.btnRestoreDefaults.TabIndex = 9;
            this.btnRestoreDefaults.Text = "Restore default values";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(9, 226);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(127, 23);
            this.btnSaveSettings.TabIndex = 8;
            this.btnSaveSettings.Text = "Save current values";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(106, 185);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(428, 20);
            this.textBox7.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "DeepL base URL:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(126, 26);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(71, 20);
            this.textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(126, 143);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(71, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(126, 114);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(71, 20);
            this.textBox4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max. wait count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Delay 2 (ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Delay 1 (ms):";
            // 
            // btnShowAdvanced
            // 
            this.btnShowAdvanced.Location = new System.Drawing.Point(39, 233);
            this.btnShowAdvanced.Name = "btnShowAdvanced";
            this.btnShowAdvanced.Size = new System.Drawing.Size(168, 23);
            this.btnShowAdvanced.TabIndex = 5;
            this.btnShowAdvanced.Text = "Show advanced parameters";
            this.btnShowAdvanced.UseVisualStyleBackColor = true;
            this.btnShowAdvanced.Click += new System.EventHandler(this.btnShowAdvanced_Click);
            // 
            // DeepLSamplerProviderConfDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(623, 611);
            this.Controls.Add(this.btnShowAdvanced);
            this.Controls.Add(this.grpSpiderParams);
            this.Controls.Add(this.grpConnError);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.grpDeepLconn);
            this.Name = "DeepLSamplerProviderConfDialog";
            this.Text = "DeepL Sampler Provider Options";
            this.grpDeepLconn.ResumeLayout(false);
            this.grpDeepLconn.PerformLayout();
            this.grpConnError.ResumeLayout(false);
            this.grpConnError.PerformLayout();
            this.grpSpiderParams.ResumeLayout(false);
            this.grpSpiderParams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDeepLconn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_translate;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox grpConnError;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpSpiderParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnShowAdvanced;
    }
}