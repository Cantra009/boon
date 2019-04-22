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
    public partial class PrisonerHis : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        int PID;
        int HID;
        public PrisonerHis()
        {
            InitializeComponent();
        }

        private void PrisonerHis_Load(object sender, EventArgs e)
        {
            GetData();
            LoadPrisoner();
            clear();
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }
        private void clear()
        {
            txtnumoftimes.Text = "";
            cbprisoner.Text = "";
            PID.Equals("");
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void GetData()
        {
            try
            {
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT HID,tbl_PrisonerHistory.PrisonerID,PrisonerName,NOfTArrested from tbl_PrisonerHistory join tbl_Prisoner on tbl_Prisoner.PrisonerID = tbl_PrisonerHistory.PrisonerID";
                SqlCommand cmd = new SqlCommand(stmt, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                lvhistory.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["HID"].ToString());
                    lv.SubItems.Add(rd["PrisonerID"].ToString());
                    lv.SubItems.Add(rd["PrisonerName"].ToString());
                    lv.SubItems.Add(rd["NOfTArrested"].ToString());

                    lvhistory.Items.Add(lv);
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

        private void cbprisoner_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //laod the data from the db

                if (cbprisoner.Text == "")
                {

                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Prisoner WHERE PrisonerName='" + cbprisoner.Text + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PID = int.Parse(dr["PrisonerID"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvhistory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnupdate.Enabled = true;
                HID = int.Parse(lvhistory.SelectedItems[0].SubItems[0].Text);
                PID = int.Parse(lvhistory.SelectedItems[0].SubItems[1].Text);
                cbprisoner.Text = (lvhistory.SelectedItems[0].SubItems[2].Text.ToString());
                txtnumoftimes.Text = (lvhistory.SelectedItems[0].SubItems[3].Text.ToString());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadPrisoner()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_Prisoner ORDER BY PrisonerID", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cbprisoner.Items.Clear();

                while (dr.Read())
                {
                    cbprisoner.Items.Add(dr["PrisonerName"].ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvhistory_Click(object sender, EventArgs e)
        {
            try
            {
                btndelete.Enabled = true;
                HID = int.Parse(lvhistory.SelectedItems[0].SubItems[0].Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PID.Equals("") && txtnumoftimes.Text == "")
                {

                    MessageBox.Show("Feilds are Requiared");
                }
                else
                {

                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "INSERT INTO tbl_PrisonerHistory ([PrisonerID],[NOfTArrested]) VALUES(" + PID + ",'" + txtnumoftimes.Text + "')";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();
                    clear();
                    GetData();

                    //notify success message
                    MessageBox.Show("Data Saved Success Fully");
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
                if (MessageBox.Show("Do You Want to update  prisoner History", "Update Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE tbl_PrisonerHistory SET PrisonerID=" + PID + ",NOfTArrested='" + txtnumoftimes.Text + "' where HID=" + HID + "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();
                    GetData();
                    clear();

                    //notify success message
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
                if (MessageBox.Show("Do You Want to Delete  this prisoner History", "Delete Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM [dbo].[tbl_PrisonerHistory] WHERE HID =" + HID + "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();
                    GetData();
                    clear();

                    //notify success message
                    MessageBox.Show("Data Deleted Success Fully");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnexist_Click(object sender, EventArgs e)
        {
            mainpage m = new mainpage();
            m.Show();
        }
    }
}
