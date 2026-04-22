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
    public partial class UserModule : Form
    {

        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        public UserModule()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UserModule_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUname.Text == "")
                {
                    MessageBox.Show("Pleas enter username", "Error");
                    return;
                }
                if (txtFname.Text == "")
                {
                    MessageBox.Show("Pleas enter user fullname", "Error");
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Pleas enter Password", "Error");
                    return;
                }

                if (txtrepass.Text == "")
                {
                    MessageBox.Show("Pleas reenter password", "Error");
                    return;
                }

                if (txtPass.Text != txtrepass.Text)
                {
                    MessageBox.Show("Pleas reenter the same password ", "Error");
                    return;
                }

                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Pleas enter user phone", "Error");
                    return;
                }

                if (txtemail.Text == "")
                {
                    MessageBox.Show("Pleas enter user email", "Error");
                    return;
                }



                if (MessageBox.Show("Are tou want to save this user?","Saving Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbuser(username,fullname,password,phone,email)VALUES(@username,@fullname,@password,@phone,@email)", con);
                    cm.Parameters.AddWithValue("@username", txtUname.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFname.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@email", txtemail.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been  successfully saved");
                    Clear();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtUname.Clear();
            txtFname.Clear();
            txtPass.Clear();
            txtPhone.Clear();
            txtemail.Clear();
            txtrepass.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            try
            {

                if (MessageBox.Show("Are tou want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbuser SET username=@username, fullname=@fullname, password=@password, phone=@phone, email=@email WHERE username LIKE '"+ txtUname.Text +"' ", con);
                    cm.Parameters.AddWithValue("@username", txtUname.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFname.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@email", txtemail.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been  successfully updated");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
