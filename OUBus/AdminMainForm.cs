﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUBus
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to exit", "Configuration Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure want to Sign out", "Configuration Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check==DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;
        }
    }
}
