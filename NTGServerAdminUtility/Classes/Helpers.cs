using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NTGServerAdminUtility.Classes
{
    class Helpers
    {
        public static class nDebug
        {
            public static void NLOG()
            {
                RichTextBox nDebugLog = new RichTextBox();
                nDebugLog.Location = new Point(20, 20);
                nDebugLog.Width = 300;
                nDebugLog.Height = 200;
                nDebugLog.Font = new Font("Consolas", 12);
                
            }

        }
    }
}
