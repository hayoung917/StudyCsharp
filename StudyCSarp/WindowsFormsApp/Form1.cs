using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    //partial은 class가 하나만 있는건 아님
    //디자이너가 만든 것은 손대지 않게 하기 위해 분리된것
    public partial class Form1 : Form   
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            button1.Click += button1_Click_1;
            textBox1.KeyPress += textBox1_KeyPress_1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Event occurred");  //윈폼에서 제일 많이 사용함
            return;
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
            }
        }
    }
}
