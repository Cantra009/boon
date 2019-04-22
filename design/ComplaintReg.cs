using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace design
{
    public partial class ComplaintReg : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        SqlCommand cmd;
        int CID;
        public ComplaintReg()
        {
            InitializeComponent();
        }

        private void ComplaintReg_Load(object sender, EventArgs e)
        {
            Clear();
            Getdata();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public void Getdata()
        {
            try
            {
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT * FROM tbl_Complaint order by CaseNumber DESC";
                cmd = new SqlCommand(stmt, con);

                con.Open();



                SqlDataReader rd = cmd.ExecuteReader();
                lvComplaint.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["CaseNumber"].ToString());
                    lv.SubItems.Add(rd["Destnict"].ToString());
                    lv.SubItems.Add(rd["DateOfCase"].ToString());
                    lv.SubItems.Add(rd["ComplaintName"].ToString());
                    lv.SubItems.Add(rd["Address"].ToString());
                    lv.SubItems.Add(rd["PlaceOfAccident"].ToString());
                    lv.SubItems.Add(rd["CaseDetail"].ToString());
                    lv.SubItems.Add(rd["CriminalName"].ToString());
                    lv.SubItems.Add(rd["CriminalAdress"].ToString());
                    lv.SubItems.Add(rd["WitnessName"].ToString());
                    lv.SubItems.Add(rd["WitnessAddress"].ToString());
                    lvComplaint.Items.Add(lv);
                }

                rd.Close();
                //cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error acured    " + ex.Message);
            }
        }
        private void Clear()
        {
            txtcasedetail.Text = "";
            txtcomadd.Text = "";
            txtcomname.Text = "";
            txtcriminaladd.Text = "";
            txtcriminalname.Text = "";
            txtdestnict.Text = "";
            txtplace.Text = "";
            txtwitnessadd.Text = "";
            txtwitnessname.Text = "";
            dofcase.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HOME_PAGE m = new HOME_PAGE();
            m.Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdestnict.Text != "" && txtplace.Text != "" && txtcomadd.Text != "" && txtcomname.Text != "" && txtcriminalname.Text != "" && txtcriminaladd.Text != "" && txtwitnessadd.Text != "" && txtwitnessname.Text != "")
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[tbl_Complaint]([Destnict],[DateOfCase],[ComplaintName],[Address],[PlaceOfAccident],[CaseDetail] ,[CriminalName],[CriminalAdress] ,[WitnessName],[WitnessAddress]) VALUES('"+txtdestnict.Text+ "','"+dofcase.Text+"','" + txtcomname.Text+ "','"+txtcomadd.Text+"','"+txtplace.Text+"','"+txtcasedetail.Text+ "','"+txtcriminalname.Text+"','"+txtcriminaladd.Text+"','"+txtwitnessname.Text+"','"+txtwitnessadd.Text+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    Clear();
                    Getdata();


                }


                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want to update this Complaint", "Update Complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE[dbo].[tbl_Complaint] SET[Destnict] ='"+txtdestnict.Text+ "' ,[DateOfCase] ='"+dofcase.Text+ "',[ComplaintName] ='"+txtcomname.Text+ "' ,[Address] ='"+txtcomadd.Text+ "',[PlaceOfAccident] ='"+txtplace.Text+ "'  ,[CaseDetail] ='"+txtcasedetail.Text+ "' ,[CriminalName] ='"+txtcomname.Text+ "',[CriminalAdress] ='"+txtcriminaladd.Text+ "',[WitnessName] ='"+txtwitnessname.Text+ "',[WitnessAddress] ='"+txtwitnessadd.Text+"' WHERE CaseNumber=" + CID + "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    // step 5: close the connection
                    con.Close();
                    Clear();
                    Getdata();
                    CID.Equals("");

                    // notify success message
                    MessageBox.Show("Data Updated Success Fully");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Do You Want to Delete this Complaint", "Delete This Complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM tbl_Complaint where CaseNumber='" + CID + "'";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();

                    //notify success message
                    Clear();
                    Getdata();
                    MessageBox.Show(" Data has been Deleted");

                }
                else
                {


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void lvComplaint_Click(object sender, EventArgs e)
        {
            try
            {
                btndelete.Enabled = true;
                CID = int.Parse(lvComplaint.SelectedItems[0].SubItems[0].Text);
                btndelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lvComplaint_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnupdate.Enabled = true;

                CID = int.Parse(lvComplaint.SelectedItems[0].SubItems[0].Text);
                txtdestnict.Text = lvComplaint.SelectedItems[0].SubItems[1].Text;
                dofcase.Text = lvComplaint.SelectedItems[0].SubItems[2].Text;
                txtcomname.Text = lvComplaint.SelectedItems[0].SubItems[3].Text;
                txtcomadd.Text = lvComplaint.SelectedItems[0].SubItems[4].Text;
                txtplace.Text = lvComplaint.SelectedItems[0].SubItems[5].Text;
                txtcasedetail.Text = lvComplaint.SelectedItems[0].SubItems[6].Text;
                txtcriminalname.Text = lvComplaint.SelectedItems[0].SubItems[7].Text;
                txtcriminaladd.Text = lvComplaint.SelectedItems[0].SubItems[8].Text;
                txtwitnessname.Text = lvComplaint.SelectedItems[0].SubItems[9].Text;
                txtwitnessadd.Text = lvComplaint.SelectedItems[0].SubItems[10].Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtserch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT *FROM tbl_Complaint  where ComplaintName  like('%"+txtserch.Text.Trim()+"%') ";
                cmd = new SqlCommand(stmt, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                lvComplaint.Items.Clear();
                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["CaseNumber"].ToString());
                    lv.SubItems.Add(rd["Destnict"].ToString());
                    lv.SubItems.Add(rd["DateOfCase"].ToString());
                    lv.SubItems.Add(rd["ComplaintName"].ToString());
                    lv.SubItems.Add(rd["Address"].ToString());
                    lv.SubItems.Add(rd["PlaceOfAccident"].ToString());
                    lv.SubItems.Add(rd["CaseDetail"].ToString());
                    lv.SubItems.Add(rd["CriminalName"].ToString());
                    lv.SubItems.Add(rd["CriminalAdress"].ToString());
                    lv.SubItems.Add(rd["WitnessName"].ToString());
                    lv.SubItems.Add(rd["WitnessAddress"].ToString());
                    lvComplaint.Items.Add(lv);
                }

                rd.Close();
                //cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error acured    " + ex.Message);
            }
        }

        private void lvComplaint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
