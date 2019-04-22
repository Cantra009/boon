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
    public partial class FIR : UserControl

    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        SqlCommand cmd;
        int FID;
        public FIR()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvFir_Click(object sender, EventArgs e)
        {
            try
            {
                FID = int.Parse(lvFir.SelectedItems[0].SubItems[0].Text);
                btndelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lvFir_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                FID = int.Parse(lvFir.SelectedItems[0].SubItems[0].Text);
                txtcrimetype.Text = lvFir.SelectedItems[0].SubItems[2].Text;
                txtfullname.Text = lvFir.SelectedItems[0].SubItems[3].Text;
               txtdistnict.Text = lvFir.SelectedItems[0].SubItems[4].Text;
                dtpofaccident.Text = lvFir.SelectedItems[0].SubItems[5].Text;
                txtplace.Text = lvFir.SelectedItems[0].SubItems[6].Text;
                
                txtdetail.Text = lvFir.SelectedItems[0].SubItems[7].Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FIR_Load(object sender, EventArgs e)
        {
            Clear();
            Getdata();
        }

        public void Getdata()
        {
            try
            {
                //step 2: prepare stmt and cmd
                string stmt = "SELECT * FROM tbl_FIR order by ID DESC";
                cmd = new SqlCommand(stmt, con);

                con.Open();



                SqlDataReader rd = cmd.ExecuteReader();
                lvFir.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem lv = new ListViewItem(rd["ID"].ToString());
                    lv.SubItems.Add(rd["CrimeType"].ToString());
                    lv.SubItems.Add(rd["FullName"].ToString());
                    lv.SubItems.Add(rd["Distnict"].ToString());
                    lv.SubItems.Add(rd["TimeOfAccident"].ToString());
                    lv.SubItems.Add(rd["PlaceOfAccident"].ToString());
                    lv.SubItems.Add(rd["DetailsOfAccident"].ToString());
                    lvFir.Items.Add(lv);
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
            txtcrimetype.Text = "";
            txtdetail.Text = "";
            txtdistnict.Text = "";
            txtfullname.Text = "";
            txtplace.Text = "";
            dtpofaccident.Text = "";

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            mainpage m = new mainpage();
            m.Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtplace.Text != "" && txtfullname.Text != ""  && txtdistnict.Text != "" && txtcrimetype.Text != "" )
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[tbl_FIR] ([CrimeType],[FullName],[Distnict],[TimeOfAccident],[PlaceOfAccident],[DetailsOfAccident])  VALUES('"+txtcrimetype.Text+"','"+txtfullname.Text+"','"+txtdistnict.Text+"','"+dtpofaccident.Text+"','"+txtplace.Text+"','"+txtdetail.Text+"')", con);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Do You Want to Delete this FIR", "Delete This FIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "DELETE FROM tbl_FIR where ID='" + FID + "'";
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want to update this FIR", "Update FIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    //step 2: prepare the sql stmt and make sqlcommand obj
                    string stmt = "UPDATE[dbo].[tbl_FIR]SET [CrimeType] ='" + txtcrimetype.Text+"',[FullName] ='" + txtfullname.Text+"',[Distnict] ='" + txtdistnict.Text+"',[TimeOfAccident] ='" + dtpofaccident.Text+"',[PlaceOfAccident] ='" + txtplace.Text+"' ,[DetailsOfAccident] ='" + txtdetail.Text+"' WHERE ID=" + FID + "";
                    cmd = new SqlCommand(stmt, con);

                    //step 3: open the connection obj
                    con.Open();

                    //Step 4: execute the command
                    cmd.ExecuteNonQuery();

                    // step 5: close the connection
                    con.Close();
                    Clear();
                    Getdata();
                    FID.Equals("");

                    // notify success message
                    MessageBox.Show("Data Updated Success Fully");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
