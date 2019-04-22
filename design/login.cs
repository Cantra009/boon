using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace design
{
    public partial class login : Form
    {
        //step 1: create connection obj
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-98CRERN\ENGKHALID;Initial Catalog=CrimeFile;Integrated Security=True");
        public login()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               if (txtuser.Text=="" || txtpss.Text=="")
                {
                    MessageBox.Show("Plese FIll The  Empty Fields");
                }
               else
                {
                    //get data
                    string uname = txtuser.Text;
                    string pass = txtpss.Text;



                    //step 2: prepare stmt and cmd
                    string stmt = "SELECT COUNT(*) from  tbl_Users where UserName='"+txtuser.Text+"' and Password='"+txtpss.Text+"'";
                    SqlCommand cmd = new SqlCommand(stmt, con);

                    //step3: open the con
                    con.Open();

                    // step 4: exec cmd
                    int x = (int)cmd.ExecuteScalar();
                    // step 5: close con
                    con.Close();


                    if (x == 1)
                    {
                        mainpage main = new mainpage();
                        this.Hide();
                        main.Show();



                    }
                    else if (x == 0)
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
