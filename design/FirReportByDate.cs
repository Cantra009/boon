﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class FirReportByDate : Form
    {
        public FirReportByDate()
        {
            InitializeComponent();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            try
            {

                ReportDocument cryRpt = new ReportDocument();
                string path = "Firreport.rpt";
                cryRpt.Load(path);




                cryRpt.DataSourceConnections[0].SetConnection(@"DESKTOP-98CRERN\ENGKHALID", "CrimeFile", "integrated security = true", "");

                ParameterField param = new ParameterField();
                ParameterFields myparams = new ParameterFields();
                ParameterDiscreteValue mydiscrete = new ParameterDiscreteValue();

                param.ParameterFieldName = "@sdate";
                mydiscrete.Value = dtpstart.Text;
                param.CurrentValues.Add(mydiscrete);
                myparams.Add(param);
                ////
                param = new ParameterField();
                mydiscrete = new ParameterDiscreteValue();

                param.ParameterFieldName = "@edate";
                mydiscrete.Value = dtpend.Text;
                param.CurrentValues.Add(mydiscrete);

                myparams.Add(param);

                FrmReport objReprotVeiwer = new FrmReport();

                objReprotVeiwer.myviewer.ParameterFieldInfo = myparams;

                objReprotVeiwer.myviewer.ReportSource = cryRpt;
                objReprotVeiwer.Refresh();
                objReprotVeiwer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
