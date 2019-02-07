using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace NTGServerAdminUtility
{
    public partial class Form1 : Form
    {

        private bool executeClicked = false;
        private bool localDebug = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedItem = listBox1.Items.IndexOf("Flush DNS");
            //executeClicked = true;
            foreach (object item in listBox1.Items)
            {
                if (listBox1.Items.Contains("Flush DNS"))
                {
                    Classes.Network.nTestDNS();
                    
                }
            }
            nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + " Flushing DNS..." + Environment.NewLine);
            nTxtLog.AppendText(" [ " + DateTime.Now + " ] DEBUG " + "ITEM INDEX = " + selectedItem + Environment.NewLine);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                //FLUSH DNS
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox1.GetItemText(listBox1.SelectedItem) + " is selected" + Environment.NewLine);
            }
            if (listBox1.SelectedIndex == 1)
            {
                //REGISTER DNS
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox1.GetItemText(listBox1.SelectedItem) + " is selected" + Environment.NewLine);
            }
            if (listBox1.SelectedIndex == 2)
            {
                //DISABLE NETWORK ADAPTERS
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox1.GetItemText(listBox1.SelectedItem) + " is selected" + Environment.NewLine);
            }
            if (listBox1.SelectedIndex == 3)
            {
                //ENABLE NETWORK ADAPTERS
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox1.GetItemText(listBox1.SelectedItem) + " is selected" + Environment.NewLine);
            }
            else
            {

                //nTxtLog.AppendText(listBox1.GetItemText(listBox1.SelectedItem) + " is selected" + Environment.NewLine);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                localDebug = true;
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] DEBUG > " + "DEBUG ON" + Environment.NewLine);
            }
            if (checkBox1.Checked == false)
            {
                localDebug = false;
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] DEBUG > " + "DEBUG OFF" + Environment.NewLine);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
