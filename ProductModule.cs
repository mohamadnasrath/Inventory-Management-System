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
    public partial class ProductModule : Form
    {
        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModule()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            txtprocat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtprocat.Items.Add(dr[0].ToString());
            }
            
            dr.Close();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                if(txtproname.Text=="")
                {
                    MessageBox.Show("Pleas enter product name", "Error");
                    return;
                }
                if (txtproprice.Text == "")
                {
                    MessageBox.Show("Pleas enter product price", "Error");
                    return;
                }
                if (txtproqty.Text == "")
                {
                    MessageBox.Show("Pleas enter product quantity", "Error");
                    return;
                }
                if (txtprocat.Text == "")
                {
                    MessageBox.Show("Pleas select product Category", "Error");
                    return;
                }

                if (MessageBox.Show("Are tou want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbproduct(proname, proqty, proprice, prodes, procat )VALUES(@proname, @proqty, @proprice, @prodes, @procat)", con);
                    cm.Parameters.AddWithValue("@proname", txtproname.Text);
                    cm.Parameters.AddWithValue("@proqty",Convert.ToInt64(txtproqty.Text));
                    cm.Parameters.AddWithValue("@proprice", Convert.ToInt64(txtproprice.Text));
                    cm.Parameters.AddWithValue("@prodes", txtprodes.Text);
                    cm.Parameters.AddWithValue("@procat", txtprocat.Text);
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

        public void Clear()
        {
            txtproname.Clear();
            txtproqty.Clear();
            txtproprice.Clear();
            txtprodes.Clear();
            txtprocat.Text = "";
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are tou want to update this Product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbproduct SET proname=@proname, proqty=@proqty, proprice=@proprice, Prodes=@prodes, procat=@procat WHERE pid LIKE '" + labproid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@proname", txtproname.Text);
                    cm.Parameters.AddWithValue("@proqty", Convert.ToInt32 (txtproqty.Text));
                    cm.Parameters.AddWithValue("@proprice", Convert.ToInt32( txtproprice.Text));
                    cm.Parameters.AddWithValue("@prodes", txtprodes.Text);
                    cm.Parameters.AddWithValue("@procat", txtprocat.Text);
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
    }
}
