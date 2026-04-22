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
    public partial class Product : Form
    {
        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Product()
        {
            InitializeComponent();
            LoadProduct();
        }


        public void LoadProduct()
        {
            int i = 0;
            dgproduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbproduct WHERE CONCAT(proname, proprice, prodes, procat) LIKE'%"+ txtsearch.Text +"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgproduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductModule ProductModule = new ProductModule();
            ProductModule.btnSave.Enabled = true;
            ProductModule.btnUpdate.Enabled = false;
            ProductModule.ShowDialog();
            LoadProduct();
        }

        private void dgproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgproduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule ProductModule = new ProductModule();
                ProductModule.labproid.Text = dgproduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                ProductModule.txtproname.Text = dgproduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                ProductModule.txtproqty.Text = dgproduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                ProductModule.txtproprice.Text = dgproduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                ProductModule.txtprodes.Text = dgproduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                ProductModule.txtprocat.Text = dgproduct.Rows[e.RowIndex].Cells[6].Value.ToString();



                ProductModule.btnSave.Enabled = false;
                ProductModule.btnUpdate.Enabled = true;
                ProductModule.ShowDialog();
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbproduct WHERE pid LIKE '" + dgproduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted");
                }
            }
            LoadProduct();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
