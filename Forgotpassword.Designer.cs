namespace nventory_Management_System
{
    partial class Forgotpassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btngpass = new System.Windows.Forms.Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.labpass = new System.Windows.Forms.Label();
            this.txtfemail = new System.Windows.Forms.TextBox();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btngetumane = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 60);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forgot Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(342, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Login";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btngpass
            // 
            this.btngpass.BackColor = System.Drawing.Color.DodgerBlue;
            this.btngpass.FlatAppearance.BorderSize = 0;
            this.btngpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngpass.Location = new System.Drawing.Point(98, 291);
            this.btngpass.Name = "btngpass";
            this.btngpass.Size = new System.Drawing.Size(215, 42);
            this.btngpass.TabIndex = 4;
            this.btngpass.Text = "Get Password";
            this.btngpass.UseVisualStyleBackColor = false;
            this.btngpass.Click += new System.EventHandler(this.btngpass_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 23;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 23;
            this.guna2Elipse2.TargetControl = this.btngpass;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // labpass
            // 
            this.labpass.AutoSize = true;
            this.labpass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labpass.ForeColor = System.Drawing.Color.Red;
            this.labpass.Location = new System.Drawing.Point(113, 221);
            this.labpass.Name = "labpass";
            this.labpass.Size = new System.Drawing.Size(0, 18);
            this.labpass.TabIndex = 5;
            // 
            // txtfemail
            // 
            this.txtfemail.Location = new System.Drawing.Point(116, 134);
            this.txtfemail.Name = "txtfemail";
            this.txtfemail.Size = new System.Drawing.Size(254, 27);
            this.txtfemail.TabIndex = 6;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 23;
            this.guna2Elipse3.TargetControl = this.btngetumane;
            // 
            // btngetumane
            // 
            this.btngetumane.BackColor = System.Drawing.Color.DodgerBlue;
            this.btngetumane.FlatAppearance.BorderSize = 0;
            this.btngetumane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngetumane.Location = new System.Drawing.Point(98, 358);
            this.btngetumane.Name = "btngetumane";
            this.btngetumane.Size = new System.Drawing.Size(215, 42);
            this.btngetumane.TabIndex = 7;
            this.btngetumane.Text = "Get Username";
            this.btngetumane.UseVisualStyleBackColor = false;
            this.btngetumane.Click += new System.EventHandler(this.btngetumane_Click);
            // 
            // Forgotpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 500);
            this.Controls.Add(this.btngetumane);
            this.Controls.Add(this.txtfemail);
            this.Controls.Add(this.labpass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btngpass);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Forgotpassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgotpassword";
            this.Load += new System.EventHandler(this.Forgotpassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btngpass;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.TextBox txtfemail;
        private System.Windows.Forms.Label labpass;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.Button btngetumane;
    }
}