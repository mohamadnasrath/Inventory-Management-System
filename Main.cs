using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nventory_Management_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panelmain_Paint(object sender, PaintEventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            PanalMain.Controls.Add(childForm);
            PanalMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new Users());
        }

        private void PanalMain_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new Customer());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new Category());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new Product());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new Order());
        }

        private void lablogout_Click(object sender, EventArgs e)
        {   
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            
        }

        private void labhome_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
