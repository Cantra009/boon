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
    public partial class ResidentPrisoner : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        int RID;
        int PID;
        public ResidentPrisoner()
        {
            InitializeComponent();
        }
        private void clear()
        {
            txtdate.Text = "";
            cbprisoner.Text = "";
            PID.Equals("");
            RID.Equals("");
            cbattendance.Text.Equals("");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
        public void Getdata()
        {
            try
            {

                button2.Enabled = false;
                button3.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT RID,tbl_Resident.PrisonerID,PrisonerName,Attedance,CONVERT(varchar,Date, 111) 'Date' from tbl_Resident join tbl_Prisoner on tbl_Prisoner.PrisonerID = tbl_Resident.PrisonerID";
                SqlCommand cmd = new SqlCommand(stmt, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                lstresident.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["RID"].ToString());
                    lv.SubItems.Add(rd["PrisonerID"].ToString());
                    lv.SubItems.Add(rd["PrisonerName"].ToString());
                    lv.SubItems.Add(rd["Date"].ToString());
                    lv.SubItems.Add(rd["Attedance"].ToString());
                    lstresident.Items.Add(lv);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
                //step 2: prepare the sql stmt and make sqlcommand obj
                string stmt = "INSERT INTO [dbo].[tbl_Resident]([PrisonerID],[Date],[Attedance])VALUES('"+PID+"','"+txtdate.Text+"','"+cbattendance.Text+"')";
                SqlCommand cmd = new SqlCommand(stmt, con);

                //step 3: open the connection obj
                con.Open();

                //Step 4: execute the command
                cmd.ExecuteNonQuery();

                //step 5: close the connection
                con.Close();
                //Getdata();


                Getdata();
                
                //notify success message
                MessageBox.Show("Data Saved Success Fully");


            
        }

        private void ResidentPrisoner_Load(object sender, EventArgs e)
        {
            LoadPrisoner();
            Getdata();
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private void lstresident_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = true;
                RID = int.Parse(lstresident.SelectedItems[0].SubItems[0].Text);
                PID = int.Parse(lstresident.SelectedItems[0].SubItems[1].Text);
                cbprisoner.Text= lstresident.SelectedItems[0].SubItems[2].Text;
                txtdate.Text = lstresident.SelectedItems[0].SubItems[3].Text;
                cbattendance.Text= lstresident.SelectedItems[0].SubItems[4].Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want to update this Resident", "Update Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE tbl_Resident SET PrisonerID='" + RID + "',Date='" + txtdate.Value.Date + "',Attedance='" + cbattendance.Text + "' where RID =" + RID + "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();
                    Getdata();

                    //notify success message
                    MessageBox.Show("Data Updated Success Fully");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    if (MessageBox.Show("Do You Want to Delete this Residen", "Delete This Residen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        //step 2: prepare the sql stmt and make sqlcommand obj
                        string stmt = "DELETE FROM tbl_Resident where RID='" + RID+ "'";
                        SqlCommand cmd = new SqlCommand(stmt, con);

                        //step 3: open the connection obj
                        con.Open();

                        //Step 4: execute the command
                        cmd.ExecuteNonQuery();

                        //step 5: close the connection
                        con.Close();

                        //notify success message
                        Getdata();
                        MessageBox.Show(" Data has been Dleted");

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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstresident_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Enabled = true;
                RID = int.Parse(lstresident.SelectedItems[0].SubItems[0].Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Prisoner WHERE PrisonerName='" +cbprisoner.Text + "'", con);
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

        private void button4_Click(object sender, EventArgs e)
        {
            mainpage m = new mainpage();
            m.Show();
        }
    }
    }
    



