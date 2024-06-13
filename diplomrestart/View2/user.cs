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

namespace diplomrestart.Model
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From users where username like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvLogin);
            lb.Items.Add(dgvPass);
            lb.Items.Add(dgvFIO);
            lb.Items.Add(dgvPhone);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            userAdd frm = new userAdd();
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


                userAdd frm = new userAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtPass.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPass"].Value);
                frm.txtFIO.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvFIO"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.txtLogin.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvLogin"].Value);
                frm.ShowDialog();
                GetData();

            }


            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {



                DialogResult dialogResult = MessageBox.Show("Вы хотите удалить данные", "Нет", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from users where UserID= " + id + "";
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

