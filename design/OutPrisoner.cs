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
    
    public partial class OutPrisoner : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        int UPID;
        int PID;
   
        public OutPrisoner()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            txtuotdate.Text = "";
            cbprisoner.Text = "";
            PID.Equals("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(PID.Equals("") && txtuotdate.Text == "") {

                    MessageBox.Show("Feilds are Requiared");
                }
                else
                {
                    
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "INSERT INTO tbl_OutPrisoner ([PrisonerID],[OutDate]) VALUES(" + PID + ",'" + txtuotdate.Value.Date + "')";
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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tblOutPrisonerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
          

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do You Want to update this prisoner", "Update Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE tbl_OutPrisoner SET PrisonerID="+PID+",OutDate='"+txtuotdate.Text+"' where UPID="+UPID+"";
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

        public void GetData()
        {
            try
            {
                button2.Enabled = false;
                button3.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT UPID,tbl_OutPrisoner.PrisonerID,PrisonerName,CONVERT(varchar,OutDate, 111) 'OutDate' from tbl_OutPrisoner join tbl_Prisoner on tbl_Prisoner.PrisonerID = tbl_OutPrisoner.PrisonerID";
                SqlCommand cmd = new SqlCommand(stmt, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                lvoutprisoner.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["UPID"].ToString());
                    lv.SubItems.Add(rd["PrisonerID"].ToString());
                    lv.SubItems.Add(rd["PrisonerName"].ToString());
                    lv.SubItems.Add(rd["OutDate"].ToString());

                    lvoutprisoner.Items.Add(lv);
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

        private void lstoutpre_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = true;
                UPID = int.Parse(lvoutprisoner.SelectedItems[0].SubItems[0].Text);
                PID = int.Parse(lvoutprisoner.SelectedItems[0].SubItems[1].Text);
                cbprisoner.Text = (lvoutprisoner.SelectedItems[0].SubItems[2].Text.ToString());
                txtuotdate.Text = (lvoutprisoner.SelectedItems[0].SubItems[3].Text.ToString());

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OutPrisoner_Load(object sender, EventArgs e)
        {
            GetData();
            LoadPrisoner();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                        PID =int.Parse(dr["PrisonerID"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvoutprisoner_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Enabled = true;
                UPID = int.Parse(lvoutprisoner.SelectedItems[0].SubItems[0].Text);
         
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want to Delete  this prisoner", "Delete Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM [dbo].[tbl_OutPrisoner] WHERE UPID =" + UPID + "";
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
    }
}
