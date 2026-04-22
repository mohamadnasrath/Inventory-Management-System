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
    public partial class Category : Form
    {

        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Category()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 0;
            dgcategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbcategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgcategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            CategoryModule CategoryModule = new CategoryModule();
            CategoryModule.btnSave.Enabled = true;
            CategoryModule.btnUpdate.Enabled = false;
            CategoryModule.ShowDialog();
            LoadCategory();
        }

        private void dgcategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgcategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryModule CategoryModule = new CategoryModule();
                CategoryModule.labcatid.Text = dgcategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                CategoryModule.txtCatname.Text = dgcategory.Rows[e.RowIndex].Cells[2].Value.ToString();


                CategoryModule.btnSave.Enabled = false;
                CategoryModule.btnUpdate.Enabled = true;
                CategoryModule.ShowDialog();
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Category?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbcategory WHERE catid LIKE '" + dgcategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted");
                }
            }
            LoadCategory();
        }
    }
}
