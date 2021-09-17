using TeraziAPI;
using System;
using System.Windows.Forms;

namespace TeraziAPI.View
{
    public class ContextMenus
    {
        #region Definitions

        private bool isAboutLoaded = false;

        #endregion Definitions

        #region Functions

        public ContextMenuStrip Create()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem;

            ////Data Reader
            //toolStripMenuItem = new ToolStripMenuItem { Text = "Data Reader"};
            //toolStripMenuItem.Click += new EventHandler(FormDataReader_Click);
            //contextMenuStrip.Items.Add(toolStripMenuItem);

            //About
            toolStripMenuItem = new ToolStripMenuItem { Text = "About", Image = TeraziAPI.Properties.Resources.About };
            toolStripMenuItem.Click += new EventHandler(About_Click);
            contextMenuStrip.Items.Add(toolStripMenuItem);

            // Separator
            contextMenuStrip.Items.Add(new ToolStripSeparator());

            // Exit
            toolStripMenuItem = new ToolStripMenuItem() { Text = "Exit", Image = TeraziAPI.Properties.Resources.Exit };
            toolStripMenuItem.Click += new System.EventHandler(Exit_Click);
            contextMenuStrip.Items.Add(toolStripMenuItem);

            return contextMenuStrip;
        }

        #endregion Functions

        #region Events

        private void About_Click(object sender, EventArgs e)
        {
            if (!isAboutLoaded)
            {
                isAboutLoaded = true;
                new AboutBox().ShowDialog();
                isAboutLoaded = false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
                System.Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Uygulama sonlandırma",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void FormDataReader_Click(object sender, EventArgs e)
        //{
        //    FormDataReader fDataReader = new FormDataReader();
        //    fDataReader.Show();

        //}
        #endregion Events
    }
}