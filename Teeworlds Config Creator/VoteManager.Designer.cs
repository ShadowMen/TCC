namespace Teeworlds_Config_Creator
{
    partial class VoteManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoteManager));
            this.VoteList = new System.Windows.Forms.ListBox();
            this.Votename = new System.Windows.Forms.TextBox();
            this.Cmd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VoteAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.VoteDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VoteList
            // 
            this.VoteList.Dock = System.Windows.Forms.DockStyle.Top;
            this.VoteList.FormattingEnabled = true;
            this.VoteList.Location = new System.Drawing.Point(0, 0);
            this.VoteList.Name = "VoteList";
            this.VoteList.Size = new System.Drawing.Size(609, 186);
            this.VoteList.TabIndex = 1;
            // 
            // Votename
            // 
            this.Votename.Location = new System.Drawing.Point(108, 191);
            this.Votename.Name = "Votename";
            this.Votename.Size = new System.Drawing.Size(343, 20);
            this.Votename.TabIndex = 2;
            // 
            // Cmd
            // 
            this.Cmd.AutoCompleteCustomSource.AddRange(new string[] {
            "change_map",
            "sv_map",
            "sv_name",
            "sv_max_clients",
            "sv_warmup",
            "sv_scorelimit",
            "sv_timelimit",
            "sv_gametype",
            "sv_maprotation",
            "sv_rounds_per_map",
            "sv_motd",
            "sv_spectator_slots",
            "sv_teambalance_time",
            "sv_spamprotection",
            "sv_tournament_mode",
            "sv_respawn_delay_tdm",
            "sv_teamdamage",
            "sv_powerups",
            "sv_vote_kick",
            "sv_vote_kick_bantime",
            "sv_vote_kick_min",
            "sv_inactivekick_time",
            "sv_inactivekick",
            "shutdown",
            "reload",
            "tune_reset",
            "restart",
            "broadcast",
            "say",
            "set_team_all",
            "tune ground_control_speed",
            "tune ground_control_accel",
            "tune ground_friction",
            "tune ground_jump_impulse",
            "tune air_jump_impulse",
            "tune air_control_speed",
            "tune air_control_accel",
            "tune air_friction",
            "tune hook_length",
            "tune hook_fire_speed",
            "tune hook_drag_accel",
            "tune hook_drag_speed",
            "tune gravity",
            "tune velramp_start",
            "tune velramp_range",
            "tune velramp_curvature",
            "tune player_collision",
            "tune player_hooking",
            "tune gun_curvature",
            "tune gun_speed",
            "tune gun_lifetime",
            "tune shotgun_curvature",
            "tune shotgun_speed",
            "tune shotgun_speeddiff",
            "tune shotgun_lifetime",
            "tune grenade_curvature",
            "tune grenade_speed",
            "tune grenade_lifetime",
            "tune laser_reach",
            "tune laser_bounce_delay",
            "tune laser_bounce_num",
            "tune laser_bounce_cost",
            "tune laser_damage"});
            this.Cmd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Cmd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Cmd.Location = new System.Drawing.Point(108, 222);
            this.Cmd.Name = "Cmd";
            this.Cmd.Size = new System.Drawing.Size(343, 20);
            this.Cmd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Beschreibung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Befehl";
            // 
            // VoteAdd
            // 
            this.VoteAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoteAdd.Location = new System.Drawing.Point(457, 188);
            this.VoteAdd.Name = "VoteAdd";
            this.VoteAdd.Size = new System.Drawing.Size(140, 25);
            this.VoteAdd.TabIndex = 4;
            this.VoteAdd.Text = "Vote einfügen";
            this.VoteAdd.UseVisualStyleBackColor = true;
            this.VoteAdd.Click += new System.EventHandler(this.VoteAdd_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 9999;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // VoteDel
            // 
            this.VoteDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoteDel.Location = new System.Drawing.Point(457, 219);
            this.VoteDel.Name = "VoteDel";
            this.VoteDel.Size = new System.Drawing.Size(140, 25);
            this.VoteDel.TabIndex = 5;
            this.VoteDel.Text = "Vote entfernen";
            this.VoteDel.UseVisualStyleBackColor = true;
            this.VoteDel.Click += new System.EventHandler(this.VoteDel_Click);
            // 
            // VoteManager
            // 
            this.AcceptButton = this.VoteAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 247);
            this.Controls.Add(this.VoteList);
            this.Controls.Add(this.VoteDel);
            this.Controls.Add(this.VoteAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmd);
            this.Controls.Add(this.Votename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VoteManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vote Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox VoteList;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button VoteAdd;
        public System.Windows.Forms.Button VoteDel;
        public System.Windows.Forms.TextBox Votename;
        public System.Windows.Forms.TextBox Cmd;
    }
}