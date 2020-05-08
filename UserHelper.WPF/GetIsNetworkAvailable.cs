using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper.WPF
{
    class GetIsNetworkAvailable
    {
        public bool CheckInternetConnction()
        {
            var result = false;

            //if (NetworkInterface.GetIsNetworkAvailable() && new Ping().Send(new IPAddress(new byte[] { 8, 8, 8, 8 }), 2000).Status == IPStatus.Success)
            //    result = true;
            var request = (HttpWebRequest)WebRequest.Create("http://g.cn/generate_204");
            request.UserAgent = "Android";
            request.KeepAlive = false;
            request.Timeout = 1500;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.ContentLength == 0 && response.StatusCode == HttpStatusCode.NoContent)
                        result = true;
                }
            }
            catch(Exception ex)
            {
                //Connection to internet not available
            }
            return result;
        }
    }
}
