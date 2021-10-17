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
    public partial class Register_Pierre : Form
    {
        public Register_Pierre()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game_Pierre Game = new Game_Pierre();
            Game.Show();
            Hide();
        }
    }
}
