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

namespace nventory_Management_System
{
    public partial class Forgotpassword : Form
    {
        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Forgotpassword()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btngpass_Click(object sender, EventArgs e)
        {
            cm = new SqlCommand("SELECT * FROM tbuser WHERE email='"+txtfemail.Text+"'", con);
            con.Open();
            dr = cm.ExecuteReader();
            if(dr.Read())
            {
                labpass.Text = "Your password is: " + dr.GetValue(2).ToString();
                con.Close();
                return;
            }
            else
            {
                MessageBox.Show("Invalid Email");
                con.Close();
                return;
            }
            
            

        }

        private void Forgotpassword_Load(object sender, EventArgs e)
        {

        }

        private void btngetumane_Click(object sender, EventArgs e)
        {
            cm = new SqlCommand("SELECT * FROM tbuser WHERE email='" + txtfemail.Text + "'", con);
            con.Open();
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                labpass.Text = "Your Userame is: " + dr.GetValue(0).ToString();
                con.Close();
                return;
            }
            else
            {
                MessageBox.Show("Invalid Email");
                con.Close();
                return;
            }
        }
    }
}
