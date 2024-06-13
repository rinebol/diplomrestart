using diplomrestart.Model;
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
    public partial class frmProvider2 : Form
    {
        public frmProvider2()
        {
            InitializeComponent();
        }

        private void frmProvider2_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From provider where tname like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvAdress);
            lb.Items.Add(dgvPhone);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProviderAdd frm = new frmProviderAdd();
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


                frmProviderAdd frm = new frmProviderAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtAdress.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvAdress"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.ShowDialog();
                GetData();

            }


            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {


                DialogResult dialogResult = MessageBox.Show("Вы хотите удалить данные", "Нет", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                                string qry = "Delete from provider where tid= " + id + "";
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
