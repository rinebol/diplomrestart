﻿using diplomrestart.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomrestart.View2
{
    public partial class frmCategoryView2 : Form
    {
        public frmCategoryView2()
        {
            InitializeComponent();
        }

     

        private void frmCategoryView2_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From category where catName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                {


                    frmCategoryAdd frm = new frmCategoryAdd();
                    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                    frm.ShowDialog();
                    GetData();

                }


                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
                {
            
                        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry = "Delete from category where catID= " + id + "";
                        Hashtable ht = new Hashtable();
                        MainClass.SQL(qry, ht);

                        MessageBox.Show("Удаление выполнено");
                        GetData();
                    
                }
            
        }
    }
}
