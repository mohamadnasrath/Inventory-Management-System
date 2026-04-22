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
    public partial class OrderModule : Form
    {
        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public OrderModule()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OrderModule_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void LoadCustomer()
        {
            int i = 0;
            dgcustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cid,cname,cphone FROM tbcustomer WHERE CONCAT (cid, cname, cphone) LIKE '%"+txtsearchcust.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgcustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }


        public void LoadProduct()
        {
            int i = 0;
            dgproduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbproduct WHERE CONCAT(proname, proprice, prodes, procat) LIKE'%" + txtsearchprod.Text + "%'", con);
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

        private void txtsearchcust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtsearchprod_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        int qty = 0;


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if(Convert.ToInt32(numericUpDown1.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Value = numericUpDown1.Value - 1;
                return;
            }
            if (Convert.ToInt32(numericUpDown1.Value) > 0)
            {
                int total = Convert.ToInt32(txtopprice.Text) * Convert.ToInt32(numericUpDown1.Value);
                txttotal.Text = total.ToString();
            }
        }

        private void dgcustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtocid.Text = dgcustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
             txtocname.Text = dgcustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
             txtocphone.Text = dgcustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void dgproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtopid.Text = dgproduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtopname.Text = dgproduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtopprice.Text = dgproduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt32(dgproduct.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtocid.Text =="")
                {
                    MessageBox.Show("Please select customer","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtopid.Text == "")
                {
                    MessageBox.Show("Please select Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (MessageBox.Show("Are tou want to insert this Order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tborder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)", con);
                    cm.Parameters.AddWithValue("@odate",  dtporder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt64(txtopid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt64(txtocid.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt16(numericUpDown1.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt64(txtopprice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt64(txttotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been  successfully Insert");
                    


                    cm = new SqlCommand("UPDATE tbproduct SET proqty = (proqty-@proqty) WHERE pid LIKE '" + txtopid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@proqty", Convert.ToInt32(numericUpDown1.Value));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            
        }

        public void Clear()
        {
            txtocid.Clear();
            txtocname.Clear(); 
            txtocphone.Clear();

            txtopid.Clear();
            txtopname.Clear();
            txtopprice.Clear();
            
            txttotal.Clear();
            txtsearchcust.Clear();
            txtsearchprod.Clear();
            dtporder.Value = DateTime.Now;
            numericUpDown1.Value = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtacust_Click(object sender, EventArgs e)
        {
            CustomerModule CustomerModule = new CustomerModule();
            CustomerModule.btnSave.Enabled = true;
            CustomerModule.btnUpdate.Enabled = false;
            CustomerModule.ShowDialog();
            LoadCustomer();
        }
    }
}
