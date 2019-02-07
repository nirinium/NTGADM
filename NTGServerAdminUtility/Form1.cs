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
using System.Net.NetworkInformation;
using System.IO;

namespace NTGServerAdminUtility
{
    public partial class Form1 : Form
    {
        Scintilla nTxtLog;

        private bool executeClicked = false;
        private bool localDebug = false;

        public Form1()
        {
            InitializeComponent();
            nStatus.ForeColor = Color.Green;
            nStatus.Text = "Connected!";
            //nStatus
            // CREATE CONTROL
            nTxtLog = new Scintilla();
            TextPanel.Controls.Add(nTxtLog);

            // BASIC CONFIG
            nTxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            //TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            nTxtLog.WrapMode = WrapMode.None;
            nTxtLog.IndentationGuides = IndentView.LookBoth;

            nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "Welcome to NTGADM, " + "Nirinium" + "! " + Environment.NewLine);
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
            nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "Flushing DNS..." + Environment.NewLine);
            if (localDebug == true)
            {
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] DEBUG > " + "ITEM INDEX = [" + selectedItem + "]" + Environment.NewLine);

            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //nStatus
            // CREATE CONTROL
            nTxtLog = new Scintilla();
            TextPanel.Controls.Add(nTxtLog);

            // BASIC CONFIG
            nTxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            //TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            nTxtLog.WrapMode = WrapMode.None;
            nTxtLog.IndentationGuides = IndentView.LookBoth;

            nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "Welcome to NTGADM, " + "Nirinium" + "! " + Environment.NewLine);
            
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
                //AppendText(nTxtLog, Color.Black, Font, Color.White, "");
                localDebug = false;
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + "DEBUG OFF" + Environment.NewLine);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void nSvrPing_Click(object sender, EventArgs e)
        {
            int timeout = 10;   //in ms

            Ping p = new Ping();
            PingReply rep = p.Send(listBox2.GetItemText(listBox2.SelectedItem), timeout);

            if (rep.Status == IPStatus.Success)
            {
                nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox2.GetItemText(listBox2.SelectedItem) + " is pingable" + Environment.NewLine);
            }
            else
            {
                p.Dispose();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = 0;

            if (checkBox2.Checked == true)
            {
                int timeout = 10;   //in ms

                Ping p = new Ping();
                PingReply rep = p.Send(listBox2.GetItemText(listBox2.SelectedItems[0]), timeout);

                if (rep.Status == IPStatus.Success)
                {
                    listBox2.ForeColor = Color.Green;
                    listBox2.Font = new Font("Consolas", 10, FontStyle.Bold);
                    nTxtLog.AppendText(" [ " + DateTime.Now + " ] " + listBox2.GetItemText(listBox2.SelectedItems.ToString()) + " is pingable" + Environment.NewLine);
                }
                else
                {
                    listBox2.ForeColor = Color.Red;
                }
            }
            else
            {
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {

            }
            else
            {
                listBox2.Items.Add(textBox1.Text);
            }
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                //
            }
            else
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string sPath = "servers.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox2.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Programs saved!");
        }

        private void serversLoad()
        {
            StreamReader sr = new StreamReader("servers.txt");
            string line = string.Empty;
            try
            {
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    this.listBox2.Items.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //close the file
                sr.Close();
            }
            //listBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serversLoad();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}

