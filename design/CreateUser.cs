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
    public partial class CreateUser : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        SqlCommand cmd;
        int UID;
        public CreateUser()
        {
            InitializeComponent();
        }



        private void Clear()
        {
            txtusername.Text = "";
            txtrole.Text = "";
            txtpassword.Text = "";

        }


        public void Getdata()
        {
            try
            {
                btndelete.Enabled = false;
                btnudpate.Enabled = false;
                //step 2: prepare stmt and cmd
                string stmt = "SELECT * FROM tbl_Users order by UserID DESC";
                cmd = new SqlCommand(stmt, con);

                con.Open();



                SqlDataReader rd = cmd.ExecuteReader();
                userlv.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["UserID"].ToString());
                    lv.SubItems.Add(rd["UserName"].ToString());
                    lv.SubItems.Add(rd["Role"].ToString());
                    lv.SubItems.Add(rd["Password"].ToString());
                    userlv.Items.Add(lv);
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
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Do You Want to Delete this User", "Delete This User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM tbl_Users where UserID='" + UID + "'";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    //step 5: close the connection
                    con.Close();

                    //notify success message
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpassword.Text != "" && txtrole.Text != "" && txtusername.Text != "")
                {
                        cmd = new SqlCommand("INSERT INTO [dbo].[tbl_Users]([UserName],[Password],[Role]) VALUES('" + txtusername.Text + "','" + txtpassword.Text + "','" + txtrole.Text + "')", con);
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

        private void btnudpate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want to update this User", "Update User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE tbl_Users SET UserName='" + txtusername.Text+ "',Password='" + txtpassword.Text + "',Role='" + txtrole.Text + "' where UserID=" + UID+ "";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                   // step 5: close the connection
                    con.Close();
                    Getdata();

                   // notify success message
                    MessageBox.Show("Data Updated Success Fully");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            mainpage m = new mainpage();
            m.Show();
        }

        private void userlv_Click(object sender, EventArgs e)
        {
            try
            {
                btndelete.Enabled = true;
                UID = int.Parse(userlv.SelectedItems[0].SubItems[0].Text);
                btndelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void userlv_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                btnudpate.Enabled = true;
                UID= int.Parse(userlv.SelectedItems[0].SubItems[0].Text);
                txtusername.Text = userlv.SelectedItems[0].SubItems[1].Text;
                txtrole.Text = userlv.SelectedItems[0].SubItems[2].Text;
                txtpassword.Text = userlv.SelectedItems[0].SubItems[3].Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            Getdata();
            Clear();
        }
    }
    }

