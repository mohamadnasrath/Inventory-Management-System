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
    public partial class CustomerModule : Form
    {


        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        public CustomerModule()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCname.Text == "")
                {
                    MessageBox.Show("Pleas enter Cusotomer name", "Error");
                    return;
                }
                if (txtCphone.Text == "")
                {
                    MessageBox.Show("Pleas enter customer Phone", "Error");
                    return;
                }


                if (MessageBox.Show("Are tou want to save this customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbcustomer(cname,cphone,cemail)VALUES(@cname,@cphone,@cemail)", con);
                    cm.Parameters.AddWithValue("@cname", txtCname.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCphone.Text);
                    cm.Parameters.AddWithValue("@cemail", txtCemail.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been  successfully saved");
                    Clear();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void Clear()
        {
            txtCemail.Clear();
            txtCname.Clear();
            txtCphone.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are tou want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbcustomer SET cname=@cname, cphone=@cphone, cemail=@cemail WHERE cid LIKE '" + labcid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@cphone", txtCphone.Text);
                    cm.Parameters.AddWithValue("@cname", txtCname.Text);
                    cm.Parameters.AddWithValue("@cemail", txtCemail.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been  successfully updated");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            

            try
            {

                if (MessageBox.Show("Are tou want to update this customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbcustomer SET cname=@cname, cphone=@cphone, cemail=@cemail WHERE cid LIKE '" + labcid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@cname", txtCname.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCphone.Text);
                    cm.Parameters.AddWithValue("@cemail", txtCemail.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been  successfully updated");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
