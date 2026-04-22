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
    public partial class Customer : Form
    {


        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Customer()
        {
            InitializeComponent();
            LoadCustomer();
        }


        public void LoadCustomer()
        {
            int i = 0;
            dgcustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbcustomer WHERE CONCAT(cid, cname, cphone, cemail) LIKE'%"+ txtcsearch.Text +"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgcustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CustomerModule CustomerModule = new CustomerModule();
            CustomerModule.btnSave.Enabled = true;
            CustomerModule.btnUpdate.Enabled = false; 
            CustomerModule.ShowDialog();
            LoadCustomer();
        }

        private void dgcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgcustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CustomerModule CustomerModule = new CustomerModule();
                CustomerModule.labcid.Text = dgcustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                CustomerModule.txtCname.Text = dgcustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                CustomerModule.txtCphone.Text = dgcustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                CustomerModule.txtCemail.Text = dgcustomer.Rows[e.RowIndex].Cells[4].Value.ToString();


                CustomerModule.btnSave.Enabled = false;
                CustomerModule.btnUpdate.Enabled = true;
                CustomerModule.ShowDialog();
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Customer?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbcustomer WHERE cid LIKE '" + dgcustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted");
                }
            }
            LoadCustomer();


        }

        private void txtcsearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
