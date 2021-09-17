using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TeraziAPI.View
{
    public class ProcessIcon : IDisposable
    {
        private readonly NotifyIcon notifyIcon;

        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            notifyIcon = new NotifyIcon();
        }

        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            notifyIcon.Dispose();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //Process.Start("explorer", null);
                    using (AboutBox fAboutBox = new AboutBox())
                    {
                        fAboutBox.ShowDialog();
                    }
                    break;

                case MouseButtons.None:
                    break;

                case MouseButtons.Right:
                    break;

                default:
                    break;
            }
        }

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.
            notifyIcon.MouseClick += new MouseEventHandler(NotifyIcon_MouseClick);
            notifyIcon.Icon = TeraziAPI.Properties.Resources.TeraziAPI;
            notifyIcon.Text = "Terazi API";
            notifyIcon.Visible = true;

            notifyIcon.ContextMenuStrip = new ContextMenus().Create();
        }

        public void ShowNotification(string text, string caption, ToolTipIcon icon, int miliseconds)
        {
            using (NotifyIcon notifyIcon = new NotifyIcon()

            {
                Icon = new Icon(SystemIcons.Application, 40, 40),
                Visible = true,
                BalloonTipTitle = caption,
                BalloonTipIcon = icon,
                BalloonTipText = text
            })
            {
                notifyIcon.ShowBalloonTip(miliseconds);
            }
        }
    }
}