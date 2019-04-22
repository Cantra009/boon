using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace design
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }
        public CrystalReportViewer myviewer
        {
            get { return viewer; }
            set { viewer = value; }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
