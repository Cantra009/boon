using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace design
{
    public partial class HOME_PAGE : Form
    {
        public HOME_PAGE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            mainpage mm = new mainpage();
            mm.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void okToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void operationFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainpage nn = new mainpage();
            nn.Show();
        }
    }
}
