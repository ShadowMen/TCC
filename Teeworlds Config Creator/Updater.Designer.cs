namespace Teeworlds_Config_Creator
{
    partial class Updater
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
        	this.startUp = new System.Windows.Forms.Button();
        	this.progressBar = new System.Windows.Forms.ProgressBar();
        	this.DownloadByte = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// startUp
        	// 
        	this.startUp.Location = new System.Drawing.Point(12, 56);
        	this.startUp.Name = "startUp";
        	this.startUp.Size = new System.Drawing.Size(250, 38);
        	this.startUp.TabIndex = 2;
        	this.startUp.Text = "Download";
        	this.startUp.UseVisualStyleBackColor = true;
        	this.startUp.Click += new System.EventHandler(this.startUp_Click);
        	// 
        	// progressBar
        	// 
        	this.progressBar.Location = new System.Drawing.Point(12, 12);
        	this.progressBar.Name = "progressBar";
        	this.progressBar.Size = new System.Drawing.Size(250, 23);
        	this.progressBar.TabIndex = 1;
        	// 
        	// DownloadByte
        	// 
        	this.DownloadByte.BackColor = System.Drawing.Color.Transparent;
        	this.DownloadByte.Location = new System.Drawing.Point(12, 38);
        	this.DownloadByte.Name = "DownloadByte";
        	this.DownloadByte.Size = new System.Drawing.Size(250, 15);
        	this.DownloadByte.TabIndex = 3;
        	this.DownloadByte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// Updater
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(274, 106);
        	this.Controls.Add(this.DownloadByte);
        	this.Controls.Add(this.progressBar);
        	this.Controls.Add(this.startUp);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Updater";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Updater";
        	this.Shown += new System.EventHandler(this.UpdaterShown);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button startUp;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label DownloadByte;
    }
}