using System;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    public partial class Maprotation : Form
    {
        private readonly TCC TeConCre;

        public Maprotation(TCC T)
        {
            InitializeComponent();
            TeConCre = T;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (SelectMap.Text == "")
            {
                if (Properties.Settings.Default.Lang == "DE")
                    MessageBox.Show("Bitt wählen sie eine Map aus bevor sie auf \"Hinzufügen\" klicken!");
                if (Properties.Settings.Default.Lang == "EN")
                    MessageBox.Show("Please select a map before you click on \"Add\"!");
            }
            else
            {
                Maps.Items.Add(SelectMap.Text);
                SelectMap.Text = "";
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (Maps.SelectedIndex > -1) Maps.Items.RemoveAt(Maps.SelectedIndex);
        }

        private void Maprotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            string maaps = "";
            for (int i = 0; i < Maps.Items.Count; i++)
            {
                if (maaps == "") maaps += Maps.Items[i].ToString();
                else maaps += " " + Maps.Items[i];
            }
            TeConCre.MapRot.Text = maaps;
        }

        private void Maprotation_Load(object sender, EventArgs e)
        {
            SelectMap.SelectedIndex = -1;
            Maps.Items.Clear();
            if (TeConCre.MapRot.Text.Length > 0) Maps.Items.AddRange(TeConCre.MapRot.Text.Split(char.Parse(" ")));
        }
    }
}