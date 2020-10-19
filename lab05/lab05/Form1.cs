using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vag_Fish;
using System.Diagnostics;
using System.IO;

namespace lab05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> wr = new List<string>();
        public VagFish vag = new VagFish();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*name file|*.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {

                string text = File.ReadAllText(fd.FileName);
                char[] separator = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] arraytext = text.Split(separator);

                foreach (string strtmp in arraytext)
                {
                    string str = strtmp.Trim();
                    if (!wr.Contains(str)) wr.Add(str);
                }

               
                this.textBox3.Text = fd.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string str = this.textBoxFindWr.Text.Trim();
            string MaxDist = this.MaxDistant.Text.Trim();
            if ((!string.IsNullOrEmpty(str))&&(!string.IsNullOrEmpty(MaxDist)))
            {
                string strUP = str.ToUpper();
                int dist = int.Parse(MaxDist);
                List<string> tmpstr = new List<string>();

                foreach (string tmp in wr)
                {
                    string st = tmp.Trim();
                    if (VagFish.Distant(st.ToUpper(), strUP) <= dist)
                    {
                        if (!tmpstr.Contains(st)) tmpstr.Add(st);
                    }
                }

                this.listBoxFoundWR.BeginUpdate();
                this.listBoxFoundWR.Items.Clear();
                foreach(string tmp in tmpstr)
                {
                    this.listBoxFoundWR.Items.Add(tmp).ToString();
                }
                this.listBoxFoundWR.EndUpdate();
            }
            else
            {
                MessageBox.Show("необходимо выбраь файл и ввести слово для поиска");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
