using System;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class Settings : Form
    {

        public Settings(TCC T)
        {
            InitializeComponent();
            Console.Write("Initialize Component!");
        }

        private void Options_Load(object sender, EventArgs e)
        {
            CheckUpdate.Checked = Properties.Settings.Default.CheckForUpdatesAtStartUp;
            TWPfad.Text = Properties.Settings.Default.TWFolder;
            folderBrowserDialog1.SelectedPath = TWPfad.Text;
            OpenLastFile.Checked = Properties.Settings.Default.OpenLastFile;
            OpenAppdata.Checked = Properties.Settings.Default.LoadAppdataMaps;
            if(Properties.Settings.Default.UpdateServer == "shadow-program.co.de") UpSerList.SelectedIndex = 0;
            else if(Properties.Settings.Default.UpdateServer == "update.shadow-software.php-friends.de") UpSerList.SelectedIndex = 1;
            if(Properties.Settings.Default.Lang == "DE")
            {
                this.Text = "Einstellungen";
                OpenLastFile.Text = "Beim Start die letzte verwendete Datei öffnen.";
                CheckUpdate.Text = "Beim Start auf Updates überprüfen.";
                OpenAppdata.Text = "Maps auch aus dem Appdata Ordner laden.";
                label1.Text = "Teeworlds Pfad:";
                Cancle.Text = "Abbrechen";
                folderBrowserDialog1.Description = "Deinen Teeworlds Ordner finden";
            }
            if (Properties.Settings.Default.Lang == "EN")
            {
                this.Text = "Settings";
                OpenLastFile.Text = "Open the last used file on startup";
                CheckUpdate.Text = "Check for Updates on Startup.";
                OpenAppdata.Text = "Load Maps from Appdata too.";
                label1.Text = "Teeworlds Path:";
                Cancle.Text = "Cancle";
                folderBrowserDialog1.Description = "Find your Teeworlds folder";
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesAtStartUp = CheckUpdate.Checked;
            Properties.Settings.Default.TWFolder = TWPfad.Text;
            Properties.Settings.Default.OpenLastFile = OpenLastFile.Checked;
            Properties.Settings.Default.LoadAppdataMaps = OpenAppdata.Checked;
            if(UpSerList.SelectedIndex == 0) Properties.Settings.Default.UpdateServer = "shadow-program.co.de";
            else if(UpSerList.SelectedIndex == 1) Properties.Settings.Default.UpdateServer = "update.shadow-software.php-friends.de";
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FolderSearch_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            TWPfad.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
