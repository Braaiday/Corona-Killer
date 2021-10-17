using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corona_Killer
{
    public partial class Login_Pierre : Form
    {
        public Login_Pierre()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "pierre";
            string password = "123";
            if ((textBox1.Text == username) && (textBox2.Text == password))
            {
                Game_Pierre Game = new Game_Pierre();
                Game.Show();
                Hide();
            }
            if ((textBox1.Text != username))
            {
                MessageBox.Show("This account does not exist, register an account before signing in.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register_Pierre Register = new Register_Pierre();
            Register.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
