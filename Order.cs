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
    public partial class Order : Form
    {


        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public Order()
        {
            InitializeComponent();
            LoadOrder();
        }


        public void LoadOrder()
        {
            int i = 0;
            dgorder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.proname, O.cid, C.cname, qty, price, total FROM tborder AS O JOIN tbcustomer AS C ON O.cid=C.cid JOIN tbproduct AS P ON O.pid=P.pid  WHERE CONCAT(orderid, odate, O.pid, P.proname, O.cid, C.cname, qty, price) LIKE '%"+txtsearch.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgorder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OrderModule OrderModule = new OrderModule();
            OrderModule.btnSave.Enabled = true;
            OrderModule.ShowDialog();
            LoadOrder();
        }

        private void dgorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgorder.Columns[e.ColumnIndex].Name;


            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Order?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tborder WHERE orderid LIKE '" + dgorder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been successfully deleted");


                    cm = new SqlCommand("UPDATE tbproduct SET proqty = (proqty+@proqty) WHERE pid LIKE '" + dgorder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@proqty", Convert.ToInt32(dgorder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadOrder();


        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
