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
using ScintillaNET;

namespace NTGServerAdminUtility
{
    public partial class Form1 : Form
    {

        private bool executeClicked = false;
        private bool localDebug = false;

        public Form1()
        {
            InitializeComponent();
            nStatus.Text = "Connected!";
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
            //nStatus
            nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "Welcome to NTGADM, " + "Nirinium" + "! "+ Environment.NewLine);

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
            void AppendText(RichTextBox nTxtBox, Color color, Font font, Color backcolor, string text)
            {
                int start = nTxtBox.TextLength;
                nTxtBox.AppendText(text);
                int end = nTxtBox.TextLength;

                nTxtBox.Select(start, end - start);
                {
                    nTxtBox.SelectionColor = color;
                    nTxtBox.SelectionFont = new Font("Consolas", 8);
                    nTxtBox.BackColor = backcolor;
                }
                nTxtBox.SelectionLength = 0; // clear
            }

            if (checkBox1.Checked == true)
            {

                //AppendText(this.nTxtLog, Color.Red, Font, Color.White, "");
                localDebug = true;
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] DEBUG > " + "DEBUG ON" + Environment.NewLine);
                
            }
            if (checkBox1.Checked == false)
            {
                //AppendText(this.nTxtLog, Color.Black, Font, Color.White, "");
                localDebug = false;
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "DEBUG OFF" + Environment.NewLine);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                nTxtLog.Clear();
            }
            else
            {
                //MessageBox.Show("You pressed Cancel!");
            }

            
        }

        private void nTxtLog_TextChanged(object sender, EventArgs e)
        {
            nTxtLog.ScrollCaret();
        }
    }
}
