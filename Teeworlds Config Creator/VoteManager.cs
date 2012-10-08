using System;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class VoteManager : Form
    {
        public VoteManager()
        {
            InitializeComponent();
        }

        private void VoteAdd_Click(object sender, EventArgs e)
        {
            if (Cmd.TextLength == 0 || Votename.TextLength == 0)
            {
                if (Properties.Settings.Default.Lang == "DE") MessageBox.Show("Beschreibung und Befehl dürfen nicht leer sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Properties.Settings.Default.Lang == "EN") MessageBox.Show("Description and Command must not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Vote;
                Vote = String.Format("add_vote" + " " + "\"" + Votename.Text.ToString() + "\"" + " " + Cmd.Text.ToString());
                VoteList.Items.Add(Vote);
                Votename.Text = "";
                Cmd.Text = "";
            }
        }

        private void VoteDel_Click(object sender, EventArgs e)
        {
            VoteList.Items.Remove(VoteList.SelectedItem);
        }
    }
}
