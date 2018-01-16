using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace GingerBread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Classes.Files.Install();
            Classes.Audio.Load();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> syb = Classes.Text.GetSyllables(textBox1.Text);
            //string print = string.Empty;
            //for (int i = 0; i < syb.Count; i++) print += syb[i] + Environment.NewLine;
            //MessageBox.Show("FINAL\n" + print);
            Classes.Audio.Read(syb);
        }
    }
}