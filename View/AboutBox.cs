using TeraziAPI.Utility;
using System;
using System.Windows.Forms;

namespace TeraziAPI
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            AssemblyAccessors assembly = new AssemblyAccessors();

            this.Text = string.Format("About {0}", assembly.AssemblyTitle);

            this.labelProductName.Text = assembly.AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", assembly.AssemblyVersion);
            this.labelCopyright.Text = assembly.AssemblyCopyright;
            this.labelCompanyName.Text = assembly.AssemblyCompany;
            this.textBoxDescription.Text = assembly.AssemblyDescription;
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            
        }
    }
}