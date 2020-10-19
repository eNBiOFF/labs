using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace lab04
{
    public partial class Form1 : Form
    {
        List<string> wr = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*name file|*.txt";

            if(fd.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                string text = File.ReadAllText(fd.FileName);
                char[] separator = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] arraytext = text.Split(separator);
                
                foreach(string strtmp in arraytext)
                {
                    string str = strtmp.Trim();
                    if (!wr.Contains(str)) wr.Add(str);
                }

                t.Stop();
                this.textBox1.Text = fd.FileName.ToString();
                this.textBox2.Text = t.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FindWord_Click_Click(object sender, EventArgs e)
        {
            string Fwrd = this.textBoxFindword.Text.Trim();

            if(!string.IsNullOrEmpty(Fwrd) && wr.Count>0)
            {
                string uwrd = Fwrd.ToUpper();
                List<string> tmp = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                foreach(string str in wr)
                {
                    if(str.ToUpper().Contains(uwrd))
                    {
                        tmp.Add(str);
                    }
                }
                t.Stop();

                this.textBoxTimeSearch.Text = t.Elapsed.ToString();

                this.listBoxFoundWords.BeginUpdate();
                this.listBoxFoundWords.Items.Clear();
                foreach(string str in tmp)
                {
                    this.listBoxFoundWords.Items.Add(str);
                }
                this.listBoxFoundWords.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
