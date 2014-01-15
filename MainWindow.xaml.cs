using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

namespace backup_mngr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool showBaloon = true;

        NotifyIcon displayIcon;

        public MainWindow()
        {
            InitializeComponent();

            displayIcon = new NotifyIcon();

            displayIcon.Icon = Properties.Resources.Main;
            displayIcon.Visible = true;
            displayIcon.DoubleClick += ((object sender, EventArgs e) => { this.Show(); this.WindowState = WindowState.Normal; });
            displayIcon.BalloonTipClicked += ((object sender, EventArgs e) => { System.Diagnostics.Debug.WriteLine("Baloon!!!"); });
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
                if (showBaloon)
                {
                    showBaloon = false;
                    displayIcon.ShowBalloonTip(1000, "Minimized to Tray", "...", ToolTipIcon.Info);
                }
            }

            base.OnStateChanged(e);
        }
    }
}
