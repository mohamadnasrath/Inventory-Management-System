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
using static System.Net.Mime.MediaTypeNames;

namespace nventory_Management_System
{
    public partial class Users : Form
    {

        SqlConnection con = new SqlConnection(@"Server=db48793.public.databaseasp.net; Database=db48793; User Id=db48793; Password=Lw8#5-xP=pQ2; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private object text;

        public Users()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dguser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbuser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dguser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()); 
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserModule userModule = new UserModule();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void dguser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dguser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModule userModule = new UserModule();
                userModule.txtUname.Text = dguser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFname.Text = dguser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPass.Text = dguser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dguser.Rows[e.RowIndex].Cells[4].Value.ToString();
                userModule.txtemail.Text = dguser.Rows[e.RowIndex].Cells[5].Value.ToString();

                userModule.btnSave.Enabled=false;
                userModule.btnUpdate.Enabled=true;
                userModule.txtUname.Enabled=false;
                userModule.ShowDialog();
            }
            
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?","Delete record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbuser WHERE username LIKE '"+ dguser.Rows[e.RowIndex].Cells[1].Value.ToString() +"'",con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted");
                }
            }
            LoadUser();

        }
    }
}
