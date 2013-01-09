using System;
using System.Windows.Forms;

namespace Teeworlds_Config_Creator
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            var Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            InitializeComponent();
            this.Text = String.Format("About {0}", Application.ProductName);
            this.labelProductName.Text = Application.ProductName;
            this.labelVersion.Text = String.Format("{0}.{1}_1 (Build {2})", Version.Major, Version.Minor, Version.Build);
            this.labelCopyright.Text = "Copyright © 2011-2013 Nils Helmig";
            this.labelCompanyName.Text = Application.CompanyName;
        }
    }
}
