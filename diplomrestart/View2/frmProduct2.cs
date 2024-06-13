using diplomrestart.Model;
using diplomrestart.View;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomrestart.View2
{
    public partial class frmProduct2 : Form
    {
        public frmProduct2()
        {
            InitializeComponent();
        }

        private void frmProvider2_Load(object sender, EventArgs e)
        {

            GetData();
        }
        public void GetData()
        {
            string qry = "select pid,pname,c.tname ,pcost,post from Product p inner join provider c on c.tid = p.pprovider where pname like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvProvider);
            lb.Items.Add(dgvCost);
            lb.Items.Add(dgvost);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd();
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


                frmProductAdd frm = new frmProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                //frm.cbProvider.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvProvider"].Value);
                //frm.cbProvider.SelectedIndex = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvProvider"].Value);
                frm.txtCost.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvCost"].Value);
                frm.txtost.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvost"].Value);
                frm.ShowDialog();
                GetData();

            }


            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {





                DialogResult dialogResult = MessageBox.Show("Вы хотите удалить данные", "Нет", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                       
                        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry = "Delete from Product where pid= " + id + "";
                        Hashtable ht = new Hashtable();
                        MainClass.SQL(qry, ht);
                        MessageBox.Show("Удаление выполнено");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                    }
             
                    GetData();
                
            }
        }
    }
}
