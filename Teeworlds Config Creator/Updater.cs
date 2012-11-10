using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
	public partial class Updater : Form
	{
        string NewFileName;
		public Updater()
		{
			InitializeComponent();
		}

		private void CheckConnection()
		{
			try
			{
				System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
				System.Net.NetworkInformation.PingReply pingreply = ping.Send(Properties.Settings.Default.UpdateServer, 5000);
				if (pingreply.Status == System.Net.NetworkInformation.IPStatus.Success) CheckVersion();
				else
				{
					NoConnection();
				}
			}
			catch (System.Net.NetworkInformation.PingException)
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
				if (Properties.Settings.Default.Lang == "DE") startUp.Text = "Überprüfe! Bitte warten sie einen Moment...";
				if (Properties.Settings.Default.Lang == "EN") startUp.Text = "Checking! Please wait a moment...";
				WebClient downloader = new WebClient();
				Stream stream = downloader.OpenRead(@"http://" + Properties.Settings.Default.UpdateServer + "/version.txt");
				StreamReader reader = new StreamReader(stream);
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
			catch(WebException)
			{
				NoConnection();
			}
			catch(Exception error)
			{
				FoundedError(error);
			}
		}

		private void startUp_Click(object sender, EventArgs e)
		{
			try
			{
				WebClient Download = new WebClient();
				Stream stream = Download.OpenRead(@"http://"+ Properties.Settings.Default.UpdateServer +"/version.txt");
				StreamReader reader = new StreamReader(stream);
				string Version = reader.ReadLine();
				Version = reader.ReadLine();
                NewFileName = "TCC - V" + Version + ".exe";
                Download.DownloadFileAsync(new Uri(@"http://" + Properties.Settings.Default.UpdateServer + "/TeeworldsConfigCreator.exe"), NewFileName);
				Download.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
				Download.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
			}
			catch (Exception error)
			{
				MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
			}
		}

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBar.Value = e.ProgressPercentage;
			DownloadByte.Text = string.Format("{0}kb/{1}kb  {2}%", e.BytesReceived/1024, e.TotalBytesToReceive/1024, e.ProgressPercentage);
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

            System.Diagnostics.Process.Start(NewFileName, "-delete " + Application.ExecutablePath);
            Application.Exit();
		}
		
		void UpdaterShown(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.Lang == "EN") startUp.Text = "Connect to the update server...";
			if (Properties.Settings.Default.Lang == "DE") startUp.Text = "Verbinde mit den Update-Server...";
			startUp.Enabled = false;
			CheckConnection();
		}
		
		void FoundedError(Exception error)
		{
			StreamWriter Writer = new StreamWriter("errorlog.txt");
			Writer.Write(error);
			Writer.Close();
			if (Properties.Settings.Default.Lang == "DE") {
				DialogResult Error = MessageBox.Show("Ein Fehler ist aufgetreten!\nBitte posten Sie, auf der Homepage, den Errorlog und versuchen Sie sich das Programm auf der Homepage zu downloaden.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (Error.ToString() == "Retry")
					CheckVersion();
				else
					this.Close();
			} else if (Properties.Settings.Default.Lang == "EN") {
				DialogResult Error2 = MessageBox.Show("An error has occurred!\nPlease post the error log on the website and try to download the program on the homepage.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (Error2.ToString() == "Retry")
					CheckVersion();
				else
					this.Close();
			}
		}
			
			void NoConnection()
		{
			if (Properties.Settings.Default.Lang == "DE") {
				DialogResult Fehler = MessageBox.Show("Es konnte keine Verbindung mit dem Update-Server erstellt werden!\nBitte versuche sie es später nocheinmal oder fragen Sie auf der Homepage ob es einen Fehler gibt!", "Server antwortet nicht", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (Fehler.ToString() == "Retry")
					CheckConnection();
				else
					this.Close();
			}
			if (Properties.Settings.Default.Lang == "EN") {
				DialogResult Fehler = MessageBox.Show("Couldn´t connect to the update server!\nPlease try it later or ask on the homepage whether it exist an error!", "Server didn´t response!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (Fehler.ToString() == "Retry")
					CheckConnection();
				else
					this.Close();
			}
		}
	}
}