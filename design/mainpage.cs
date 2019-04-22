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
    public partial class mainpage : Form
    {
        public mainpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel6.Height = btnreg.Height;
            panel6.Top = btnreg.Top;
            prisonerReg1.BringToFront();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel6.Height = btncomplaint.Height;
            panel6.Top = btncomplaint.Top;
            complaintReg1.BringToFront();



        }

        private void prisoner1_Load(object sender, EventArgs e)
        {

        }

        private void btnhistory_Click(object sender, EventArgs e)
        {
            panel6.Height = btnhistory.Height;
            panel6.Top = btnhistory.Top;
            prisonerHis1.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Height = btnresident.Height;
            panel6.Top = btnresident.Top;
            residentPrisoner1.BringToFront();


        }

        private void btnoutpri_Click(object sender, EventArgs e)
        {
            panel6.Height = btnoutpri.Height;
            panel6.Top = btnoutpri.Top;
            outPrisoner1.BringToFront();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Height = btnFIR.Height;
            panel6.Top = btnFIR.Top;
            fir1.BringToFront();

        }

        private void btnChangepass_Click(object sender, EventArgs e)
        {

            panel6.Height = btnCreateuser.Height;
            panel6.Top = btnCreateuser.Top;
            createUser1.BringToFront();



        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void residentPrisoner1_Load(object sender, EventArgs e)
        {

        }

        private void prisonerReg1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainpage_Load(object sender, EventArgs e)
        {

        }

        private void createUser1_Load(object sender, EventArgs e)
        {

        }

        private void residentPrisoner1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel6.Height = button2.Height;
            panel6.Top = button2.Top;
            home1.BringToFront();
        }

        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            panel6.Height = button3.Height;
            panel6.Top = button3.Top;
            helpCenter1.BringToFront();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            panel6.Height = button4.Height;
            panel6.Top = button4.Top;
            about1.BringToFront();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Report d = new Report();
            d.Show();
        }
    }
}
