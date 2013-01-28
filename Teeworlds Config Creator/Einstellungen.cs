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
            TWServerFile.Text = Properties.Settings.Default.ServerEXE;
            TWfolderSearch.SelectedPath = TWPfad.Text;
            OpenLastFile.Checked = Properties.Settings.Default.OpenLastFile;
            OpenAppdata.Checked = Properties.Settings.Default.LoadAppdataMaps;
            if (Properties.Settings.Default.UpdateServer == "shadow-program.co.de") UpSerList.SelectedIndex = 0;
            else if (Properties.Settings.Default.UpdateServer == "update.shadow-software.php-friends.de")
                UpSerList.SelectedIndex = 1;
            if (Properties.Settings.Default.Lang == "DE")
            {
                Text = "Einstellungen";
                OpenLastFile.Text = "Beim Start die letzte verwendete Datei öffnen.";
                CheckUpdate.Text = "Beim Start auf Updates überprüfen.";
                OpenAppdata.Text = "Maps auch aus dem Appdata Ordner laden.";
                label1.Text = "Teeworlds Pfad:";
                label3.Text = "Teeworlds Server Datei: ";
                Cancle.Text = "Abbrechen";
                TWfolderSearch.Description = "Deinen Teeworlds Ordner finden";
                TWexeSearch.Title = "Wähle die Teeworlds Server Datei aus";
            }
            if (Properties.Settings.Default.Lang == "EN")
            {
                Text = "Settings";
                OpenLastFile.Text = "Open the last used file on startup";
                CheckUpdate.Text = "Check for Updates on Startup.";
                OpenAppdata.Text = "Load Maps from Appdata too.";
                label1.Text = "Teeworlds Path:";
                label3.Text = "Teeworlds server file: ";
                Cancle.Text = "Cancle";
                TWfolderSearch.Description = "Find your Teeworlds folder";
                TWexeSearch.Title = "Select Teeworlds Server File";
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesAtStartUp = CheckUpdate.Checked;
            Properties.Settings.Default.TWFolder = TWPfad.Text;
            Properties.Settings.Default.ServerEXE = TWServerFile.Text;
            Properties.Settings.Default.OpenLastFile = OpenLastFile.Checked;
            Properties.Settings.Default.LoadAppdataMaps = OpenAppdata.Checked;
            if (UpSerList.SelectedIndex == 0) Properties.Settings.Default.UpdateServer = "shadow-program.co.de";
            else if (UpSerList.SelectedIndex == 1)
                Properties.Settings.Default.UpdateServer = "update.shadow-software.php-friends.de";
            Properties.Settings.Default.Save();
            Close();
        }

        private void Cancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FolderSearch_Click(object sender, EventArgs e)
        {
            TWfolderSearch.ShowDialog();
            TWPfad.Text = TWfolderSearch.SelectedPath;
        }

        private void SearchExe_Click(object sender, EventArgs e)
        {
            TWexeSearch.InitialDirectory = TWPfad.Text;
            TWexeSearch.ShowDialog();
            TWServerFile.Text = TWexeSearch.SafeFileName;
        }
    }
}