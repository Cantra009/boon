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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprisonerreport_Click(object sender, EventArgs e)
        {
            frmprisonerbydate d = new frmprisonerbydate();
            d.Show();
        }

        private void btncomreport_Click(object sender, EventArgs e)
        {
            ComplaintReport com = new ComplaintReport();
            com.Show();
        }

        private void btnfirreport_Click(object sender, EventArgs e)
        {
            FirReportByDate Fir = new FirReportByDate();
            Fir.Show();
        }
    }
}
