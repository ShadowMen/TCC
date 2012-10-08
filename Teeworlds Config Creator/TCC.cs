using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class TCC : Form
    {
        AboutBox1 InfoBox = new AboutBox1();
        VoteManager VoteForm = new VoteManager();
        BatCreator SSCreator = new BatCreator();
        Updater Updater = new Updater();
        Maprotation MapRotForm;
        Settings option;
        string CurrentFile;
        string LastFile;
        string lang;

        public TCC()
        {
            InitializeComponent();
            MapRotForm = new Maprotation(this);
            option = new Settings(this);
        }

        private void loadSettings()
        {
            lang = Properties.Settings.Default.Lang;
            ChangeLang(lang);
            toolTip1.Active = Properties.Settings.Default.HelpActive;
            hilfeToolStripMenuItem.Checked = toolTip1.Active;
            VoteForm.toolTip1.Active = Properties.Settings.Default.HelpActive;
            hilfeToolStripMenuItem.Checked = toolTip1.Active;
            if (Properties.Settings.Default.CheckForUpdatesAtStartUp) Updater.ShowDialog();
            if (Properties.Settings.Default.LastFile.Length > 0) LastFile = Properties.Settings.Default.LastFile;
            if (Properties.Settings.Default.OpenLastFile && File.Exists(LastFile)) OpenFile(LastFile);
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VoteForm.ShowDialog();
        }

        private void WarmupCheck_CheckedChanged(object sender, EventArgs e)
        {
            WarmupTime.Enabled = WarmupCheck.Checked;
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://shadow-software.php-friends.de");
        }

        private void infoÜberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoBox.ShowDialog();
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!toolTip1.Active)
            {
                toolTip1.Active = true;
                VoteForm.toolTip1.Active = true;
            }
            else if (toolTip1.Active)
            {
                toolTip1.Active = false;
                VoteForm.toolTip1.Active = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            TeBaTi.Enabled = TeBaTiCheck.Checked;
        }

        private void CfgCreate_Click(object sender, EventArgs e)
        {
            CreateConfig();
        }

        private void CreateConfig()
        {
            try
            {
                //alte Ausgabe löschen
                ConfigOutput.Items.Clear();
                //Offline oder Online
                if (OfflineRB.Checked) ConfigOutput.Items.Add("sv_register 0");
                else ConfigOutput.Items.Add("sv_register 1");
                //Ports
                ConfigOutput.Items.Add("sv_port " + Port.Value);
                ConfigOutput.Items.Add("sv_external_port " + ExPort.Value);
                if (highBand.Checked) ConfigOutput.Items.Add("sv_high_bandwidth 1");
                else ConfigOutput.Items.Add("sv_high_bandwidth 0");
                //Server Name
                ConfigOutput.Items.Add("sv_name " + SerName.Text);
                //Max Clients
                ConfigOutput.Items.Add("sv_max_clients " + MaxClients.Value);
                //Max Clienst per IP
                ConfigOutput.Items.Add("sv_max_clients_per_ip " + MaxClientspIP.Value);
                //Spec Slots
                ConfigOutput.Items.Add("sv_spectator_slots " + SpecSlots.Value);
                //Passwort
                ConfigOutput.Items.Add("password " + Password.Text);
                //Rcon Passwort
                ConfigOutput.Items.Add("sv_rcon_password " + RcPasswort.Text);
                //Max Rcon Tries
                ConfigOutput.Items.Add("sv_rcon_max_tries " + MaxRconTri.Value);
                //Rcon Ban Time
                ConfigOutput.Items.Add("sv_rcon_ban_time " + RconBanTime.Value);
                //GameType
                if (GType.Text.Length == 0)
                {
                    ConfigOutput.Items.Clear();
                    if (Properties.Settings.Default.Lang == "DE") MessageBox.Show("Bitte wähle ein Gametype aus, da der Server sonst nicht startet!", "Freies Feld!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Properties.Settings.Default.Lang == "EN") MessageBox.Show("Please chose a Gametype, until the server doesn´t start!", "Free Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ConfigOutput.Items.Add("sv_gametype " + GType.Text);
                //Motd
                ConfigOutput.Items.Add("sv_motd " + Motd.Text);
                //Maps
                if (Map.Text.Length == 0)
                {
                    ConfigOutput.Items.Clear();
                    if (Properties.Settings.Default.Lang == "DE") MessageBox.Show("Bitte wähle eine Map aus, da der Server sonst nicht startet!", "Freies Feld!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Properties.Settings.Default.Lang == "EN") MessageBox.Show("Please chose a map, until the server doesn´t start!", "Free Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ConfigOutput.Items.Add("sv_map " + Map.Text);
                ConfigOutput.Items.Add("sv_maprotation " + MapRot.Text);
                ConfigOutput.Items.Add("sv_rounds_per_map " + RoundsPmap.Value);
                //Limits
                ConfigOutput.Items.Add("sv_timelimit " + TiLimit.Value);
                ConfigOutput.Items.Add("sv_scorelimit " + ScLimit.Value);
                //Sonstiges
                if (SpamProt.Checked) ConfigOutput.Items.Add("sv_spamprotection 1");
                else ConfigOutput.Items.Add("sv_spamprotection 0");
                if (TeamDmg.Checked) ConfigOutput.Items.Add("sv_teamdamage 1");
                else ConfigOutput.Items.Add("sv_teamdamage 0");
                if (VoteKick.Checked)
                {
                    ConfigOutput.Items.Add("sv_vote_kick 1");
                    ConfigOutput.Items.Add("sv_vote_kick_bantime " + VoteKickTime.Value);
                }
                else ConfigOutput.Items.Add("sv_votekick 0");
                if (WarmupCheck.Checked) ConfigOutput.Items.Add("sv_warmup " + WarmupTime.Value);
                if (TeBaTiCheck.Checked) ConfigOutput.Items.Add("sv_teambalance_time " + TeBaTi.Value);
                if (PowerUps.Checked) ConfigOutput.Items.Add("sv_powerups 1");
                else ConfigOutput.Items.Add("sv_powerups 0");
                if (Tournament.Checked) ConfigOutput.Items.Add("sv_tournament_mode 1");
                else ConfigOutput.Items.Add("sv_tournament_mode 0");
                if (InactiveKT.Value > 0) ConfigOutput.Items.Add("sv_inactivekick_time " + InactiveKT.Value);
                if (DealInactive.SelectedIndex != -1) ConfigOutput.Items.Add("sv_inactivekick " + DealInactive.SelectedIndex);
                //Instagib
                if (groupBox6.Enabled)
                {
                    if (FastKill.Checked) ConfigOutput.Items.Add("sv_fastkill 1");
                    else ConfigOutput.Items.Add("sv_fastkill 0");
                    if (LaserJump.Checked) ConfigOutput.Items.Add("sv_laserjump 1");
                    else ConfigOutput.Items.Add("sv_laserjump 0");
                    if (AntiBot.Checked) ConfigOutput.Items.Add("sv_antibot 1");
                    else ConfigOutput.Items.Add("sv_antibot 0");
                    ConfigOutput.Items.Add("sv_war_time " + InstaWartime.Value);
                    if (ChatKill.Checked) ConfigOutput.Items.Add("sv_chatkill 1");
                    else ConfigOutput.Items.Add("sv_chatkill 0");
                    ConfigOutput.Items.Add("sv_restart_time " + ResTime.Value);
                    if (leaveMuted.Checked) ConfigOutput.Items.Add("sv_leave_muted 1");
                    else ConfigOutput.Items.Add("sv_leave_muted 0");
                    ConfigOutput.Items.Add("sv_go_time " + goTime.Value);
                    if (xonxFeat.Checked) ConfigOutput.Items.Add("sv_xonx_feature 1");
                    else ConfigOutput.Items.Add("sv_xonx_feature 0");
                    if (RestartFeat.Checked) ConfigOutput.Items.Add("sv_restart_feature 1");
                    else ConfigOutput.Items.Add("sv_restart_feature 0");
                    if (StoGoFeat.Checked) ConfigOutput.Items.Add("sv_stopgo_feature 1");
                    else ConfigOutput.Items.Add("sv_stopgo_feature 0");
                }
                //zCatch
                if (groupBox8.Enabled)
                {
                    int mode = zMode.SelectedIndex + 1;
                    ConfigOutput.Items.Add("sv_mode " + mode);
                    int aljo = AJoin.SelectedIndex + 1;
                    ConfigOutput.Items.Add("sv_allow_join " + aljo);
                    ConfigOutput.Items.Add("sv_anticamper " + zCatchAC.SelectedIndex);
                    if (ColIndi.Checked) ConfigOutput.Items.Add("sv_color_indicator 1");
                    else ConfigOutput.Items.Add("sv_color_indicator 0");
                    ConfigOutput.Items.Add("sv_bonus " + Bonus.Value);
                    if (FollowCatcher.Checked) ConfigOutput.Items.Add("sv_follow_catcher 1");
                    else ConfigOutput.Items.Add("sv_follow_catcher 0");
                    if (zLaserJump.Checked) ConfigOutput.Items.Add("sv_laserjumps 1");
                    else ConfigOutput.Items.Add("sv_laserjumps 0");
                    if (VoteFoRea.Checked) ConfigOutput.Items.Add("sv_vote_forcereason 1");
                    else ConfigOutput.Items.Add("sv_vote_forcereason 0");
                    ConfigOutput.Items.Add("sv_suicide_time " + SuicTime.Value);
                    if (GreMinDmg.Enabled) ConfigOutput.Items.Add("sv_grenade_min_damage " + GreMinDmg.Value);
                    if (zCatchAC.Enabled) ConfigOutput.Items.Add("sv_anticamper_freeze " + ACFreTi.Value);
                    ConfigOutput.Items.Add("sv_kill_penalty " + KillPena.Value);
                }
                //Survival
                if (groupBox18.Enabled)
                {
                    ConfigOutput.Items.Add("sv_givehealth " + SurGiveHea.Value);
                    ConfigOutput.Items.Add("sv_givearmor " + SurGiveArm.Value);
                    if (SurGiveHam.Checked) ConfigOutput.Items.Add("sv_giveweapon_hammer 1");
                    else ConfigOutput.Items.Add("sv_giveweapon_hammer 0");
                    if (SurGiveGun.Checked) ConfigOutput.Items.Add("sv_giveweapon_gun 1");
                    else ConfigOutput.Items.Add("sv_giveweapon_gun 0");
                    ConfigOutput.Items.Add("sv_giveweapon_shotgun " + SurGiveShot.Value);
                    ConfigOutput.Items.Add("sv_giveweapon_grenade " + SurGiveGren.Value);
                    ConfigOutput.Items.Add("sv_giveweapon_laser " + SurGiveLaser.Value);
                    if (SurHideWea.Checked) ConfigOutput.Items.Add("sv_hideweapons 1");
                    else ConfigOutput.Items.Add("sv_hideweapons 0");
                    if (SurHidePick.Checked) ConfigOutput.Items.Add("sv_hidepickups 1");
                    else ConfigOutput.Items.Add("sv_hidepickups 0");
                    if (SurRespPick.Checked) ConfigOutput.Items.Add("sv_respawn_pickups 1");
                    else ConfigOutput.Items.Add("sv_respawn_pickups 0");
                    if (SurRespWeap.Checked) ConfigOutput.Items.Add("sv_respawn_weapons 1");
                    else ConfigOutput.Items.Add("sv_respawn_weapons 0");
                }
                //Hammerparty
                if (groupBox19.Enabled) ConfigOutput.Items.Add("sv_hammer_strength " + HPHamStr.Value);
                //Infection
                if (groupBox20.Enabled)
                {
                    ConfigOutput.Items.Add("inf_walldelay " + InfectWaDel.Value);
                    ConfigOutput.Items.Add("inf_walllife " + InfectWaLife.Value);
                    ConfigOutput.Items.Add("inf_walllength " + InfectWaLenght.Value);
                    ConfigOutput.Items.Add("inf_infectiondelay " + InfectDelay.Value);
                    ConfigOutput.Items.Add("inf_airstrikekills " + InfectAirStrKill.Value);
                    ConfigOutput.Items.Add("inf_superjumpkills " + InfectSupJum.Value);
                    ConfigOutput.Items.Add("inf_superjumpforce " + InfectSupJumFor.Value);
                    ConfigOutput.Items.Add("inf_zombie_explodes " + InfecZombExplo.SelectedIndex);
                    ConfigOutput.Items.Add("inf_airstrike_text " + InfectAirText.Text);
                    ConfigOutput.Items.Add("inf_superjump_text " + InfectSJT.Text);
                }
                //Foot/TeeBall
                if (groupBox21.Enabled)
                {
                    ConfigOutput.Items.Add("sv_bounce_loss " + FootBouLoss.Value);
                    if (FootExplo.Checked) ConfigOutput.Items.Add("sv_explosions 1");
                    else ConfigOutput.Items.Add("sv_explosions 0");
                    ConfigOutput.Items.Add("sv_spawn_delay " + FootSpaDel.Value);
                    ConfigOutput.Items.Add("sv_ball_respawn " + FootBallResp.Value);
                    ConfigOutput.Items.Add("sv_score_diff " + FootScorDiff.Value);
                    ConfigOutput.Items.Add("sv_sudden_death_score_diff " + FootDSDiff.Value);
                    ConfigOutput.Items.Add("sv_keeptime " + FootKeepTime.Value);
                    ConfigOutput.Items.Add("sv_hitkeeptime " + FootHitKeepTime.Value);
                    ConfigOutput.Items.Add("sv_selfkillscore " + FootSelfkillScore.Value);
                    ConfigOutput.Items.Add("sv_respawntime " + FootRspwnTime.Value);
                    if (FootBasket.Checked) ConfigOutput.Items.Add("sv_basket 1");
                    else ConfigOutput.Items.Add("sv_basket 0");
                    if (FootSelfkill.Checked) ConfigOutput.Items.Add("sv_selfkill 1");
                    else ConfigOutput.Items.Add("sv_selfkill 0");
                    ConfigOutput.Items.Add("sv_grenade_startspeed " + FootGreStaSpe.Value);
                    if (FootHookTeam.Checked) ConfigOutput.Items.Add("sv_hook_team 1");
                    else ConfigOutput.Items.Add("sv_hook_team 0");
                    if (FootHookKeep.Checked) ConfigOutput.Items.Add("sv_hook_keeper 1");
                    else ConfigOutput.Items.Add("sv_hook_keeper 0");
                    if (FootGoalKeep.Checked) ConfigOutput.Items.Add("sv_goalkeeper 1");
                    else ConfigOutput.Items.Add("sv_goalkeeper 0");
                    ConfigOutput.Items.Add("sv_goal_keeptime " + FootGoKeTi.Value);
                    if (FootReal.Checked) ConfigOutput.Items.Add("sv_real_foot 1");
                    else ConfigOutput.Items.Add("sv_real_foot 0");
                    if (FootKeJump.Checked) ConfigOutput.Items.Add("sv_keeper_jumping 1");
                    else ConfigOutput.Items.Add("sv_keeper_jumping 0");
                    if (FootGreDeath.Checked) ConfigOutput.Items.Add("sv_grenade_death 1");
                    else ConfigOutput.Items.Add("sv_grenade_death 0");
                }
                //Race
                if (groupBox22.Enabled)
                {
                    ConfigOutput.Items.Add("sv_reserved_slots " + RaceReSlots.Value);
                    ConfigOutput.Items.Add("sv_reserved_slots_pass " + RaceReSloPW.Text);
                    ConfigOutput.Items.Add("sv_regen " + RaceRegen.Value);
                    if (RaceStrip.Checked) ConfigOutput.Items.Add("sv_strip 1");
                    else ConfigOutput.Items.Add("sv_strip 0");
                    if (RaceInfAmmo.Checked) ConfigOutput.Items.Add("sv_infinite_ammo 1");
                    else ConfigOutput.Items.Add("sv_infinite_ammo 0");
                    if (RaceNoItems.Checked) ConfigOutput.Items.Add("sv_no_items 1");
                    else ConfigOutput.Items.Add("sv_no_items 0");
                    if (RaceTele.Checked) ConfigOutput.Items.Add("sv_teleport 1");
                    else ConfigOutput.Items.Add("sv_teleport 0");
                    if (RaceTelGre.Checked) ConfigOutput.Items.Add("sv_teleport_grenade 1");
                    else ConfigOutput.Items.Add("sv_teleport_grenade 0");
                    if (RaceTelKill.Checked) ConfigOutput.Items.Add("sv_teleport_kill 1");
                    else ConfigOutput.Items.Add("sv_teleport_kill 0");
                    if (RaceTelVelRes.Checked) ConfigOutput.Items.Add("sv_teleport_vel_reset 1");
                    else ConfigOutput.Items.Add("sv_teleport_vel_reset 0");
                    if (RaceDGAD.Checked) ConfigOutput.Items.Add("sv_delete_grenades_after_death 1");
                    else ConfigOutput.Items.Add("sv_delete_grenades_after_death 0");
                    if (RaceRoJuDmg.Checked) ConfigOutput.Items.Add("sv_rocket_jump_damage 1");
                    else ConfigOutput.Items.Add("sv_rocket_jump_damage 0");
                    ConfigOutput.Items.Add("sv_pickup_respawn " + RacePickResp.Value);
                    if (RaceScoreIP.Checked) ConfigOutput.Items.Add("sv_score_ip 1");
                    else ConfigOutput.Items.Add("sv_score_ip 0");
                    if (RaceCheckpSave.Checked) ConfigOutput.Items.Add("sv_checkpoint_save 1");
                    else ConfigOutput.Items.Add("sv_checkpoint_save 0");
                    ConfigOutput.Items.Add("sv_score_folder " + RaceScoreFold.Text);
                    if (RaceShowTimes.Checked) ConfigOutput.Items.Add("sv_show_times 1");
                    else ConfigOutput.Items.Add("sv_show_times 0");
                    if (RaceShowOthers.Checked) ConfigOutput.Items.Add("sv_show_others 1");
                    else ConfigOutput.Items.Add("sv_show_others 0");
                    if (RaceLoadMapDef.Checked) ConfigOutput.Items.Add("sv_load_map_defaults 1");
                    else ConfigOutput.Items.Add("sv_load_map_defaults 0");
                    if (RaceUseSQL.Checked)
                    {
                        ConfigOutput.Items.Add("sv_use_sql 1");
                        ConfigOutput.Items.Add("sv_sql_user " + RaceSqlUser.Text);
                        ConfigOutput.Items.Add("sv_sql_pw " + RaceSqlPW.Text);
                        ConfigOutput.Items.Add("sv_sql_ip " + RaceSqlIP.Text);
                        ConfigOutput.Items.Add("sv_sql_port " + RaceSqlPort.Value);
                        ConfigOutput.Items.Add("sv_sql_database " + RaceSqlDatabase.Text);
                        ConfigOutput.Items.Add("sv_sql_prefix " + RaceSqlPrefix.Text);
                    }
                    else ConfigOutput.Items.Add("sv_use_sql 0");
                }
                //Teeking
                if (groupBox23.Enabled)
                {
                    ConfigOutput.Items.Add("teeking_start_weaponts " + TeekingStartWea.SelectedIndex);
                    ConfigOutput.Items.Add("teeking_king_mj " + TeekingJumps.Value);
                    ConfigOutput.Items.Add("teeking_king_fs " + TeekingKFirespeed.Value);
                    ConfigOutput.Items.Add("teeking_tee_fs " + TeekingTFirespeed.Value);
                    ConfigOutput.Items.Add("teeking_king_im " + TeekingImorTime.Value);
                    ConfigOutput.Items.Add("teeking_king_number " + TeekingNofK.Value);
                    ConfigOutput.Items.Add("teeking_lastking_prize " + TeekingLKPrize.Value);
                    ConfigOutput.Items.Add("teeking_KingKillKing_prize " + TeekingKingPrize.Value);
                }
                //WaterMod
                if(groupBox26.Enabled)
                {
                	ConfigOutput.Items.Add("*WaterMOD");
                	ConfigOutput.Items.Add("sv_water_gravity " + WModGravity.Value);
                	ConfigOutput.Items.Add("sv_water_maxx " + WModMaxX.Value);
                	ConfigOutput.Items.Add("sv_water_maxy " + WModMaxY.Value);
                	ConfigOutput.Items.Add("sv_water_friction " + WModFrict.Value);
                	if (WModOxy.Checked) ConfigOutput.Items.Add("sv_water_oxygen 1");
                	else ConfigOutput.Items.Add("sv_water_oxygen 0");
                	ConfigOutput.Items.Add("sv_water_oxy_drain " + WModOxyDeg.Value);
                	ConfigOutput.Items.Add("sv_water_oxy_regen " + WModOxyReg.Value);
                	ConfigOutput.Items.Add("sv_water_oxy_emoteid " + WModOxyEmoID.Value);
                	ConfigOutput.Items.Add("sv_water_gain " + WModGain.Value);
                	if (WModReflection.Checked) ConfigOutput.Items.Add("sv_water_reflect 1");
                	else ConfigOutput.Items.Add("sv_water_reflect 0");
                }
                //Tunes
                if (useTune.Checked)
                {
                    //Ground
                    ConfigOutput.Items.Add("tune ground_control_speed " + GcS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune ground_control_accel " + GcA.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune ground_friction " + Gf.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune ground_jump_impulse " + GjI.Value.ToString().Replace(",", "."));
                    //Air
                    ConfigOutput.Items.Add("tune air_jump_impulse " + AjI.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune air_control_speed " + AcS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune air_control_accel " + AcA.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune air_friction " + Af.Value.ToString().Replace(",", "."));
                    //Hook
                    ConfigOutput.Items.Add("tune hook_length " + HL.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune hook_fire_speed " + HfS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune hook_drag_accel " + HdA.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune hook_drag_speed " + HdS.Value.ToString().Replace(",", "."));
                    //Physics
                    ConfigOutput.Items.Add("tune gravity " + gravity.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune velramp_start " + VrS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune velramp_range " + VrR.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune velramp_curvature " + VrC.Value.ToString().Replace(",", "."));
                    if (Collision.Checked) ConfigOutput.Items.Add("tune player_collision 1");
                    else ConfigOutput.Items.Add("tune player_collision 0");
                    if (Hooking.Checked) ConfigOutput.Items.Add("tune player_hooking 1");
                    else ConfigOutput.Items.Add("tune player_hooking 0");
                    ConfigOutput.Items.Add("tune gun_curvature " + GunC.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune gun_speed " + GunS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune gun_lifetime " + GunL.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune shotgun_curvature " + ShotgunC.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune shotgun_speed " + ShotgunS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune shotgun_speeddiff " + ShotgunDiff.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune shotgun_lifetime " + ShotgunL.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune grenade_curvature " + GrenadeC.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune grenade_speed " + GrenadeS.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune grenade_lifetime " + GrenadeL.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune laser_reach " + LaserR.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune laser_bounce_delay " + LaserBD.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune laser_bounce_num " + LaserBN.Value.ToString().Replace(",", "."));
                    ConfigOutput.Items.Add("tune laser_damage " + LaserDmg.Value.ToString().Replace(",", "."));
                }

                //Votes auslesen und einfügen
                for (int i = 0; i < VoteForm.VoteList.Items.Count; i++)
                {
                    ConfigOutput.Items.Add(VoteForm.VoteList.Items[i].ToString());
                }

                //Extra Zeilen einfügen
                if (ExtraLines.TextLength > 0)
                {
                    ConfigOutput.Items.Add("*Extra Lines");
                    ConfigOutput.Items.AddRange(ExtraLines.Lines);
                }
            }
            catch (Exception error)
            {
                ConfigOutput.Items.Clear();
                MessageBox.Show(error.ToString());
                return;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveFile(saveFileDialog1.FileName);
        }

        private void SaveFile(string filename)
        {
            try
            {
                CurrentFile = filename;
                LastFile = filename;
                StreamWriter streamWriter = new StreamWriter(filename);
                for (int s = 0; s < ConfigOutput.Items.Count; s++)
                {
                    streamWriter.WriteLine(ConfigOutput.Items[s]);
                }
                streamWriter.Close();
                this.Text = filename + " - Teeworlds Config Creator";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.TWFolder;
            CreateConfig();
            if (CurrentFile == LastFile && CurrentFile != null) SaveFile(CurrentFile);
            else saveFileDialog1.ShowDialog();
        }

        private void VoteKick_CheckedChanged(object sender, EventArgs e)
        {
            VoteKickTime.Enabled = VoteKick.Checked;
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.TWFolder;
            openFileDialog1.ShowDialog();
        }

        private void OpenFile(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    this.Text = filename + " - Teeworlds Config Creator";
                    LastFile = filename;
                    CurrentFile = filename;
                    //Die ausgewählte Datei öffnen, lesen und in Output reinschreiben
                    string Line;
                    bool XLines = false;
                    ConfigOutput.Items.Clear();
                    VoteForm.VoteList.Items.Clear();
                    StreamReader reader = new StreamReader(filename);
                    //Die Werte auslesen
                    while ((Line = reader.ReadLine()) != null)
                    {
                        ConfigOutput.Items.Add(Line);
                        if (XLines) ExtraLines.Text += Line + "\r\n";
                        string[] words = Line.Split(char.Parse(" "));
                        //Online oder Offline
                        if (Line == "sv_register 1") OnlineRB.Checked = true;
                        if (Line == "sv_register 0") OfflineRB.Checked = true;
                        //Port
                        if (words[0] == "sv_port") Port.Value = decimal.Parse(words[1]);
                        //Externer Port
                        if (words[0] == "sv_external_port") ExPort.Value = decimal.Parse(words[1]);
                        //High Bandwidth
                        if (Line == "sv_high_bandwidth 1") highBand.Checked = true;
                        if (Line == "sv_high_bandwidth 0") highBand.Checked = false;
                        //Servername
                        if (words[0] == "sv_name") SerName.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //Max Clients per IP
                        if (words[0] == "sv_max_clients_per_ip") MaxClientspIP.Value = decimal.Parse(words[1]);
                        //Max Clients
                        if (words[0] == "sv_max_clients") MaxClients.Value = decimal.Parse(words[1]);
                        //Spectator Slots
                        if (words[0] == "sv_spectator_slots") SpecSlots.Value = decimal.Parse(words[1]);
                        //Rcon Passwort
                        if (words[0] == "sv_rcon_password") RcPasswort.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //Rcon Passwort Max Tries
                        if (words[0] == "sv_rcon_max_tries") MaxRconTri.Value = decimal.Parse(words[1]);
                        //Rcon Ban Time
                        if (words[0] == "sv_rcon_ban_time") RconBanTime.Value = decimal.Parse(words[1]);
                        //Passwort
                        else if (words[0] == "password") Password.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //Gametype
                        if (words[0] == "sv_gametype") GType.Text = words[1];
                        //Motd
                        if (words[0] == "sv_motd") Motd.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //ZeitLimit
                        if (words[0] == "sv_timelimit") TiLimit.Value = decimal.Parse(words[1]);
                        //PunkteLimit
                        if (words[0] == "sv_scorelimit") ScLimit.Value = decimal.Parse(words[1]);
                        //Spam Protection
                        if (Line == "sv_spamprotection 1") SpamProt.Checked = true;
                        if (Line == "sv_spamprotection 0") SpamProt.Checked = false;
                        //Teamdamage
                        if (Line == "sv_teamdamage 1") TeamDmg.Checked = true;
                        if (Line == "sv_teamdamage 0") TeamDmg.Checked = false;
                        //VoteKick + VotekickTime
                        if (Line == "sv_vote_kick 1") VoteKick.Checked = true;
                        if (Line == "sv_vote_kick 0") VoteKick.Checked = false;
                        if (words[0] == "sv_vote_kick_bantime") VoteKickTime.Value = decimal.Parse(words[1]);
                        //Warmup
                        if (words[0] == "sv_warmup")
                        {
                            WarmupCheck.Checked = true;
                            WarmupTime.Value = decimal.Parse(words[1]);
                        }
                        //Teambalance Time
                        if (Line.Contains("sv_teambalance_time"))
                        {
                            TeBaTiCheck.Checked = true;
                            TeBaTi.Value = decimal.Parse(words[1]);
                        }
                        //Powerups
                        if (Line == "sv_powerups 1") PowerUps.Checked = true;
                        if (Line == "sv_powerups 0") PowerUps.Checked = false;
                        //Tournament Mode
                        if (Line == "sv_tournament_mode 1") Tournament.Checked = true;
                        if (Line == "sv_tournament_mode 0") Tournament.Checked = false;
                        //Inacitive Kick Time
                        if (words[0] == "sv_inactivekick_time") InactiveKT.Value = decimal.Parse(words[1]);
                        else if (words[0] == "sv_inactivekick") DealInactive.SelectedIndex = int.Parse(words[1]);
                        //Instagib
                        if (Line == "sv_fastkill 1" && groupBox6.Enabled) FastKill.Checked = true;
                        if (Line == "sv_fastkill 0" && groupBox6.Enabled) FastKill.Checked = false;
                        if (Line == "sv_laserjump 1" && groupBox6.Enabled) LaserJump.Checked = true;
                        if (Line == "sv_laserjump 0" && groupBox6.Enabled) LaserJump.Checked = false;
                        if (Line == "sv_chatkill 1" && groupBox6.Enabled) ChatKill.Checked = true;
                        if (Line == "sv_chatkill 0" && groupBox6.Enabled) ChatKill.Checked = false;
                        if (Line == "sv_antibot 1" && groupBox6.Enabled) AntiBot.Checked = true;
                        if (Line == "sv_antibot 0" && groupBox6.Enabled) AntiBot.Checked = false;
                        if (words[0] == "sv_war_time" && groupBox6.Enabled) InstaWartime.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_restart_time" && groupBox6.Enabled) ResTime.Value = decimal.Parse(words[1]);
                        if (Line == "sv_leave_muted 1" && groupBox6.Enabled) leaveMuted.Checked = true;
                        if (Line == "sv_leave_muted 0" && groupBox6.Enabled) leaveMuted.Checked = false;
                        if (words[0] == "sv_go_time" && groupBox6.Enabled) goTime.Value = decimal.Parse(words[1]);
                        if (Line == "sv_xonx_feature 1" && groupBox6.Enabled) xonxFeat.Checked = true;
                        if (Line == "sv_xonx_feature 0" && groupBox6.Enabled) xonxFeat.Checked = false;
                        if (Line == "sv_restart_feature 1" && groupBox6.Enabled) RestartFeat.Checked = true;
                        if (Line == "sv_restart_feature 0" && groupBox6.Enabled) RestartFeat.Checked = false;
                        if (Line == "sv_stopgo_feature 1" && groupBox6.Enabled) StoGoFeat.Checked = true;
                        if (Line == "sv_stopgo_feature 0" && groupBox6.Enabled) StoGoFeat.Checked = false;
                        //zCatch
                        if (words[0] == "sv_mode" && groupBox8.Enabled)
                        {
                            int mode = int.Parse(words[1]) - 1;
                            zMode.SelectedIndex = mode;
                        }
                        if (words[0] == "sv_allow_join" && groupBox8.Enabled)
                        {
                            int aljo = int.Parse(words[1]) - 1;
                            AJoin.SelectedIndex = aljo;
                        }
                        if (Line == "sv_color_indicator 1" && groupBox8.Enabled) ColIndi.Checked = true;
                        if (Line == "sv_color_indicator 0" && groupBox8.Enabled) ColIndi.Checked = false;
                        if (words[0] == "sv_bonus" && groupBox8.Enabled) Bonus.Value = decimal.Parse(words[1]);
                        if (Line == "sv_follow_catcher 1" && groupBox8.Enabled) FollowCatcher.Checked = true;
                        if (Line == "sv_follow_catcher 0" && groupBox8.Enabled) FollowCatcher.Checked = false;
                        if (Line == "sv_laserjumps 1" && groupBox8.Enabled) zLaserJump.Checked = true;
                        if (Line == "sv_laserjumps 0" && groupBox8.Enabled) zLaserJump.Checked = false;
                        if (Line == "sv_vote_forcereason 1" && groupBox8.Enabled) VoteFoRea.Checked = true;
                        if (Line == "sv_vote_forcereason 0" && groupBox8.Enabled) VoteFoRea.Checked = false;
                        if (words[0] == "sv_suicide_time" && groupBox8.Enabled) SuicTime.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_grenade_min_damage" && groupBox8.Enabled) GreMinDmg.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_anticamper" && groupBox8.Enabled) zCatchAC.SelectedIndex = int.Parse(words[1]);
                        if (words[0] == "sv_anticamper_freeze" && groupBox8.Enabled) ACFreTi.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_kill_penalty" && groupBox8.Enabled) KillPena.Value = decimal.Parse(words[1]);
                        //Survival
                        if (words[0] == "sv_givehealth" && groupBox18.Enabled) SurGiveHea.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_givearmor" && groupBox18.Enabled) SurGiveArm.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_giveweapon_shotgun" && groupBox18.Enabled) SurGiveShot.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_giveweapon_grenade" && groupBox18.Enabled) SurGiveGren.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_giveweapon_laser" && groupBox18.Enabled) SurGiveLaser.Value = decimal.Parse(words[1]);
                        if (Line == "sv_giveweapon_hammer 1" && groupBox18.Enabled) SurGiveHam.Checked = true;
                        if (Line == "sv_giveweapon_hammer 0" && groupBox18.Enabled) SurGiveHam.Checked = false;
                        if (Line == "sv_giveweapon_gun 1" && groupBox18.Enabled) SurGiveGun.Checked = true;
                        if (Line == "sv_giveweapon_gun 0" && groupBox18.Enabled) SurGiveGun.Checked = false;
                        if (Line == "sv_hideweapons 1" && groupBox18.Enabled) SurHideWea.Checked = true;
                        if (Line == "sv_hideweapons 0" && groupBox18.Enabled) SurHideWea.Checked = false;
                        if (Line == "sv_hidepickups 1" && groupBox18.Enabled) SurHidePick.Checked = true;
                        if (Line == "sv_hidepickups 0" && groupBox18.Enabled) SurHidePick.Checked = false;
                        if (Line == "sv_respawn_pickups 1" && groupBox18.Enabled) SurRespPick.Checked = true;
                        if (Line == "sv_respawn_pickups 0" && groupBox18.Enabled) SurRespPick.Checked = false;
                        if (Line == "sv_respawn_weapons 1" && groupBox18.Enabled) SurRespWeap.Checked = true;
                        if (Line == "sv_respawn_weapons 0" && groupBox18.Enabled) SurRespWeap.Checked = false;
                        //Hammer Party
                        if (words[0] == "sv_hammer_strength" && groupBox19.Enabled) HPHamStr.Value = decimal.Parse(words[1]);
                        //Infection
                        if (words[0] == "inf_walldelay" && groupBox20.Enabled) InfectWaDel.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_walllife" && groupBox20.Enabled) InfectWaLife.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_walllength" && groupBox20.Enabled) InfectWaLenght.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_infectiondelay" && groupBox20.Enabled) InfectDelay.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_airstrikekills" && groupBox20.Enabled) InfectAirStrKill.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_superjumpkills" && groupBox20.Enabled) InfectSupJum.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_superjumpforce" && groupBox20.Enabled) InfectSupJumFor.Value = decimal.Parse(words[1]);
                        if (words[0] == "inf_zombie_explodes" && groupBox20.Enabled) InfecZombExplo.SelectedIndex = int.Parse(words[1]);
                        if (words[0] == "inf_airstrike_text" && groupBox20.Enabled) InfectAirText.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        if (words[0] == "inf_superjump_text" && groupBox20.Enabled) InfectSJT.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //Foot/TeeBall
                        if (words[0] == "sv_bounce_loss" && groupBox21.Enabled) FootBouLoss.Value = decimal.Parse(words[1]);
                        if (Line == "sv_explosions 1" && groupBox21.Enabled) FootExplo.Checked = true;
                        if (Line == "sv_explosions 0" && groupBox21.Enabled) FootExplo.Checked = false;
                        if (words[0] == "sv_spawn_delay" && groupBox21.Enabled) FootSpaDel.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_ball_respawn" && groupBox21.Enabled) FootBallResp.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_score_diff" && groupBox21.Enabled) FootScorDiff.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_sudden_death_score_diff" && groupBox21.Enabled) FootDSDiff.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_keeptime" && groupBox21.Enabled) FootKeepTime.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_hitkeeptime" && groupBox21.Enabled) FootHitKeepTime.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_selfkillscore" && groupBox21.Enabled) FootSelfkillScore.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_respawntime" && groupBox21.Enabled) FootRspwnTime.Value = decimal.Parse(words[1]);
                        if (Line == "sv_basket 1" && groupBox21.Enabled) FootBasket.Checked = true;
                        if (Line == "sv_basket 0" && groupBox21.Enabled) FootBasket.Checked = false;
                        if (Line == "sv_selfkill 1" && groupBox21.Enabled) FootSelfkill.Checked = true;
                        if (Line == "sv_selfkill 0" && groupBox21.Enabled) FootSelfkill.Checked = false;
                        if (words[0] == "sv_grenade_startspeed" && groupBox21.Enabled) FootGreStaSpe.Value = decimal.Parse(words[1]);
                        if (Line == "sv_hook_team 1" && groupBox21.Enabled) FootHookTeam.Checked = true;
                        if (Line == "sv_hook_team 0" && groupBox21.Enabled) FootHookTeam.Checked = false;
                        if (Line == "sv_hook_keeper 1" && groupBox21.Enabled) FootHookKeep.Checked = true;
                        if (Line == "sv_hook_keeper 0" && groupBox21.Enabled) FootHookKeep.Checked = false;
                        if (Line == "sv_goalkeeper 1" && groupBox21.Enabled) FootGoalKeep.Checked = true;
                        if (Line == "sv_goalkeeper 0" && groupBox21.Enabled) FootGoalKeep.Checked = false;
                        if (words[0] == "sv_goal_keeptime" && groupBox21.Enabled) FootGoKeTi.Value = decimal.Parse(words[1]);
                        if (Line == "sv_real_foot 1" && groupBox21.Enabled) FootReal.Checked = true;
                        if (Line == "sv_real_foot 0" && groupBox21.Enabled) FootReal.Checked = false;
                        if (Line == "sv_keeper_jumping 1" && groupBox21.Enabled) FootKeJump.Checked = true;
                        if (Line == "sv_keeper_jumping 0" && groupBox21.Enabled) FootKeJump.Checked = false;
                        if (Line == "sv_grenade_death 1" && groupBox21.Enabled) FootGreDeath.Checked = true;
                        if (Line == "sv_grenade_death 0" && groupBox21.Enabled) FootGreDeath.Checked = false;
                        //Race
                        if (words[0] == "sv_reserved_slots" && groupBox22.Enabled) RaceReSlots.Value = decimal.Parse(words[1]);
                        if (Line == "sv_infinite_ammo 1" && groupBox22.Enabled) RaceInfAmmo.Checked = true;
                        if (Line == "sv_infinite_ammo 0" && groupBox22.Enabled) RaceInfAmmo.Checked = false;
                        if (words[0] == "sv_reserved_slots_pass" && groupBox22.Enabled) RaceReSloPW.Text = words[1];
                        if (words[0] == "sv_regen" && groupBox22.Enabled) RaceRegen.Value = decimal.Parse(words[1]);
                        if (Line == "sv_strip 1" && groupBox22.Enabled) RaceStrip.Checked = true;
                        if (Line == "sv_strip 0" && groupBox22.Enabled) RaceStrip.Checked = false;
                        if (Line == "sv_no_items 1" && groupBox22.Enabled) RaceNoItems.Checked = true;
                        if (Line == "sv_no_items 0" && groupBox22.Enabled) RaceNoItems.Checked = false;
                        if (Line == "sv_teleport 1" && groupBox22.Enabled) RaceTele.Checked = true;
                        if (Line == "sv_teleport 0" && groupBox22.Enabled) RaceTele.Checked = false;
                        if (Line == "sv_teleport_grenade 1" && groupBox22.Enabled) RaceTelGre.Checked = true;
                        if (Line == "sv_teleport_grenade 0" && groupBox22.Enabled) RaceTelGre.Checked = false;
                        if (Line == "sv_teleport_kill 1" && groupBox22.Enabled) RaceTelKill.Checked = true;
                        if (Line == "sv_teleport_kill 0" && groupBox22.Enabled) RaceTelKill.Checked = false;
                        if (Line == "sv_teleport_vel_reset 1" && groupBox22.Enabled) RaceTelVelRes.Checked = true;
                        if (Line == "sv_teleport_vel_reset 0" && groupBox22.Enabled) RaceTelVelRes.Checked = false;
                        if (Line == "sv_delete_grenades_after_death 1" && groupBox22.Enabled) RaceDGAD.Checked = true;
                        if (Line == "sv_delete_grenades_after_death 0" && groupBox22.Enabled) RaceDGAD.Checked = false;
                        if (Line == "sv_rocket_jump_damage 1" && groupBox22.Enabled) RaceRoJuDmg.Checked = true;
                        if (Line == "sv_rocket_jump_damage 0" && groupBox22.Enabled) RaceRoJuDmg.Checked = false;
                        if (words[0] == "sv_pickup_respawn" && groupBox22.Enabled) RacePickResp.Value = decimal.Parse(words[1]);
                        if (Line == "sv_score_ip 1" && groupBox22.Enabled) RaceScoreIP.Checked = true;
                        if (Line == "sv_score_ip 0" && groupBox22.Enabled) RaceScoreIP.Checked = false;
                        if (Line == "sv_checkpoint_save 1" && groupBox22.Enabled) RaceCheckpSave.Checked = true;
                        if (Line == "sv_checkpoint_save 0" && groupBox22.Enabled) RaceCheckpSave.Checked = false;
                        if (words[0] == "sv_score_folder" && groupBox22.Enabled) RaceScoreFold.Text = words[1];
                        if (Line == "sv_show_times 1" && groupBox22.Enabled) RaceShowTimes.Checked = true;
                        if (Line == "sv_show_times 0" && groupBox22.Enabled) RaceShowTimes.Checked = false;
                        if (Line == "sv_show_others 1" && groupBox22.Enabled) RaceShowOthers.Checked = true;
                        if (Line == "sv_show_others 0" && groupBox22.Enabled) RaceShowOthers.Checked = false;
                        if (Line == "sv_load_map_defaults 1" && groupBox22.Enabled) RaceLoadMapDef.Checked = true;
                        if (Line == "sv_load_map_defaults 0" && groupBox22.Enabled) RaceLoadMapDef.Checked = false;
                        if (Line == "sv_use_sql 1" && groupBox22.Enabled) RaceUseSQL.Checked = true;
                        if (Line == "sv_use_sql 0" && groupBox22.Enabled) RaceUseSQL.Checked = false;
                        if (words[0] == "sv_sql_user" && groupBox22.Enabled) RaceSqlUser.Text = words[1];
                        if (words[0] == "sv_sql_pw" && groupBox22.Enabled) RaceSqlPW.Text = words[1];
                        if (words[0] == "sv_sql_ip" && groupBox22.Enabled) RaceSqlIP.Text = words[1];
                        if (words[0] == "sv_sql_port" && groupBox22.Enabled) RaceSqlPort.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_sql_database" && groupBox22.Enabled) RaceSqlDatabase.Text = words[1];
                        if (words[0] == "sv_sql_prefix" && groupBox22.Enabled) RaceSqlPrefix.Text = words[1];
                        //Teeking
                        if (words[0] == "teeking_start_weaponts" && groupBox23.Enabled) TeekingStartWea.SelectedIndex = int.Parse(words[1]);
                        if (words[0] == "teeking_king_mj" && groupBox23.Enabled) TeekingJumps.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_king_fs" && groupBox23.Enabled) TeekingKFirespeed.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_tee_fs" && groupBox23.Enabled) TeekingTFirespeed.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_king_im" && groupBox23.Enabled) TeekingImorTime.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_king_number" && groupBox23.Enabled) TeekingNofK.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_lastking_prize" && groupBox23.Enabled) TeekingLKPrize.Value = decimal.Parse(words[1]);
                        if (words[0] == "teeking_KingKillKing_prize" && groupBox23.Enabled) TeekingKingPrize.Value = decimal.Parse(words[1]);
                        //WaterMod
                        if (Line == "*WaterMOD") UseWater.Checked = true;
                        if (words[0] == "sv_water_gravity" && groupBox26.Enabled) WModGravity.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_maxx" && groupBox26.Enabled) WModMaxX.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_maxy" && groupBox26.Enabled) WModMaxY.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_friction" && groupBox26.Enabled) WModFrict.Value = decimal.Parse(words[1]);
                        if (Line == "sv_water_oxygen 1" && groupBox26.Enabled) WModOxy.Checked = true;
                        if (Line == "sv_water_oxygen 0" && groupBox26.Enabled) WModOxy.Checked = false;
                        if (words[0] == "sv_water_oxy_drain" && groupBox26.Enabled) WModOxyDeg.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_oxy_regen" && groupBox26.Enabled) WModOxyReg.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_oxy_emoteid" && groupBox26.Enabled) WModOxyEmoID.Value = decimal.Parse(words[1]);
                        if (words[0] == "sv_water_gain" && groupBox26.Enabled) WModGain.Value = decimal.Parse(words[1]);
                        if (Line == "sv_water_reflect 1" && groupBox26.Enabled) WModReflection.Checked = true;
                        if (Line == "sv_water_reflect 0" && groupBox26.Enabled) WModReflection.Checked = false;
                        //MapRotation
                        if (words[0] == "sv_maprotation") MapRot.Text = Line.Substring(Line.IndexOf(" ") + 1);
                        //Map
                        else if (words[0] == "sv_map") Map.Text = words[1];
                        //Rounds per Map
                        if (words[0] == "sv_rounds_per_map") RoundsPmap.Value = decimal.Parse(words[1]);
                        //Tunes
                        if (words[0] == "tune") useTune.Checked = true;
                        if (words[0] == "tune" && words[1] == "ground_control_speed") GcS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "ground_control_accel") GcA.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "ground_friction") Gf.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "ground_jump_impulse") GjI.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "air_jump_impulse") AjI.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "air_control_speed") AcS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "air_control_accel") AcA.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "air_friction") Af.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "hook_length") HL.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "hook_fire_speed") HfS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "hook_drag_accel") HdA.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "hook_drag_speed") HdS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "gravity") gravity.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "velramp_start") VrS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "velramp_range") VrR.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "velramp_curvature") VrC.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "player_collision")
                        {
                            if (int.Parse(words[2]) == 1) Collision.Checked = true;
                            else Collision.Checked = false;
                        }
                        if (words[0] == "tune" && words[1] == "player_hooking")
                        {
                            if (int.Parse(words[2]) == 1) Hooking.Checked = true;
                            else Hooking.Checked = false;
                        }
                        if (words[0] == "tune" && words[1] == "gun_curvature") GunC.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "gun_speed") GunS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "gun_lifetime") GunL.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "shotgun_curvature") ShotgunC.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "shotgun_speed") ShotgunS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "shotgun_speeddiff") ShotgunDiff.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "shotgun_lifetime") ShotgunL.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "grenade_curvature") GrenadeC.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "grenade_speed") GrenadeS.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "grenade_lifetime") GrenadeL.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "laser_reach") LaserR.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "laser_bounce_delay") LaserBD.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "laser_bounce_num") LaserBN.Value = decimal.Parse(words[2].Replace(".", ","));
                        if (words[0] == "tune" && words[1] == "laser_damage") LaserDmg.Value = decimal.Parse(words[2].Replace(".", ","));
                        //Votes
                        if (words[0] == "add_vote") VoteForm.VoteList.Items.Add(Line);
                        //Extra Lines
                        if (Line == "*Extra Lines")
                        {
                            ExtraLines.Text = "";
                            XLines = true;
                        }
                    }
                    reader.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void openFileDialog1_FileOK(object sender, CancelEventArgs e)
        {
            OpenFile(openFileDialog1.FileName);
        }

        private void GType_TextChanged(object sender, EventArgs e)
        {
        	//Überprüfen ob Gametype = Instagib ist
            if (GType.Text == "idm" || GType.Text == "itdm" || GType.Text == "ictf") groupBox6.Enabled = true;
            else groupBox6.Enabled = false;
            //Überprüfen ob Gametype = zcatch ist
            if (GType.Text == "zcatch") groupBox8.Enabled = true;
            else groupBox8.Enabled = false;
            //Überprüfen ob Gametype = Survival ist
            if (GType.Text == "survdm" || GType.Text == "survtdm") groupBox18.Enabled = true;
            else groupBox18.Enabled = false;
            //Überprüfen ob Gametype = Hammerparty ist
            if (GType.Text == "hammerparty" || GType.Text == "hammerpartytdm") groupBox19.Enabled = true;
            else groupBox19.Enabled = false;
            //Überprüfen ob Gametype = Catching ist
            if (GType.Text == "infection") groupBox20.Enabled = true;
            else groupBox20.Enabled = false;
            //Überprüfen ob Gametype = Foot/Teeball ist
            if (GType.Text == "foot") groupBox21.Enabled = true;
            else groupBox21.Enabled = false;
            //Überprüfen ob Gametype = Race ist
            if (GType.Text == "race") groupBox22.Enabled = true;
            else groupBox22.Enabled = false;
            //Überprüfen ob Gametype = Teeking ist
            if (GType.Text == "teeking") groupBox23.Enabled = true;
            else groupBox23.Enabled = false;
            //Überprüfen ob Gametype = WaterMod ist
        	if(GType.Text == "dm" || GType.Text == "tdm" || GType.Text == "ctf" || GType.Text == "idm" || GType.Text == "itdm" || GType.Text == "ictf")
        	{
        		UseWater.Enabled = true;
        		groupBox25.Enabled = true;
        	}
        	else
        	{
        		UseWater.Enabled = false;
        		UseWater.Checked = false;
        		groupBox25.Enabled = false;
        	}
        } 
        
        private void renew1_Click(object sender, EventArgs e)
        {
            GcS.Value = 10;
        }

        private void renew2_Click(object sender, EventArgs e)
        {
            GcA.Value = 2;
        }

        private void renew3_Click(object sender, EventArgs e)
        {
            Gf.Value = decimal.Parse("0,5");
        }

        private void renew4_Click(object sender, EventArgs e)
        {
            GjI.Value = decimal.Parse("13,2");
        }

        private void renew5_Click(object sender, EventArgs e)
        {
            AjI.Value = 12;
        }

        private void renew6_Click(object sender, EventArgs e)
        {
            AcS.Value = 5;
        }

        private void renew7_Click(object sender, EventArgs e)
        {
            AcA.Value = decimal.Parse("1,5");
        }

        private void renew8_Click(object sender, EventArgs e)
        {
            Af.Value = decimal.Parse("0,95");
        }

        private void renew9_Click(object sender, EventArgs e)
        {
            HL.Value = 380;
        }

        private void renew10_Click(object sender, EventArgs e)
        {
            HfS.Value = 80;
        }

        private void renew11_Click(object sender, EventArgs e)
        {
            HdA.Value = 3;
        }

        private void renew12_Click(object sender, EventArgs e)
        {
            HdS.Value = 15;
        }

        private void renew13_Click(object sender, EventArgs e)
        {
            gravity.Value = decimal.Parse("0,5");
        }

        private void renew14_Click(object sender, EventArgs e)
        {
            VrS.Value = 550;
        }

        private void renew15_Click(object sender, EventArgs e)
        {
            VrR.Value = 2000;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VrC.Value = decimal.Parse("1,4");
        }

        private void OfflineRB_CheckedChanged(object sender, EventArgs e)
        {
            highBand.Enabled = OfflineRB.Checked;
        }

        private void renew17_Click(object sender, EventArgs e)
        {
            GunC.Value = decimal.Parse("1,25");
        }

        private void renew18_Click(object sender, EventArgs e)
        {
            GunS.Value = decimal.Parse("2200");
        }

        private void renew19_Click(object sender, EventArgs e)
        {
            GunL.Value = decimal.Parse("2");
        }

        private void renew20_Click(object sender, EventArgs e)
        {
            ShotgunC.Value = decimal.Parse("1,25");
        }

        private void renew21_Click(object sender, EventArgs e)
        {
            ShotgunS.Value = decimal.Parse("2750");
        }

        private void renew22_Click(object sender, EventArgs e)
        {
            ShotgunDiff.Value = decimal.Parse("0,8");
        }

        private void renew23_Click(object sender, EventArgs e)
        {
            ShotgunL.Value = decimal.Parse("0,2");
        }

        private void renew24_Click(object sender, EventArgs e)
        {
            GrenadeC.Value = decimal.Parse("7");
        }

        private void renew25_Click(object sender, EventArgs e)
        {
            GrenadeS.Value = decimal.Parse("1000");
        }

        private void renew26_Click(object sender, EventArgs e)
        {
            GrenadeL.Value = decimal.Parse("2");
        }

        private void renew27_Click(object sender, EventArgs e)
        {
            LaserR.Value = decimal.Parse("800");
        }

        private void renew28_Click(object sender, EventArgs e)
        {
            LaserBD.Value = decimal.Parse("150");
        }

        private void renew29_Click(object sender, EventArgs e)
        {
            LaserBN.Value = decimal.Parse("1");
        }

        private void renew30_Click(object sender, EventArgs e)
        {
            LaserDmg.Value = decimal.Parse("5");
        }

        private void ChangeLang(string s)
        {
            if (s == "DE")
            {
                deutschToolStripMenuItem.Checked = true;
                englischToolStripMenuItem.Checked = false;
                //MainForm
                dateiToolStripMenuItem.Text = "Datei";
                öffnenToolStripMenuItem.Text = "Öffnen";
                speichernToolStripMenuItem.Text = "Speichern";
                speichernunterStripMenuItem1.Text = "Speichern unter...";
                openFileDialog1.Title = "Öffnen";
                saveFileDialog1.Title = "Speichern";
                beendenToolStripMenuItem.Text = "Beenden";
                startDateiToolStripMenuItem.Text = "\"Start-Skript\"-Datei erstellen";
                infoÜberToolStripMenuItem.Text = "Info Über";
                hilfeToolStripMenuItem.Text = "Hilfe";
                UpdaterToolStripMenuItem.Text = "Auf Aktualisierung überprüfen";
                spracheToolStripMenuItem.Text = "Sprache";
                deutschToolStripMenuItem.Text = "Deutsch";
                englischToolStripMenuItem.Text = "Englisch";
                einstellungenToolStripMenuItem.Text = "Einstellungen";
                CfgCreate.Text = "Config erstellen";
                VoteOpen.Text = "Votes verwalten";
                useTune.Text = "Server Tunes verwenden?";
                groupBox5.Text = "Sonstiges";
                groupBox3.Text = "Server Informationen";
                groupBox7.Text = "Map Informationen";
                int lastindex = DealInactive.SelectedIndex;
                DealInactive.Items.Clear();
                DealInactive.DropDownWidth = 410;
                string[] Option = new string[] { "Den Spieler zum Zuschauer machen.", "Falls ein Zuschauer Platz frei ist den Spieler zum Zuschauer machen sonst ihn kicken.", "Den Spieler kicken." };
                DealInactive.Items.AddRange(Option);
                if (lastindex == -1) DealInactive.SelectedIndex = 0;
                else DealInactive.SelectedIndex = lastindex;
                //ScriptCreator Form
                SSCreator.label1.Text = "Server.exe Datei";
                SSCreator.label2.Text = "Config.cfg Datei";
                SSCreator.button1.Text = "Skript speichern...";
                //VoteForm
                VoteForm.VoteAdd.Text = "Vote einfügen";
                VoteForm.VoteDel.Text = "Vote entfernen";
                VoteForm.label1.Text = "Beschreibung";
                VoteForm.label2.Text = "Befehl";
                VoteForm.toolTip1.ToolTipTitle = "Hilfe";
                VoteForm.toolTip1.SetToolTip(VoteForm.Votename, "Hier die Beschreibung des Votes eingeben.");
                VoteForm.toolTip1.SetToolTip(VoteForm.Cmd, "Hier den Befehl eingeben der ausgeführt werden soll, nachdem der Vote erfolgreich war.");
                //AboutBox
                InfoBox.textBoxDescription.Text = "Mit dem \"Teeworlds Config Creator\" kann man schnell und komfortabel eine Config-Datei für den eigenen Server erstellen.\r\nEmpfohlen für Anfänger oder für Erfahrene, welche schnell eine Config-Datei erstellen wollen.\r\n\r\nRiesen Dank an Felix \"DerHase\" K. für die Bilder und dem neuen Icon!";
                //Updater
                Updater.Text = "Auf Aktualisierung überprüfen!";
                //Maprotation form
                MapRotForm.Add.Text = "Hinzufügen";
                MapRotForm.Remove.Text = "Entfernen";
                //ToolTip
                //Allgemein
                Allgemein.Text = "Standard";
                toolTip1.ToolTipTitle = "Hilfe";
                toolTip1.SetToolTip(OnlineRB, "Wenn \"Online\" ausgewählt ist, wird der Server im Internet sichtbar sein, solange der Port freigeschaltet ist.\nFalls der Port nicht freigeschaltet ist, suche bei google nach \"Port Forward\"");
                toolTip1.SetToolTip(OfflineRB, "Wenn \"Offline\" ausgewählt ist, ist der Server nur im lokalem Netzwerk sichbar.");
                toolTip1.SetToolTip(Port, "Der Port auf dem der Server läuft.\nWichtig: Der Port muss frei sein!");
                toolTip1.SetToolTip(highBand, "Schaltet den \"Breitband Modus\" ein, der die Internetgeschwindigkeit für Lan Server erhöht.\nWichtig: Funktioniert nur im Lan Modus!");
                toolTip1.SetToolTip(SerName, "Trage hier den Servernamen ein, der im Server Browser angezeigt wird.");
                toolTip1.SetToolTip(MaxClients, "Anzahl der maximalen erlaubten Spieler auf dem Server.");
                toolTip1.SetToolTip(MaxClientspIP, "Anzahl der maximalen erlaubten Spieler mit der selben IP-Adresse.");
                toolTip1.SetToolTip(SpecSlots, "Anzahl der verfügbaren Pätze, für die Zuschauer.");
                toolTip1.SetToolTip(Password, "Trage hier das Passwort ein, welches der Spieler eingeben muss, um auf dem Server drauf zu kommen.");
                toolTip1.SetToolTip(RcPasswort, "Trage hier das Rcon Passwort ein, welches benötigt wird, um den Server zu verwalten, während man auf ihm drauf ist.");
                toolTip1.SetToolTip(MaxRconTri, "Maximale Versuche um das richtige Rcon Passwort einzugeben.\nInfo: Falls man dies nicht schafft wird man für die angegebene Zeit gebannt!");
                toolTip1.SetToolTip(RconBanTime, "Zeit in Minuten, wielange man für das Scheitern bei der Eingabe des Rcon Passwortes gebannt wird.");
                toolTip1.SetToolTip(GType, "Wähle hier den Gametype aus.\nWichtig: Für die jeweiligen Teeworlds fremden Gametypen muss auch der benötigte Mod zur verfügung stehen!");
                toolTip1.SetToolTip(TiLimit, "Zeitlimit in Minuten. Nachdem die Zeit um ist, wird die Runde beendet und eine neue beginnt.");
                toolTip1.SetToolTip(ScLimit, "Wenn das Punktelimit erreicht ist, hat der Spieler gewonnen, der das Punktelimit erreicht hat.");
                toolTip1.SetToolTip(VoteOpen, "Hier kannst du alle Votes verwalten.");
                toolTip1.SetToolTip(CfgCreate, "Wenn du dir sicher bis, dass du alles fertig hast, dann erstelle die Config.");
                toolTip1.SetToolTip(SpamProt, "\"Spam Protection\" sorgt dafür, das jeder Spieler nur ein paar Nachrichten pro Minute schreiben kann.");
                toolTip1.SetToolTip(TeamDmg, "Sollen die Teamkamerraden durch Freundesbeschuss verletzt werden?");
                toolTip1.SetToolTip(VoteKick, "\"Vote Kick\" erlaubt es Spieler über einem Vote von dem Server zu kicken.");
                toolTip1.SetToolTip(VoteKickTime, "Zeit in Minuten, wielange man nach einem Vote Kick gebannt ist.");
                toolTip1.SetToolTip(WarmupCheck, "Kann man sich Anfang einer Runde aufwärmen?");
                toolTip1.SetToolTip(WarmupTime, "Zeit in Sekunden, indem man sich warm machen kann.");
                toolTip1.SetToolTip(TeBaTiCheck, "Sollen die Teams ausbalanciert werden?");
                toolTip1.SetToolTip(TeBaTi, "Zeit in Sekunden, nachdem die Teams ausbalanciert werden.");
                toolTip1.SetToolTip(PowerUps, "Wenn dies aktiviert ist, werden Powerups wie z.B. Kantana (Ninja) verwendet.");
                toolTip1.SetToolTip(Tournament, "Aktiviert den \"Tournament Modus\". Dadurch werden alle neuen Spieler automatisch zum Zuschauer gemacht.");
                toolTip1.SetToolTip(InactiveKT, "Zeit in Minuten, wielange man inaktiv bleiben darf.");
                toolTip1.SetToolTip(DealInactive, "Was soll mit den inaktiven Spielern gemacht werden?\n0 = Den Spieler zum Zuschauer machen.\n1 = Falls ein Zuschauer Platz frei ist den Spieler zum Zuschauer machen sonst ihn vom Server kicken.\n2 = Den Spieler vom Server kicken.");
                toolTip1.SetToolTip(Map, "Trage hier den Mapnamen ein, damit die Map vom Server geladen wird.\nWichtig: Die Map muss verfügbar sein, da der Server sonst nicht startet.");
                toolTip1.SetToolTip(MapRot, "Trage hier die Maps ein, die beim Spielende geladen werden sollen.\nBeispiel: \"dm1 dm2 dm6\"");
                toolTip1.SetToolTip(RoundsPmap, "Anzahl der Runden, die gespielt werden bis die Map gewechselt wird.");
                toolTip1.SetToolTip(Motd, "\"Message Of The Day\" ist die Nachricht, die beim betreten des Servers und unter Serverinfo angezeigt wird.");
                //Mods
                ModsP1.Text = "Modifikationen - Seite 1";
                groupbox27.Text = "Modifikationen - Seite 2";
                //Insta
                toolTip1.SetToolTip(FastKill, "Wenn dies aktiviert ist, dann spawnt man, nach einem Selbstmord, in 0.5 Sekunden erneut.");
                toolTip1.SetToolTip(LaserJump, "Wenn dies aktiviert ist, kann man mit dem Laser, wie beim Granatenwerfer, springen.");
                toolTip1.SetToolTip(ChatKill, "Wenn dies aktiviert ist, werden die Chatkiller im Chat angezeigt.");
                toolTip1.SetToolTip(AntiBot, "Wenn dies aktiviert ist, werden alle Spieler mit \"[Bot]\" im Namen automatisch gebannt.");
                toolTip1.SetToolTip(InstaWartime, "Zeit in Sekunden, bevor der \"Krieg\" startet.");
                toolTip1.SetToolTip(ResTime, "Zeit in Sekunden, bevor die Runde neu startet.");
                toolTip1.SetToolTip(goTime, "Zeit in Sekunden, bevor das Spiel startet, nach einer Pause.");
                toolTip1.SetToolTip(xonxFeat, "Aktiviert die \"XonX\" und \"Reset\" Eigenschaft.");
                toolTip1.SetToolTip(leaveMuted, "Darf der Spieler den Server verlassen, wenn er stumm gestellt ist?\nWenn nein, wird der Spieler gebannt!");
                toolTip1.SetToolTip(StoGoFeat, "Aktiviert die \"Stop und Go Chat\" Eigenschaft");
                toolTip1.SetToolTip(RestartFeat, "Aktiviert die \"Restart\" Eigenschaft");
                //zCatch
                toolTip1.SetToolTip(zMode, "Bestimmt den (Waffen-)Modus von zCatch.\n1 = Instagib.\n2 = Raketen Arena.\n3 = Hammer Party.\n4 = Nur Granaten.\n5 = Ninja.");
                int lastindex2 = zMode.SelectedIndex;
                int lastindex3 = AJoin.SelectedIndex;
                int lastindex4 = zCatchAC.SelectedIndex;
                zMode.Items.Clear();
                string[] Modes = { "Instagib", "Raketen Arena", "Hammer Party", "Nur Granaten", "Ninja" };
                zMode.Items.AddRange(Modes);
                toolTip1.SetToolTip(AJoin, "Setzt fest wie der Spieler dem jetztigen Spiel beitreten kann.\n1 = Erlaubt dem Spieler das Spiel zu betreten, ohne auf die nächste Runde zu warten.\n2 = Der Spieler betretet das Spiel, sobald der Spieler mit den meisten Kills stirbt.");
                AJoin.Items.Clear();
                AJoin.DropDownWidth = 390;
                string[] Modes2 = { "Erlaubt dem Spieler das Spiel zu betreten, ohne auf die nächste Runde zu warten.", "Der Spieler betretet das Spiel, sobald der Spieler mit den meisten Kills stirbt." };
                AJoin.Items.AddRange(Modes2);
                string[] Modes3 = { "Deaktiviert", "In jedem Modus", "Nur in Instagib" };
                zCatchAC.Items.Clear();
                zCatchAC.Items.AddRange(Modes3);
                if (lastindex2 == -1) zMode.SelectedIndex = 0;
                else zMode.SelectedIndex = lastindex2;
                if (lastindex3 == -1) AJoin.SelectedIndex = 1;
                else AJoin.SelectedIndex = lastindex3;
                if (lastindex4 == -1) zCatchAC.SelectedIndex = 2;
                else zCatchAC.SelectedIndex = lastindex4;
                toolTip1.SetToolTip(ColIndi, "Farbe des Tees passt sich je nach Anzahl der gefangenen Spieler an.");
                toolTip1.SetToolTip(Bonus, "Bonuspunkte für den letzten Spieler.");
                toolTip1.SetToolTip(zLaserJump, "Wenn dies aktiviert ist kann man mit dem Laser, wie beim Granatenwerfer, springen.");
                toolTip1.SetToolTip(VoteFoRea, "Erlaubt nur Votes mit einem Grund.");
                toolTip1.SetToolTip(SuicTime, "Minimale Zeit um sich selbst zu töten.\n0 = Selbstmord verbiten.");
                toolTip1.SetToolTip(GreMinDmg, "Im \"Nur Granaten\" Modus, wie viel Schaden wird benötigt um den Gegner zu töten.");
                toolTip1.SetToolTip(FollowCatcher, "Ein gefangener Spieler verfolgt den Fänger, wenn dies aktiviert ist.");
                toolTip1.SetToolTip(zCatchAC, "In welchem Modus soll \"Anticamper\" aktiv sein?\n0 = Deaktiviert\n1 = In jedem Modus\n2 = Nur in Instagib");
                toolTip1.SetToolTip(ACFreTi, "Zeit in Sekunden, wielange ein Camper eingefroren ist!\n0 = Den Camper töten");
                toolTip1.SetToolTip(KillPena, "Anzahl der Punkte, die einem abgezogen werden, sobald man Selbstmord begeht.");
                //Survival
                toolTip1.SetToolTip(SurGiveArm, "Anzahl der Schilder, die der Spieler am Start hat.");
                toolTip1.SetToolTip(SurGiveGren, "Anzahl der Munition für den Granatenwerfer.\n-1 = Unendlich");
                toolTip1.SetToolTip(SurGiveGun, "Soll die Pistole dem Spieler zur Verfügung stehen?");
                toolTip1.SetToolTip(SurGiveHam, "Soll der Hammer dem Spieler zur Verfügung stehen?");
                toolTip1.SetToolTip(SurGiveHea, "Anzahl der Herzen, die der Spieler am Start hat.");
                toolTip1.SetToolTip(SurGiveLaser, "Anzahl der Munition für den Laser.\n-1 = Unendlich");
                toolTip1.SetToolTip(SurGiveShot, "Anzahl der Munition für die Shotgun.\n-1 = Unendlich");
                toolTip1.SetToolTip(SurHidePick, "Sollen die Herzen und Schilder zum aufheben deaktiviert sein?");
                toolTip1.SetToolTip(SurHideWea, "Sollen die Waffen zum aufheben deaktiviert sein?");
                toolTip1.SetToolTip(SurRespPick, "Sollen die Herzen und Schilder nach dem aufheben respawnen?");
                toolTip1.SetToolTip(SurRespWeap, "Sollen die Waffen nach dem aufheben respawnen?");
                //Hammerparty
                toolTip1.SetToolTip(HPHamStr, "Stärke des Hammers.");
                //Infection
                int lastindex5 = InfecZombExplo.SelectedIndex;
                toolTip1.SetToolTip(InfectWaDel, "Zeit in Sekunden, bevor die Wand aktiviert wird.");
                toolTip1.SetToolTip(InfectWaLife, "Zeit in Sekunden, in der die Wand stehen bleibt.");
                toolTip1.SetToolTip(InfectWaLenght, "Länge, in Pixeln, der Wand.");
                toolTip1.SetToolTip(InfectDelay, "Verzögerung, bevor der IZombie gewählt wird.");
                toolTip1.SetToolTip(InfectAirStrKill, "Benötigte Kills für einen Luftangriff.");
                toolTip1.SetToolTip(InfectSupJum, "Benötigte Kills für einen Supersprung.");
                toolTip1.SetToolTip(InfectSupJumFor, "Stärke des Supersprungs.");
                toolTip1.SetToolTip(InfecZombExplo, "Zombie Explosion.\n0 = Aus\n1 = IZombie\n2 = Alle Zombies");
                string[] modes4 = { "Aus", "IZombie", "Alle Zombies" };
                InfecZombExplo.Items.Clear();
                InfecZombExplo.Items.AddRange(modes4);
                if (lastindex5 == -1) InfecZombExplo.SelectedIndex = 1;
                else InfecZombExplo.SelectedIndex = lastindex5;
                toolTip1.SetToolTip(InfectAirText, "Angezeigter Text, wenn jemand einen Luftangriff bekommt.\n%s = Spielername");
                toolTip1.SetToolTip(InfectSJT, "Angezeigter Text, wenn jemand einen Supersprung bekommt.\n%s = Spielername");
                //Foot/TeeBall
                toolTip1.SetToolTip(FootBouLoss, "Der Ball verliert so viel Geschwindigkeit nach einem Sprung des Balls.");
                toolTip1.SetToolTip(FootExplo, "Sollen die Granaten explodieren nach einem Tor?");
                toolTip1.SetToolTip(FootSpaDel, "Spawn Verzögerung in Millisekunden für die Spieler, nach dem Tod.");
                toolTip1.SetToolTip(FootBallResp, "Respawn-Zeit in Sekunden vom Ball.");
                toolTip1.SetToolTip(FootScorDiff, "Unterschied zwischen den Team-Punkten bevor ein Team gewinnen kann.");
                toolTip1.SetToolTip(FootDSDiff, "Unterschied zwischen den Team-Punkten bevor ein Team in \"Sudden Death\" gewinnen kann.");
                toolTip1.SetToolTip(FootKeepTime, "Zeit in Sekunden, um den Ball zu halten.");
                toolTip1.SetToolTip(FootHitKeepTime, "Wartezeit in Sekunden, nachdem man mit dem Hammer getroffen wurde.");
                toolTip1.SetToolTip(FootSelfkillScore, "Anzahl der Punkte, die für Selbstmord abgezogen werden.");
                toolTip1.SetToolTip(FootRspwnTime, "Zeit in Sekunde, zum respawnen nach einem Selbstmord.");
                toolTip1.SetToolTip(FootBasket, "Dunking und Basketball-Punktesystem an- oder ausschalten?");
                toolTip1.SetToolTip(FootSelfkill, "Soll Selbstmord aktiviert oder deaktiviert sein?");
                toolTip1.SetToolTip(FootGreStaSpe, "Wert für die Granatengeschwindigkeit, die an der eigenen Geschwindigkeit dazu kommt.");
                toolTip1.SetToolTip(FootHookTeam, "Kann ihr Team gehookt werden?");
                toolTip1.SetToolTip(FootHookKeep, "Kann der Torwart gehookt werden?");
                toolTip1.SetToolTip(FootGoalKeep, "soll der Torwart aktiviert oder deaktiviert sein?");
                toolTip1.SetToolTip(FootGoKeTi, "Zeit in Sekunden, wielange der Torwart den Ball halten darf.");
                toolTip1.SetToolTip(FootReal, "Hammertreffer an oder aus?");
                toolTip1.SetToolTip(FootKeJump, "Endloses springen für Torwarte?");
                toolTip1.SetToolTip(FootGreDeath, "Soll man sterben, sobald man die Granate aufhebt?\nWichtig: Dies sollte nur aktiviert werden, wenn sie eine Tischtennis-Map spielen!");
                //Race Deutsch
                toolTip1.SetToolTip(RaceReSlots, "Anzahl der reservierten Plätze.");
                toolTip1.SetToolTip(RaceInfAmmo, "Aktiviert oder deaktiviert unendlich Munition.");
                toolTip1.SetToolTip(RaceReSloPW, "Passwort für reservierten Plätze.");
                toolTip1.SetToolTip(RaceRegen, "Lege Regeneration pro sekunde fest.");
                toolTip1.SetToolTip(RaceStrip, "Aktiviert oder deaktiviert das Behalten von Waffen nach teleportation.");
                toolTip1.SetToolTip(RaceNoItems, "Entferne jedes Item von der Karte, falls dort welche sind.");
                toolTip1.SetToolTip(RaceTele, "Aktiviert oder deaktiviert teleportation.");
                toolTip1.SetToolTip(RaceTelGre, "Aktiviert oder deaktiviert teleportation von Granaten.");
                toolTip1.SetToolTip(RaceTelKill, "Teleportiere jemanden der ihn killt.\n(Entschuldigung, aber ich weis nicht was diese Option macht.)");
                toolTip1.SetToolTip(RaceTelVelRes, "Nach teleportation die Geschwindigkeit zurücksetzen.");
                toolTip1.SetToolTip(RaceDGAD, "Löscht Granaten, nachdem der Spieler starb.");
                toolTip1.SetToolTip(RaceRoJuDmg, "Aktiviert oder deaktiviert \"Rocket jump\" Schaden.");
                toolTip1.SetToolTip(RacePickResp, "Zeit nachdem ein Item respawnt.\n-1 = Nach dem Tod");
                toolTip1.SetToolTip(RaceScoreIP, "Überprüfedie Punktzahl auch nach IP.");
                toolTip1.SetToolTip(RaceCheckpSave, "Speichern von Checkpoint-Zeiten zur Punkte-Datei.");
                toolTip1.SetToolTip(RaceScoreFold, "Ordner indem die Punkte-Dateien gespeichert werden.");
                toolTip1.SetToolTip(RaceShowTimes, "Zeige die Zeit der anderen Spieler an.");
                toolTip1.SetToolTip(RaceShowOthers, "Zeige andere Spieler an.");
                toolTip1.SetToolTip(RaceLoadMapDef, "Lege die Einstellungen,welche in der Karte gescpeichert sind beim Mapchange/reload fest.");
                toolTip1.SetToolTip(RaceUseSQL, "Aktiviert SQL Datenbank anstatt einer Punkte-Datei.");
                toolTip1.SetToolTip(RaceSqlPort, "SQL Benutzer.");
                toolTip1.SetToolTip(RaceSqlUser, "SQL Passwort.");
                toolTip1.SetToolTip(RaceSqlPW, "SQL Datenbank IP.");
                toolTip1.SetToolTip(RaceSqlIP, "SQL Datenbank Port.");
                toolTip1.SetToolTip(RaceSqlDatabase, "SQL Datenbank Name.");
                toolTip1.SetToolTip(RaceSqlPrefix, "SQL Datenbank tabellen prefix.");
                //Teeking
                string[] modes5 = { "Granatenwerfer", "Laser", "Granatenwerfer und Laser" };
                int lastindex6 = TeekingStartWea.SelectedIndex;
                TeekingStartWea.Items.Clear();
                TeekingStartWea.Items.AddRange(modes5);
                if (lastindex6 == -1) TeekingStartWea.SelectedIndex = 1;
                else TeekingStartWea.SelectedIndex = lastindex6;
                toolTip1.SetToolTip(TeekingStartWea, "Wähle aus welche Waffe benutzt werden kann.\n0 = Granatenwerfer.\n1 = Laser.\n2 = Granatenwerfer und Laser.");
                toolTip1.SetToolTip(TeekingJumps, "Maximale Anzahl an Sprüngen für den König!\n-1 = unendlich.");
                toolTip1.SetToolTip(TeekingKFirespeed, "Die Feuerrate des König.");
                toolTip1.SetToolTip(TeekingTFirespeed, "Die Feuerrate der Tees.");
                toolTip1.SetToolTip(TeekingImorTime, "Zeit der Unsterblichkeit für Spieler, die zehn Rüstung gesammelt haben.");
                toolTip1.SetToolTip(TeekingNofK, "Anzahl der Könige.\n-1 = jeder ist König.\n0 = \"LastKing\" Modus.");
                toolTip1.SetToolTip(TeekingLKPrize, "Preis für den lezten König.\nFunktioniert nur im \"LastKing\" Modus.");
                toolTip1.SetToolTip(TeekingKingPrize, "Preis für den König, der einen anderen König getötet hat.");
                //WaterMOD
                groupBox25.Text = "WaterMOD(Für TW 0.6)";
                UseWater.Text = "WasserMOD verwenden";
                toolTip1.SetToolTip(WModGravity, "Schwerkraft im Wasser.");
                toolTip1.SetToolTip(WModMaxX, "Max. Geschwindigkeit in x-Richtung im Wasser.");
                toolTip1.SetToolTip(WModMaxY, "Max. Geschwindigkeit in y-Richtung im Wasser.");
                toolTip1.SetToolTip(WModFrict, "Reibung im Wasser.");
				toolTip1.SetToolTip(WModGain, "Hinzugefügen von Geschwindigkeit, wenn man im fließendem Wasser ist.");
				toolTip1.SetToolTip(WModOxy, "Verwenden Sie Sauerstoff im Wasser.");
				toolTip1.SetToolTip(WModOxyDeg, "Die Geschwindigkeit des Sauerstoffverlust im Wasser.\n50 = 1 Sekunde");
				toolTip1.SetToolTip(WModOxyReg, "Die Geschwindigkeit der Sauerstoffaufnahme im Wasser.\n50 = 1 Sekunde");
				toolTip1.SetToolTip(WModOxyEmoID, "Anzahl der Emotions, die wegen dem Schaden durch Sauerstoffmangel angezeigt werden.");
				toolTip1.SetToolTip(WModReflection, "Laser vom Wasser abprallen lassen.");
                //Extra Lines
                XtraLines.Text = "Extra Zeilen";
                XtraLinesDescripton.Text = "Hier können sie eigene Befehle einfügen z.B. wenn TCC einen Mod nicht unterstützt.";
            }
            else if (s == "EN")
            {
                deutschToolStripMenuItem.Checked = false;
                englischToolStripMenuItem.Checked = true;
                //MainForm
                dateiToolStripMenuItem.Text = "File";
                öffnenToolStripMenuItem.Text = "Open";
                speichernToolStripMenuItem.Text = "Save";
                openFileDialog1.Title = "Open File";
                saveFileDialog1.Title = "Save File";
                speichernunterStripMenuItem1.Text = "Save File under...";
                beendenToolStripMenuItem.Text = "Exit";
                startDateiToolStripMenuItem.Text = "Create \"Startup Script\" file";
                infoÜberToolStripMenuItem.Text = "About";
                hilfeToolStripMenuItem.Text = "Help";
                UpdaterToolStripMenuItem.Text = "Check for Updates";
                spracheToolStripMenuItem.Text = "Language";
                deutschToolStripMenuItem.Text = "German";
                englischToolStripMenuItem.Text = "English";
                einstellungenToolStripMenuItem.Text = "Settings";
                CfgCreate.Text = "Create Config";
                VoteOpen.Text = "Manage Votes";
                useTune.Text = "Use Server Tunes?";
                groupBox5.Text = "Other";
                groupBox3.Text = "Server Information";
                groupBox7.Text = "Map Information";
                int lastindex = DealInactive.SelectedIndex;
                DealInactive.Items.Clear();
                DealInactive.DropDownWidth = 305;
                string[] Option = new string[] { "Switch the player to spectators.", "If a spectator slot free, switch the player to spectators else kick.", "Kick the player." };
                DealInactive.Items.AddRange(Option);
                if (lastindex == -1) DealInactive.SelectedIndex = 0;
                else DealInactive.SelectedIndex = lastindex;
                //ScriptCreator Form
                SSCreator.label1.Text = "Server.exe File";
                SSCreator.label2.Text = "Config.cfg File";
                SSCreator.button1.Text = "Save Script...";
                //VoteForm
                VoteForm.VoteAdd.Text = "Add Vote";
                VoteForm.VoteDel.Text = "Delete Vote";
                VoteForm.label1.Text = "Description";
                VoteForm.label2.Text = "Command";
                VoteForm.toolTip1.ToolTipTitle = "Help";
                VoteForm.toolTip1.SetToolTip(VoteForm.Votename, "Insert here the description of the Vote.");
                VoteForm.toolTip1.SetToolTip(VoteForm.Cmd, "Insert here the command, which executed when the Vote was succesfully.");
                //AboutBox
                InfoBox.textBoxDescription.Text = "With the Tool \"Teeworlds Config Creator\" you can create fast and easy a config-file for your own teeworlds server. Recommended for Newbies or experienced player there only want to create quickly a Config.\r\n\r\nBig Thanks to Felix \"DerHase\" K. for the Images and the new Icon.";
                //Updater
                Updater.Text = "Check for Updates";
                //Maprotation form
                MapRotForm.Add.Text = "Add";
                MapRotForm.Remove.Text = "Remove";
                //ToolTip
                //Allgemein
                Allgemein.Text = "Default";
                toolTip1.ToolTipTitle = "Help";
                toolTip1.SetToolTip(OnlineRB, "If this set to \"Online\", is the server visible on the internet, until the port is forward.\nIf you don´t know how to forward a port search on Google: \"Port Forward\"!");
                toolTip1.SetToolTip(OfflineRB, "If this set to \"Offline\", is the server only visible on the local network.");
                toolTip1.SetToolTip(Port, "Port which the server use.\nImportant: The Port must be free!");
                toolTip1.SetToolTip(highBand, "Activate the \"High Brandwidth\" mode, which increase the internet speed for LAN Server.\nImportant: Works only in the Offline mode!");
                toolTip1.SetToolTip(SerName, "Insert here the servername, which is visible for other players in the Server Browser.");
                toolTip1.SetToolTip(MaxClients, "Number of maximal allowed player on the server.");
                toolTip1.SetToolTip(MaxClientspIP, "Number of allowed player with the same IP.");
                toolTip1.SetToolTip(SpecSlots, "Number of aviable slots for spectators.");
                toolTip1.SetToolTip(Password, "Insert here the passwort, which the client must enter to join the server.");
                toolTip1.SetToolTip(RcPasswort, "Insert here the rconpasswort, wich used to manage the server, while you are on the server.");
                toolTip1.SetToolTip(MaxRconTri, "Maximal tries to enter the correct rcon password.\nInfo: If someone didn´t got it, he get ban!");
                toolTip1.SetToolTip(RconBanTime, "The time in minutes, how long someone get ban, because he enter the wrong rcon password.");
                toolTip1.SetToolTip(GType, "Chose a gametype.\nImportant: For the gametype, which Teeworlds not know, you need the used server mod!");
                toolTip1.SetToolTip(TiLimit, "Timelimit in minutes. Until the time is over, the round is over an a new round start.");
                toolTip1.SetToolTip(ScLimit, "If reach the scorelimit, the player win, who reach the scorelimit.");
                toolTip1.SetToolTip(VoteOpen, "Manage the votes here.");
                toolTip1.SetToolTip(CfgCreate, "Create the config with a klick");
                toolTip1.SetToolTip(SpamProt, "Spam Protection makes, that other player only can write a few messages per minute.");
                toolTip1.SetToolTip(TeamDmg, "Should player get damage by friendly fire?");
                toolTip1.SetToolTip(VoteKick, "\"Vote Kick\" allow player to kick someone per vote.");
                toolTip1.SetToolTip(VoteKickTime, "Time in minutes, how long someone banned for an vote kick");
                toolTip1.SetToolTip(WarmupCheck, "Can you warmup on a new round?");
                toolTip1.SetToolTip(WarmupTime, "Time in seconds, you can warmup.");
                toolTip1.SetToolTip(TeBaTiCheck, "Should Teams get balanced.");
                toolTip1.SetToolTip(TeBaTi, "Time in seconds, after Teams get balanced.");
                toolTip1.SetToolTip(PowerUps, "If this activate, Powerups are used like a Kantana (Ninja).");
                toolTip1.SetToolTip(Tournament, "Activate \"Tournament mode\". All new players were switch to the spectators.");
                toolTip1.SetToolTip(InactiveKT, "Time in minutes, how long someone allow to be inactive.");
                toolTip1.SetToolTip(DealInactive, "How to deal with inactive players?\n0 = Switch the player to spectators.\n1 = If a spectator slot free, switch the player to spectators else kick.\n2 = Kick the player.");
                toolTip1.SetToolTip(Map, "Insert the mapname here, which the server load.\nImportant: The map must be aviable, until the server doesn´t start.");
                toolTip1.SetToolTip(MapRot, "Insert the mapnames here, wich the server load if a round ends.\nexample: \"dm1 dm2 dm6\"");
                toolTip1.SetToolTip(RoundsPmap, "Number of rounds, which play per map.");
                toolTip1.SetToolTip(Motd, "\"Message Of The Day\" is the message, which show by joining the server and server info.");
                //Mods
                ModsP1.Text = "Mods - Page 1";
                groupbox27.Text = "Mods - Page 2";
                //Insta
                toolTip1.SetToolTip(FastKill, "If this activate all players spawn, on suicide, after 0.5 seconds.");
                toolTip1.SetToolTip(LaserJump, "If this activate you can jump with the laser like the rocket launcher.");
                toolTip1.SetToolTip(ChatKill, "If this activate would all Chatkillers show in the chat.");
                toolTip1.SetToolTip(AntiBot, "If this activate automaticly ban players with \"[Bot]\" in name.");
                toolTip1.SetToolTip(InstaWartime, "Time in seconds, before war starts.");
                toolTip1.SetToolTip(ResTime, "Time in seconds, before round restarts.");
                toolTip1.SetToolTip(goTime, "Time in seconds, before game starts when paused.");
                toolTip1.SetToolTip(xonxFeat, "Enable \"XonX and reset Chat\" features.");
                toolTip1.SetToolTip(leaveMuted, "Can the player leave the Server muted? If not, he gets banned for the muted time!");
                toolTip1.SetToolTip(StoGoFeat, "Enable \"stop and go chat\" features.");
                toolTip1.SetToolTip(RestartFeat, "Enable \"restart Chat\" feature.");
                //zCatch
                toolTip1.SetToolTip(zMode, "Determines the mode (weapon) of zCatch.\n1 = Instagib.\n2 = Rocket area.\n3 = Hammerparty.\n4 = Grenade only.\n5 = Ninja.");
                int lastindex2 = zMode.SelectedIndex;
                int lastindex3 = AJoin.SelectedIndex;
                int lastindex4 = zCatchAC.SelectedIndex;
                zMode.Items.Clear();
                string[] Modes = { "Instagib", "Rocket area", "Hammerparty", "Grenade only", "Ninja" };
                zMode.Items.AddRange(Modes);
                toolTip1.SetToolTip(AJoin, "Sets how the players can join in the current game.\n1 = Allow new players to join the game without need to wait for the next round.\n2 = The player will join when the player with the most kills dies.");
                AJoin.Items.Clear();
                AJoin.DropDownWidth = 356;
                string[] Modes2 = { "Allow new players to join the game without need to wait for the next round.", "The player will join when the player with the most kills dies." };
                AJoin.Items.AddRange(Modes2);
                string[] Modes3 = { "Disable", "In all modes", "Only in Instagib (Riffle)" };
                zCatchAC.Items.Clear();
                zCatchAC.Items.AddRange(Modes3);
                if (lastindex2 == -1) zMode.SelectedIndex = 0;
                else zMode.SelectedIndex = lastindex2;
                if (lastindex3 == -1) AJoin.SelectedIndex = 1;
                else AJoin.SelectedIndex = lastindex3;
                if (lastindex4 == -1) zCatchAC.SelectedIndex = 2;
                else zCatchAC.SelectedIndex = lastindex4;
                toolTip1.SetToolTip(ColIndi, "Color of the tea adapts depending on the number of captive players.");
                toolTip1.SetToolTip(Bonus, "Gives the last player extra points.");
                toolTip1.SetToolTip(zLaserJump, "If this activated, you can jump with the laser like a Rocketlauncher.");
                toolTip1.SetToolTip(VoteFoRea, "Only Votes with a reason are allowed.");
                toolTip1.SetToolTip(SuicTime, "Minimum of time to suicide.\n0 = restrict selfkill.");
                toolTip1.SetToolTip(GreMinDmg, "In the \"Only Grenade\" mode, how much damage you need to kill a enemy.");
                toolTip1.SetToolTip(FollowCatcher, "A catched player follow the Catcher if this activated.");
                toolTip1.SetToolTip(zCatchAC, "In which mode should the \"Anticamper\" be active?\n0 = Disable\n1 = In all modes\n2 = Only in Instagib (Riffle)");
                toolTip1.SetToolTip(ACFreTi, "Time in seconds, howlong the camper should be frezze!\n0 = Kill the camper");
                toolTip1.SetToolTip(KillPena, "Amount of points which the score will be decreased on each suicide.");
                //Survival
                toolTip1.SetToolTip(SurGiveArm, "Number of Armor, which the player have at start.");
                toolTip1.SetToolTip(SurGiveGren, "Number of Ammo for the Rocketlauncher.\n-1 = Infinitive");
                toolTip1.SetToolTip(SurGiveGun, "Should the pistol aviable for the player?");
                toolTip1.SetToolTip(SurGiveHam, "Should the hammer aviable for the player?");
                toolTip1.SetToolTip(SurGiveHea, "Number of Health, which the player have at start.");
                toolTip1.SetToolTip(SurGiveLaser, "Number of Ammo for the Laser.\n-1 = Infinitive");
                toolTip1.SetToolTip(SurGiveShot, "Number of Ammo for the Shotgun.\n-1 = Infinitive");
                toolTip1.SetToolTip(SurHidePick, "Shouldn´t the Hearts and Armor aviable to pickup?");
                toolTip1.SetToolTip(SurHideWea, "Shouldn´t the Weapons aviable to pickup?");
                toolTip1.SetToolTip(SurRespPick, "Should the Hearts and Armor respawn after pickup?");
                toolTip1.SetToolTip(SurRespWeap, "Should the Weapons respawn after pickup?");
                //Hammerparty
                toolTip1.SetToolTip(HPHamStr, "Strength of the Hammer.");
                //Infection
                int lastindex5 = InfecZombExplo.SelectedIndex;
                toolTip1.SetToolTip(InfectWaDel, "Time in seconds, before wall is active.");
                toolTip1.SetToolTip(InfectWaLife, "Time in seconds, the wall stays.");
                toolTip1.SetToolTip(InfectWaLenght, "Length in Pixel of a wall.");
                toolTip1.SetToolTip(InfectDelay, "Delay before the IZombie gets chosen.");
                toolTip1.SetToolTip(InfectAirStrKill, "Kills needed for an airstrike.");
                toolTip1.SetToolTip(InfectSupJum, "Kills needed for superjump.");
                toolTip1.SetToolTip(InfectSupJumFor, "Strength of superjump.");
                toolTip1.SetToolTip(InfecZombExplo, "Zombies explode.\n0 = off\n1 = IZombie\n2 = All Zombies");
                string[] modes4 = {"Off", "IZombie", "All Zombies"};
                InfecZombExplo.Items.Clear();
                InfecZombExplo.Items.AddRange(modes4);
                if(lastindex5 == -1) InfecZombExplo.SelectedIndex = 1;
                else InfecZombExplo.SelectedIndex = lastindex5;
                toolTip1.SetToolTip(InfectAirText, "Text send when someone earns an airstrike.\n%s = playername");
                toolTip1.SetToolTip(InfectSJT, "Text send when someone earns superjump.\n%s = playername");
                //Foot/TeeBall
                toolTip1.SetToolTip(FootBouLoss, "The ball loses that much speed after a bounce.");
                toolTip1.SetToolTip(FootExplo, "Should the grenades explode after a goal?");
                toolTip1.SetToolTip(FootSpaDel, "Spawn delay in milliseconds for players after a kill.");
                toolTip1.SetToolTip(FootBallResp, "Respawn time in seconds of the ball.");
                toolTip1.SetToolTip(FootScorDiff, "Difference between the team-scores before a team can win.");
                toolTip1.SetToolTip(FootDSDiff, "Difference between the team-scores before a team can win in sudden death.");
                toolTip1.SetToolTip(FootKeepTime, "Time in seconds to hold the ball.");
                toolTip1.SetToolTip(FootHitKeepTime, "Keep time in seconds after you have hit with hammer.");
                toolTip1.SetToolTip(FootSelfkillScore, "Negative score for selfkill.");
                toolTip1.SetToolTip(FootRspwnTime, "Time in seconds to respawn after selfkill.");
                toolTip1.SetToolTip(FootBasket, "Dunking and Basketball-Scoresystem on or off?");
                toolTip1.SetToolTip(FootSelfkill, "Enable or disable selfkill.");
                toolTip1.SetToolTip(FootGreStaSpe, "Value for grenadespeed, which adapt at the own speed.");
                toolTip1.SetToolTip(FootHookTeam, "Can hook your team?");
                toolTip1.SetToolTip(FootHookKeep, "Can hook the Goalkeeper?");
                toolTip1.SetToolTip(FootGoalKeep, "Enable or disable Goalkeeper.");
                toolTip1.SetToolTip(FootGoKeTi, "Keeptime in seconds for goalkeepers.");
                toolTip1.SetToolTip(FootReal, "Hammerhits on or off?");
                toolTip1.SetToolTip(FootKeJump, "Endless jumping for goalkeepers?");
                toolTip1.SetToolTip(FootGreDeath, "Die on grenadepickup?\nImportant: Only activate this for a tabletennis map!");
                //Race
                toolTip1.SetToolTip(RaceReSlots, "Number of reserved slots.");
                toolTip1.SetToolTip(RaceInfAmmo, "Enable or disable infinite ammo.");
                toolTip1.SetToolTip(RaceReSloPW, "Password for reserved slots.");
                toolTip1.SetToolTip(RaceRegen, "Set regeneration per second.");
                toolTip1.SetToolTip(RaceStrip, "Enable or disable keeping weapon after teleporting.");
                toolTip1.SetToolTip(RaceNoItems, "Removes any items from the map if there are any.");
                toolTip1.SetToolTip(RaceTele, "Enable or disable teleportation.");
                toolTip1.SetToolTip(RaceTelGre, "Enable or disable teleport of grenade.");
                toolTip1.SetToolTip(RaceTelKill, "Teleporting one someone kills him.");
                toolTip1.SetToolTip(RaceTelVelRes, "Reset velocity after teleport.");
                toolTip1.SetToolTip(RaceDGAD, "Delete grenades after the player dies.");
                toolTip1.SetToolTip(RaceRoJuDmg, "Enable or disable rocket jump damage.");
                toolTip1.SetToolTip(RacePickResp, "Time before a pickup respawn.\n-1 = After Death");
                toolTip1.SetToolTip(RaceScoreIP, "Check score for ip, too.");
                toolTip1.SetToolTip(RaceCheckpSave, "Save checkpoint times to score file.");
                toolTip1.SetToolTip(RaceScoreFold, "Folder to save score files to.");
                toolTip1.SetToolTip(RaceShowTimes, "Show the times of other players.");
                toolTip1.SetToolTip(RaceShowOthers, "Show other players.");
                toolTip1.SetToolTip(RaceLoadMapDef, "Set the settings on map change/reload which are stored in the map.");
                toolTip1.SetToolTip(RaceUseSQL, "Enables SQL DB instead of record file.");
                toolTip1.SetToolTip(RaceSqlPort, "SQL User.");
                toolTip1.SetToolTip(RaceSqlUser, "SQL Password.");
                toolTip1.SetToolTip(RaceSqlPW, "SQL Database IP.");
                toolTip1.SetToolTip(RaceSqlIP, "SQL Database port.");
                toolTip1.SetToolTip(RaceSqlDatabase, "SQL Database name.");
                toolTip1.SetToolTip(RaceSqlPrefix, "SQL Database table prefix.");
                //Teeking
                string[] modes5 = { "Grenades", "Rifle", "Grenades and Rifle" };
                int lastindex6 = TeekingStartWea.SelectedIndex;
                TeekingStartWea.Items.Clear();
                TeekingStartWea.Items.AddRange(modes5);
                if (lastindex6 == -1) TeekingStartWea.SelectedIndex = 1;
                else TeekingStartWea.SelectedIndex = lastindex6;
                toolTip1.SetToolTip(TeekingStartWea, "Chose which weapon can be used.\n0 = Grenades.\n1 = Rifle.\n2 = Grenades and Rifle.");
                toolTip1.SetToolTip(TeekingJumps, "Max number of jumps for king!\n-1 = infinitive.");
                toolTip1.SetToolTip(TeekingKFirespeed, "The firespeed of the King.");
                toolTip1.SetToolTip(TeekingTFirespeed, "The firespeed of the Tees.");
                toolTip1.SetToolTip(TeekingImorTime, "Time of immortality for player, who collected a ten armor.");
                toolTip1.SetToolTip(TeekingNofK, "Number of kings.\n-1 = for everybody.\n0 = LastKing mode.");
                toolTip1.SetToolTip(TeekingLKPrize, "Prize for the last king.\nWorks only in LastKing mode.");
                toolTip1.SetToolTip(TeekingKingPrize, "Prize for king, who killed a king.");
                //WaterMOD
                groupBox25.Text = "WaterMOD(for TW 0.6)";
                UseWater.Text = "Use WasserMOD";
                toolTip1.SetToolTip(WModGravity, "Gravity in water.");
                toolTip1.SetToolTip(WModMaxX, "Max. velocity in x direction when in water.");
                toolTip1.SetToolTip(WModMaxY, "Max. velocity in Y direction when in water.");
                toolTip1.SetToolTip(WModFrict, "Friction in water.");
				toolTip1.SetToolTip(WModGain, "Added speed if in flowing water.");
				toolTip1.SetToolTip(WModOxy, "Use oxygen in water.");
				toolTip1.SetToolTip(WModOxyDeg, "Speed of oxygen degeneration in water.\n50 = 1sec");
				toolTip1.SetToolTip(WModOxyReg, "Speed of oxygen regeneration out of water.\n50 = 1sec");
				toolTip1.SetToolTip(WModOxyEmoID, "Number of emote to show when getting damage due to oxygen.");
				toolTip1.SetToolTip(WModReflection, "Reflect lasers at water.");
                //Extra Lines
                XtraLines.Text = "Extra Lines";
                XtraLinesDescripton.Text = "If TCC don´t support a mod then you can add here your own config lines.";
            }
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (englischToolStripMenuItem.Checked)
            {
                deutschToolStripMenuItem.Checked = true;
                englischToolStripMenuItem.Checked = false;
                ChangeLang("DE");
                lang = "DE";
                saveSetting();
            }
            else
            {
                deutschToolStripMenuItem.Checked = true;
                ChangeLang("DE");
                lang = "DE";
                saveSetting();
            }
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deutschToolStripMenuItem.Checked)
            {
                englischToolStripMenuItem.Checked = true;
                deutschToolStripMenuItem.Checked = false;
                ChangeLang("EN");
                lang = "EN";
                saveSetting();
            }
            else
            {
                englischToolStripMenuItem.Checked = true;
                ChangeLang("EN");
                lang = "EN";
                saveSetting();
            }
        }

        private void UpdaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	Updater.ShowDialog();
        }

        private void TCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSetting();
        }

        private void saveSetting()
        {
            Properties.Settings.Default.HelpActive = hilfeToolStripMenuItem.Checked;
            Properties.Settings.Default.Lang = lang;
            Properties.Settings.Default.LastFile = LastFile;
            Properties.Settings.Default.Save();
        }

        private void beendenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(zMode.SelectedIndex == 3) GreMinDmg.Enabled = true;
            else GreMinDmg.Enabled = false;
        }

        private void zCatchAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zCatchAC.SelectedIndex != 0) ACFreTi.Enabled = true;
            else ACFreTi.Enabled = false;
        }

        private void startDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SSCreator.ShowDialog();
        }

        private void useTune_CheckedChanged(object sender, EventArgs e)
        {
            groupBox10.Enabled = useTune.Checked;
            groupBox11.Enabled = useTune.Checked;
            groupBox12.Enabled = useTune.Checked;
            groupBox13.Enabled = useTune.Checked;
            groupBox14.Enabled = useTune.Checked;
            groupBox15.Enabled = useTune.Checked;
            groupBox16.Enabled = useTune.Checked;
            groupBox17.Enabled = useTune.Checked;
        }

        private void TCC_Shown(object sender, EventArgs e)
        {
            loadSettings();
            LoadMaps();
        }

        private void LoadMaps()
        {
            Map.Items.Clear();
            MapRotForm.SelectMap.Items.Clear();
            if (Directory.Exists(Properties.Settings.Default.TWFolder + @"\data\maps"))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Properties.Settings.Default.TWFolder + @"\data\maps");
                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo fiOutput in files)
                {
                    if (fiOutput.Extension == ".map")
                    {
                        Map.Items.Add(Path.GetFileNameWithoutExtension(fiOutput.FullName));
                        MapRotForm.SelectMap.Items.Add(Path.GetFileNameWithoutExtension(fiOutput.FullName));
                    }
                }
            }
            if (Properties.Settings.Default.LoadAppdataMaps)
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Teeworlds\maps"))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Teeworlds\maps");
                    FileInfo[] Appdatafiles = dirInfo.GetFiles();
                    foreach (FileInfo fiOutput in Appdatafiles)
                    {
                        if (fiOutput.Extension == ".map")
                        {
                            Map.Items.Add(Path.GetFileNameWithoutExtension(fiOutput.FullName));
                            MapRotForm.SelectMap.Items.Add(Path.GetFileNameWithoutExtension(fiOutput.FullName));
                        }
                    }
                }
            }
        }

        private void MapRotAdd_Click(object sender, EventArgs e)
        {
            MapRotForm.ShowDialog();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option.ShowDialog();
        }

        private void MaxClients_ValueChanged(object sender, EventArgs e)
        {
            SpecSlots.Maximum = MaxClients.Value - 1;
            MaxClientspIP.Maximum = MaxClients.Value;
        }

        private void RaceUseSQL_CheckedChanged(object sender, EventArgs e)
        {
            label95.Enabled = RaceUseSQL.Checked;
            RaceSqlPort.Enabled = RaceUseSQL.Checked;
            label92.Enabled = RaceUseSQL.Checked;
            RaceSqlUser.Enabled = RaceUseSQL.Checked;
            label93.Enabled = RaceUseSQL.Checked;
            RaceSqlPW.Enabled = RaceUseSQL.Checked;
            label94.Enabled = RaceUseSQL.Checked;
            RaceSqlIP.Enabled = RaceUseSQL.Checked;
            label96.Enabled = RaceUseSQL.Checked;
            RaceSqlDatabase.Enabled = RaceUseSQL.Checked;
            label97.Enabled = RaceUseSQL.Checked;
            RaceSqlPrefix.Enabled = RaceUseSQL.Checked;
        }

        private void speichernunterStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.TWFolder;
            CreateConfig();
            saveFileDialog1.ShowDialog();
        }

        private void MapRefresh_Click(object sender, EventArgs e)
        {
            LoadMaps();
        }

        private void TeekingNofK_ValueChanged(object sender, EventArgs e)
        {
            if (TeekingNofK.Value == -1)
            {
                label104.Enabled = true;
                TeekingLKPrize.Enabled = true;
            }
            else
            {
                label104.Enabled = false;
                TeekingLKPrize.Enabled = false;
            }
            if (TeekingNofK.Value <= MaxClients.Value && TeekingNofK.Value != -1)
            {
                label105.Enabled = true;
                TeekingKingPrize.Enabled = true;
            }
            else
            {
                label105.Enabled = false;
                TeekingKingPrize.Enabled = false;
            }
        }
        
        void UseWaterCheckedChanged(object sender, EventArgs e)
        {
        	if(UseWater.Checked == true)
        	{
	        	groupBox26.Enabled = true;
        		groupBox6.Enabled = false;
        	}
        	else if(UseWater.Checked == false && GType.Text == "idm" || GType.Text == "itdm" || GType.Text == "ictf")
        	{
	        	groupBox26.Enabled = false;
        		groupBox6.Enabled = true;
        	}
        	else
        	{
        		groupBox26.Enabled = false;
        		groupBox6.Enabled = false;
        	}
        }
    }
}
