using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTGServerAdminUtility.Classes
{
    class Network
    {
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        public static void nFlushDNS()
        {
            UInt32 result = DnsFlushResolverCache();
        }

        public static void nTestDNS()
        {
            int i = 0;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ipconfig /flushdns pause";            
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine("Flushing DNS..." + ++i);
        }

    }
}
