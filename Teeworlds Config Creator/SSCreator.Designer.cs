namespace Teeworlds_Config_Creator
{
    partial class BatCreator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerBrowse = new System.Windows.Forms.TextBox();
            this.CfgBrowse = new System.Windows.Forms.TextBox();
            this.ButServ = new System.Windows.Forms.Button();
            this.ButCfg = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExeÖffner = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.CfgÖffner = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerBrowse
            // 
            this.ServerBrowse.Location = new System.Drawing.Point(104, 13);
            this.ServerBrowse.Name = "ServerBrowse";
            this.ServerBrowse.Size = new System.Drawing.Size(286, 20);
            this.ServerBrowse.TabIndex = 1;
            this.ServerBrowse.TextChanged += new System.EventHandler(this.ServerBrowse_TextChanged);
            // 
            // CfgBrowse
            // 
            this.CfgBrowse.Location = new System.Drawing.Point(104, 39);
            this.CfgBrowse.Name = "CfgBrowse";
            this.CfgBrowse.Size = new System.Drawing.Size(286, 20);
            this.CfgBrowse.TabIndex = 2;
            this.CfgBrowse.TextChanged += new System.EventHandler(this.CfgBrowse_TextChanged);
            // 
            // ButServ
            // 
            this.ButServ.FlatAppearance.BorderSize = 0;
            this.ButServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButServ.Image = global::Teeworlds_Config_Creator.Properties.Resources.search;
            this.ButServ.Location = new System.Drawing.Point(396, 13);
            this.ButServ.Name = "ButServ";
            this.ButServ.Size = new System.Drawing.Size(20, 20);
            this.ButServ.TabIndex = 0;
            this.ButServ.TabStop = false;
            this.ButServ.UseVisualStyleBackColor = true;
            this.ButServ.Click += new System.EventHandler(this.ButServ_Click);
            // 
            // ButCfg
            // 
            this.ButCfg.FlatAppearance.BorderSize = 0;
            this.ButCfg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButCfg.Image = global::Teeworlds_Config_Creator.Properties.Resources.search;
            this.ButCfg.Location = new System.Drawing.Point(396, 39);
            this.ButCfg.Name = "ButCfg";
            this.ButCfg.Size = new System.Drawing.Size(20, 20);
            this.ButCfg.TabIndex = 0;
            this.ButCfg.TabStop = false;
            this.ButCfg.UseVisualStyleBackColor = true;
            this.ButCfg.Click += new System.EventHandler(this.ButCfg_Click);
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.Window;
            this.Output.Location = new System.Drawing.Point(12, 65);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ShortcutsEnabled = false;
            this.Output.Size = new System.Drawing.Size(404, 100);
            this.Output.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server.exe Datei";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Config Datei";
            // 
            // ExeÖffner
            // 
            this.ExeÖffner.Filter = ".exe|*.exe";
            this.ExeÖffner.FileOk += new System.ComponentModel.CancelEventHandler(this.ExeÖffner_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Start Server";
            this.saveFileDialog1.Filter = "Batch(Windows)|*.bat|Shell Script(Linux)|*.sh";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // CfgÖffner
            // 
            this.CfgÖffner.Filter = ".cfg|*.cfg";
            this.CfgÖffner.FileOk += new System.ComponentModel.CancelEventHandler(this.CfgÖffner_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(404, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Skript Speichern..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BatCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 216);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.ServerBrowse);
            this.Controls.Add(this.ButCfg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CfgBrowse);
            this.Controls.Add(this.ButServ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatCreator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Start Script";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerBrowse;
        private System.Windows.Forms.TextBox CfgBrowse;
        private System.Windows.Forms.Button ButServ;
        private System.Windows.Forms.Button ButCfg;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.OpenFileDialog ExeÖffner;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog CfgÖffner;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button1;
    }
}