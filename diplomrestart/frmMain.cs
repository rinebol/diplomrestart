﻿using diplomrestart.Model;
using diplomrestart.View;
using diplomrestart.View2;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomrestart
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
           
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView2());
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            AddControls(new frmProvider2());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddControls(new frmStatusOrder());
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
           


        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            AddControls(new frmOrder2());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddControls(new user());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}
