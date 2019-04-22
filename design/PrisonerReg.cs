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
    public partial class PrisonerReg : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True"); // making connection   
        SqlCommand cmd;
        int PID;
        public PrisonerReg()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            txtindate.Text = "";
            txtpage.Text = "";
            txtpname.Text = "";
            txtheight.Text = "";
            txtcrimetype.Text = "";
            txtpmname.Text = "";
            txtpname.Text = "";
            txtindate.Text = "";
            txtcompname.Text = "";
            txtcolor.Text = "";

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainpage mm = new mainpage();
            mm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (  txtpname.Text != "" && txtpage.Text != "" && txtpmname.Text != "" && txtindate.Text != "" && txtheight.Text != "" && txtcrimetype.Text != "" && txtcolor.Text != "")
                {

                    cmd = new SqlCommand("insert into tbl_Prisoner(PrisonerName,PrisonerAge,MotherName,Color,Height,CrimeType,ComplaintName,InDate) values('" + txtpname.Text + "'," + txtpage.Text + ",'" + txtpmname.Text + "','" + txtcolor.Text + "'," + txtheight.Text + ",'" + txtcrimetype.Text + "','" + txtcompname.Text + "','" + txtindate.Value.Date + "')", con);
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
        public void Getdata()
        {
            try
            {
                button2.Enabled = false;
                button3.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT * FROM tbl_Prisoner order by PrisonerID ASC";
                SqlCommand cmd = new SqlCommand(stmt, con);

                con.Open();



                SqlDataReader rd = cmd.ExecuteReader();
                lvprisoner.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["PrisonerID"].ToString());
                    lv.SubItems.Add(rd["PrisonerName"].ToString());
                    lv.SubItems.Add(rd["PrisonerAge"].ToString());
                    lv.SubItems.Add(rd["MotherName"].ToString());
                    lv.SubItems.Add(rd["Color"].ToString());
                    lv.SubItems.Add(rd["Height"].ToString());
                    lv.SubItems.Add(rd["CrimeType"].ToString());
                    lv.SubItems.Add(rd["ComplaintName"].ToString());
                    lv.SubItems.Add(rd["InDate"].ToString());






                    lvprisoner.Items.Add(lv);
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

        private void PrisonerReg_Load(object sender, EventArgs e)
        {
            Getdata();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtpage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void lstpre_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = true;
                PID =int.Parse( lvprisoner.SelectedItems[0].SubItems[0].Text);
                txtpname.Text = (lvprisoner.SelectedItems[0].SubItems[1].Text.ToString());
                txtpage.Text = lvprisoner.SelectedItems[0].SubItems[2].Text;
                txtpmname.Text = lvprisoner.SelectedItems[0].SubItems[3].Text;
                txtcolor.Text = lvprisoner.SelectedItems[0].SubItems[4].Text;
                txtheight.Text = (lvprisoner.SelectedItems[0].SubItems[5].Text.ToString());
                txtcrimetype.Text = (lvprisoner.SelectedItems[0].SubItems[6].Text.ToString());
                txtcompname.Text = (lvprisoner.SelectedItems[0].SubItems[7].Text.ToString());
                txtindate.Text = (lvprisoner.SelectedItems[0].SubItems[8].Text.ToString());


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
                if (MessageBox.Show("Do You Want to update this Prisoner", "Update Prisoner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {



                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE tbl_Prisoner SET PrisonerName='" + txtpname.Text + "',PrisonerAge=" + txtpage.Text + ",MotherName='" + txtpmname.Text + "',Color='" + txtcolor.Text + "',Height='" + txtheight.Text + "',CrimeType='" + txtcrimetype.Text + "',ComplaintName='" + txtcompname.Text + "',InDate='" + txtindate.Value.Date + "' where PrisonerID =" + PID + "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();
                    Getdata();
                    Clear();
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
            try
            {
                if (MessageBox.Show("Do You Want to Delete this Prisoner", "Delete This Prisoner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM tbl_Prisoner where PrisonerID='" + PID + "'";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();

                    //notify success message
                    Getdata();
                    Clear();
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

        private void lstpre_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Enabled = true;
                PID = int.Parse(lvprisoner.SelectedItems[0].SubItems[0].Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lvprisoner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtserach_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                button2.Enabled = false;
                button3.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT *FROM tbl_Prisoner  where PrisonerName like('%"+txtserach.Text.Trim()+"%') ";
                SqlCommand cmd = new SqlCommand(stmt, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                lvprisoner.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["PrisonerID"].ToString());
                    lv.SubItems.Add(rd["PrisonerName"].ToString());
                    lv.SubItems.Add(rd["PrisonerAge"].ToString());
                    lv.SubItems.Add(rd["MotherName"].ToString());
                    lv.SubItems.Add(rd["Color"].ToString());
                    lv.SubItems.Add(rd["Height"].ToString());
                    lv.SubItems.Add(rd["CrimeType"].ToString());
                    lv.SubItems.Add(rd["ComplaintName"].ToString());
                    lv.SubItems.Add(rd["InDate"].ToString());
                    lvprisoner.Items.Add(lv);
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
    }
}