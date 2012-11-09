namespace Teeworlds_Config_Creator
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.TWPfad = new System.Windows.Forms.TextBox();
            this.Finish = new System.Windows.Forms.Button();
            this.Cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderSearch = new System.Windows.Forms.Button();
            this.CheckUpdate = new System.Windows.Forms.CheckBox();
            this.TWfolderSearch = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenLastFile = new System.Windows.Forms.CheckBox();
            this.OpenAppdata = new System.Windows.Forms.CheckBox();
            this.UpSerList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TWServerFile = new System.Windows.Forms.TextBox();
            this.SearchExe = new System.Windows.Forms.Button();
            this.TWexeSearch = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // TWPfad
            // 
            this.TWPfad.Location = new System.Drawing.Point(139, 12);
            this.TWPfad.Name = "TWPfad";
            this.TWPfad.Size = new System.Drawing.Size(170, 20);
            this.TWPfad.TabIndex = 1;
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(12, 171);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(129, 23);
            this.Finish.TabIndex = 8;
            this.Finish.Text = "OK";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // Cancle
            // 
            this.Cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancle.Location = new System.Drawing.Point(219, 171);
            this.Cancle.Name = "Cancle";
            this.Cancle.Size = new System.Drawing.Size(116, 23);
            this.Cancle.TabIndex = 9;
            this.Cancle.Text = "Abbrechen";
            this.Cancle.UseVisualStyleBackColor = true;
            this.Cancle.Click += new System.EventHandler(this.Cancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teeworlds Pfad:";
            // 
            // FolderSearch
            // 
            this.FolderSearch.FlatAppearance.BorderSize = 0;
            this.FolderSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FolderSearch.Image = global::Teeworlds_Config_Creator.Properties.Resources.search;
            this.FolderSearch.Location = new System.Drawing.Point(315, 12);
            this.FolderSearch.Name = "FolderSearch";
            this.FolderSearch.Size = new System.Drawing.Size(20, 20);
            this.FolderSearch.TabIndex = 2;
            this.FolderSearch.TabStop = false;
            this.FolderSearch.UseVisualStyleBackColor = true;
            this.FolderSearch.Click += new System.EventHandler(this.FolderSearch_Click);
            // 
            // CheckUpdate
            // 
            this.CheckUpdate.AutoSize = true;
            this.CheckUpdate.Location = new System.Drawing.Point(12, 64);
            this.CheckUpdate.Name = "CheckUpdate";
            this.CheckUpdate.Size = new System.Drawing.Size(242, 17);
            this.CheckUpdate.TabIndex = 3;
            this.CheckUpdate.Text = "Beim Start die letzte verwendete Datei öffnen.";
            this.CheckUpdate.UseVisualStyleBackColor = true;
            // 
            // TWfolderSearch
            // 
            this.TWfolderSearch.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // OpenLastFile
            // 
            this.OpenLastFile.AutoSize = true;
            this.OpenLastFile.Location = new System.Drawing.Point(12, 87);
            this.OpenLastFile.Name = "OpenLastFile";
            this.OpenLastFile.Size = new System.Drawing.Size(195, 17);
            this.OpenLastFile.TabIndex = 4;
            this.OpenLastFile.Text = "Öffnen der letzten geöffneten Datei.";
            this.OpenLastFile.UseVisualStyleBackColor = true;
            // 
            // OpenAppdata
            // 
            this.OpenAppdata.AutoSize = true;
            this.OpenAppdata.Location = new System.Drawing.Point(12, 110);
            this.OpenAppdata.Name = "OpenAppdata";
            this.OpenAppdata.Size = new System.Drawing.Size(232, 17);
            this.OpenAppdata.TabIndex = 5;
            this.OpenAppdata.Text = "Maps auch aus dem Appdata Ordner laden.";
            this.OpenAppdata.UseVisualStyleBackColor = true;
            // 
            // UpSerList
            // 
            this.UpSerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpSerList.FormattingEnabled = true;
            this.UpSerList.Items.AddRange(new object[] {
            "#1 Update-Server (Germany)",
            "#2 Update-Server (Germany)"});
            this.UpSerList.Location = new System.Drawing.Point(97, 133);
            this.UpSerList.Name = "UpSerList";
            this.UpSerList.Size = new System.Drawing.Size(212, 21);
            this.UpSerList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Update-Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Teeworlds Server Datei:";
            // 
            // TWServerFile
            // 
            this.TWServerFile.Location = new System.Drawing.Point(139, 38);
            this.TWServerFile.Name = "TWServerFile";
            this.TWServerFile.Size = new System.Drawing.Size(170, 20);
            this.TWServerFile.TabIndex = 11;
            // 
            // SearchExe
            // 
            this.SearchExe.FlatAppearance.BorderSize = 0;
            this.SearchExe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchExe.Image = global::Teeworlds_Config_Creator.Properties.Resources.search;
            this.SearchExe.Location = new System.Drawing.Point(315, 38);
            this.SearchExe.Name = "SearchExe";
            this.SearchExe.Size = new System.Drawing.Size(20, 20);
            this.SearchExe.TabIndex = 12;
            this.SearchExe.TabStop = false;
            this.SearchExe.UseVisualStyleBackColor = true;
            this.SearchExe.Click += new System.EventHandler(this.SearchExe_Click);
            // 
            // TWexeSearch
            // 
            this.TWexeSearch.FileName = "teeworlds_srv.exe";
            this.TWexeSearch.Filter = ".exe|*.exe";
            // 
            // Settings
            // 
            this.AcceptButton = this.Finish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancle;
            this.ClientSize = new System.Drawing.Size(347, 201);
            this.ControlBox = false;
            this.Controls.Add(this.SearchExe);
            this.Controls.Add(this.TWServerFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpSerList);
            this.Controls.Add(this.OpenAppdata);
            this.Controls.Add(this.OpenLastFile);
            this.Controls.Add(this.CheckUpdate);
            this.Controls.Add(this.FolderSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancle);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.TWPfad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Optionen";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox UpSerList;

        #endregion

        private System.Windows.Forms.TextBox TWPfad;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Button Cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FolderSearch;
        private System.Windows.Forms.CheckBox CheckUpdate;
        private System.Windows.Forms.FolderBrowserDialog TWfolderSearch;
        private System.Windows.Forms.CheckBox OpenLastFile;
        private System.Windows.Forms.CheckBox OpenAppdata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TWServerFile;
        private System.Windows.Forms.Button SearchExe;
        private System.Windows.Forms.OpenFileDialog TWexeSearch;
    }
}