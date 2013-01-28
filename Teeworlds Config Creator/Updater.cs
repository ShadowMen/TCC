using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class Updater : Form
    {
        private string NewFileName;

        public Updater()
        {
            InitializeComponent();
        }

        private void CheckConnection()
        {
            try
            {
                var ping = new Ping();
                PingReply pingreply = ping.Send(Properties.Settings.Default.UpdateServer, 5000);
                if (pingreply.Status == IPStatus.Success) CheckVersion();
                else
                {
                    NoConnection();
                }
            }
            catch (PingException)
            {
                NoConnection();
            }
            catch (Exception error)
            {
                FoundedError(error);
            }
        }

        private void CheckVersion()
        {
            string NewVersion;
            decimal OldVersion = decimal.Parse(Application.ProductVersion);
            try
            {
                if (Properties.Settings.Default.Lang == "DE")
                    startUp.Text = "Überprüfe! Bitte warten sie einen Moment...";
                if (Properties.Settings.Default.Lang == "EN") startUp.Text = "Checking! Please wait a moment...";
                var downloader = new WebClient();
                Stream stream =
                    downloader.OpenRead(@"http://" + Properties.Settings.Default.UpdateServer + "/version.txt");
                var reader = new StreamReader(stream);
                NewVersion = reader.ReadLine();
                stream.Close();
                if (decimal.Parse(NewVersion) > OldVersion)
                {
                    if (Properties.Settings.Default.Lang == "DE") startUp.Text = "Neue Version herunterladen";
                    else if (Properties.Settings.Default.Lang == "EN") startUp.Text = "Update to the new version";
                    startUp.Enabled = true;
                }
                else if (decimal.Parse(NewVersion) <= OldVersion)
                {
                    if (Properties.Settings.Default.Lang == "DE") startUp.Text = "Keine neue Version vorhanden";
                    else if (Properties.Settings.Default.Lang == "EN") startUp.Text = "There are currently no update";
                }
            }
            catch (WebException)
            {
                NoConnection();
            }
            catch (Exception error)
            {
                FoundedError(error);
            }
        }

        private void startUp_Click(object sender, EventArgs e)
        {
            try
            {
                var Download = new WebClient();
                Stream stream = Download.OpenRead(@"http://" + Properties.Settings.Default.UpdateServer + "/version.txt");
                var reader = new StreamReader(stream);
                string Version = reader.ReadLine();
                Version = reader.ReadLine();
                NewFileName = "TCC - V" + Version + ".exe";
                Download.DownloadFileAsync(
                    new Uri(@"http://" + Properties.Settings.Default.UpdateServer + "/TeeworldsConfigCreator.exe"),
                    NewFileName);
                Download.DownloadProgressChanged += ProgressChanged;
                Download.DownloadFileCompleted += Completed;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            DownloadByte.Text = string.Format("{0}kb/{1}kb  {2}%", e.BytesReceived/1024, e.TotalBytesToReceive/1024,
                                              e.ProgressPercentage);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            startUp.Enabled = false;
            if (Properties.Settings.Default.Lang == "DE")
            {
                startUp.Text = "Herunterladen abgeschlossen";
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                startUp.Text = "Download complete";
            }

            Process.Start(NewFileName, "-delete " + Application.ExecutablePath);
            Application.Exit();
        }

        private void UpdaterShown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "EN") startUp.Text = "Connect to the update server...";
            if (Properties.Settings.Default.Lang == "DE") startUp.Text = "Verbinde mit den Update-Server...";
            startUp.Enabled = false;
            CheckConnection();
        }

        private void FoundedError(Exception error)
        {
            var Writer = new StreamWriter("errorlog.txt");
            Writer.Write(error);
            Writer.Close();
            if (Properties.Settings.Default.Lang == "DE")
            {
                DialogResult Error =
                    MessageBox.Show(
                        "Ein Fehler ist aufgetreten!\nBitte posten Sie, auf der Homepage, den Errorlog und versuchen Sie sich das Programm auf der Homepage zu downloaden.",
                        "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Error.ToString() == "Retry")
                    CheckVersion();
                else
                    Close();
            }
            else if (Properties.Settings.Default.Lang == "EN")
            {
                DialogResult Error2 =
                    MessageBox.Show(
                        "An error has occurred!\nPlease post the error log on the website and try to download the program on the homepage.",
                        "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Error2.ToString() == "Retry")
                    CheckVersion();
                else
                    Close();
            }
        }

        private void NoConnection()
        {
            if (Properties.Settings.Default.Lang == "DE")
            {
                DialogResult Fehler =
                    MessageBox.Show(
                        "Es konnte keine Verbindung mit dem Update-Server erstellt werden!\nBitte versuche sie es später nocheinmal oder fragen Sie auf der Homepage ob es einen Fehler gibt!",
                        "Server antwortet nicht", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Fehler.ToString() == "Retry")
                    CheckConnection();
                else
                    Close();
            }
            if (Properties.Settings.Default.Lang == "EN")
            {
                DialogResult Fehler =
                    MessageBox.Show(
                        "Couldn´t connect to the update server!\nPlease try it later or ask on the homepage whether it exist an error!",
                        "Server didn´t response!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Fehler.ToString() == "Retry")
                    CheckConnection();
                else
                    Close();
            }
        }
    }
}