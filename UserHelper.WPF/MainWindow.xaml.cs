using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows;

namespace UserHelper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //GPupdate.Click += GPupdate_Click;
            //RebootPC.Click += RebootPC_Click;
        }
        private void GPupdate_Click(object sender, RoutedEventArgs e)
        {
            var update = new GPupdate();
            update.UpdateGroupPolicy();
        }

        private void RebootPC_Click(object sender, RoutedEventArgs e)
        {
            var update = new Reboot();
            update.RebootPC();
           
        }

        private void MachineName_Initialized(object sender, System.EventArgs e)
        {
            MachineName.Text = (System.Environment.MachineName);
        }
        /// <summary>
        /// Get IP adress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPs_Initialized(object sender, System.EventArgs e)
        {
            var addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();

            IPs.Text = addresses.First().ToString();

            //foreach (var address in addresses)
            //{
            //    IPs.Inlines.Add("  " +Convert.ToString(address));
            //}
        }
        /// <summary>
        /// Network drives info init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ND_Initialized(object sender, System.EventArgs e)
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MappedLogicalDisk");
            foreach (var queryObj in searcher.Get())
            {
                NDs.Inlines.Add("  "+queryObj["DeviceID"].ToString()+"  ");
            }
        }
        /// <summary>
        /// Logical Drives info init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LD_Initialized(object sender, System.EventArgs e)
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (var queryObj in searcher.Get())
            {
                if(queryObj["DeviceID"].ToString() == "C:" || queryObj["DeviceID"].ToString() == "D:")
                {
                    var space = Convert.ToInt64(queryObj["FreeSpace"]) /1024 /1024 /1024;
                    LDs.Inlines.Add("  "+queryObj["DeviceID"].ToString() + "  " +space.ToString() + "Gb");
                }                    
            }
        }

        private void PasswordEx_Initialized(object sender, System.EventArgs e)
        {
            var result = new AD();
            PWex.Text = result.GetPasswordExperationDate();
        }

        private void NetworkStatus_Initialized(object sender, System.EventArgs e)
        {
            var check = new GetIsNetworkAvailable();
            NA.Text = check.CheckInternetConnction().ToString();
        }
    }
}
