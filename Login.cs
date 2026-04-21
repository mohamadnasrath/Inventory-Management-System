using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace nventory_Management_System
{
    public partial class Login : Form
    {

        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Exit Application","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void checkBoxpass_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxpass.Checked ==false )
            {
                txtpass.UseSystemPasswordChar = true;
            }

            else
            {
                txtpass.UseSystemPasswordChar= false;   
            }

        }

        private void lbclear_Click(object sender, EventArgs e)
        {
            txtuname.Clear();
            txtpass.Clear();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbuser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("username", txtuname.Text);
                cm.Parameters.AddWithValue ("password", txtpass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                if(dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["fullname"].ToString() + " |", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main main = new Main();
                    main.ShowDialog();
                    this.Close();

                }

                else
                {
                    MessageBox.Show("Invalid Username or Password", "Access Denited",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    con.Close();
                    return;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Forgotpassword fpass = new Forgotpassword();
            fpass.ShowDialog();
        }
    }
}
