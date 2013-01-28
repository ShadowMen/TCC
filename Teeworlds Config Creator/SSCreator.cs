using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class BatCreator : Form
    {
        public BatCreator()
        {
            InitializeComponent();
        }

        private void ButServ_Click(object sender, EventArgs e)
        {
            ExeÖffner.InitialDirectory = Properties.Settings.Default.TWFolder;
            ExeÖffner.ShowDialog();
        }

        private void ExeÖffner_FileOk(object sender, CancelEventArgs e)
        {
            ServerBrowse.Text = ExeÖffner.SafeFileName;
        }

        private void ButCfg_Click(object sender, EventArgs e)
        {
            CfgÖffner.InitialDirectory = Properties.Settings.Default.TWFolder;
            CfgÖffner.ShowDialog();
        }

        private void CfgÖffner_FileOk(object sender, CancelEventArgs e)
        {
            CfgBrowse.Text = CfgÖffner.SafeFileName;
        }

        private void ServerBrowse_TextChanged(object sender, EventArgs e)
        {
            Output.Text = ServerBrowse.Text + " -f " + CfgBrowse.Text;
        }

        private void CfgBrowse_TextChanged(object sender, EventArgs e)
        {
            Output.Text = ServerBrowse.Text + " -f " + CfgBrowse.Text;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Stream stream = saveFileDialog1.OpenFile();
            var writer = new StreamWriter(stream);
            writer.Write(Output.Text);
            writer.Close();
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}