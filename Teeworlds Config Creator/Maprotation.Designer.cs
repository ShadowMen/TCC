namespace Teeworlds_Config_Creator
{
    partial class Maprotation
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
            this.Maps = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.SelectMap = new System.Windows.Forms.ComboBox();
            this.Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Maps
            // 
            this.Maps.FormattingEnabled = true;
            this.Maps.Location = new System.Drawing.Point(12, 12);
            this.Maps.Name = "Maps";
            this.Maps.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Maps.Size = new System.Drawing.Size(184, 82);
            this.Maps.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(107, 129);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(89, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // SelectMap
            // 
            this.SelectMap.FormattingEnabled = true;
            this.SelectMap.Location = new System.Drawing.Point(12, 102);
            this.SelectMap.Name = "SelectMap";
            this.SelectMap.Size = new System.Drawing.Size(184, 21);
            this.SelectMap.TabIndex = 2;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(12, 129);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(89, 23);
            this.Remove.TabIndex = 3;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Maprotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 164);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.SelectMap);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Maps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(356, 42);
            this.Name = "Maprotation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Maprotation_FormClosing);
            this.Load += new System.EventHandler(this.Maprotation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox Maps;
        public System.Windows.Forms.ComboBox SelectMap;
        public System.Windows.Forms.Button Add;
        public System.Windows.Forms.Button Remove;


    }
}