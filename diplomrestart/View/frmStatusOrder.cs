using diplomrestart.Model;
using diplomrestart.View2;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace diplomrestart.View
{
    public partial class frmStatusOrder : Form
    {
        public frmStatusOrder()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void frmStatusOrder_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            //string qry = "Select oid, p.pname,c.tname,ocount,SUM(ocount*p.pcost),oactive,odate from OrderP o inner join Product p on p.pid = o.oprovider inner join provider c on c.tid = p.pprovider where oname like '%" + txtSearch.Text + "%' GROUP BY oactive,ocount,p.pcost,oid, p.pname,c.tname,odate";
            string qry = "Select oid, oprovider,  oname,ocount,osklad ,odate , ocost  from OrderP where oname like '%" + txtSearch.Text + "%' GROUP BY ocount,ocost,oid,oprovider,oname,odate,osklad";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvProvider);
            lb.Items.Add(dgvCount);
            lb.Items.Add(dgvSklad);
           
            lb.Items.Add(dgvCost);
            lb.Items.Add(dgvDate);


            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {


                frmStatusOrderAdd frm = new frmStatusOrderAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.cbProduct.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.cbSklad.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvSklad"].Value);
                frm.txtCount.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvCount"].Value);
                frm.cdNameP.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvProvider"].Value);
                frm.cbCost.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvCost"].Value);
                frm.ShowDialog();
                GetData();

            }
            /////В процесе 
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "ok")
            {




               
                frmProduct2 frm2 = new frmProduct2();
                frm2.GetData();
                frmProductAdd frm = new frmProductAdd();
               

                frm2.GetData();
                int i = 0;
                for (int one = 1; one == 1; i++)
                {

                    if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value) == Convert.ToString(frm2.guna2DataGridView1.Rows[i].Cells["dgvName"].Value))
                    {
                        //frm.txtost.Text = Convert.ToString(frm2.guna2DataGridView1.CurrentRow.Cells["dgvost"].Value);
                        //frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvCount"].Value);
                          

                        frm.id = Convert.ToInt32(frm2.guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        frm.txtName.Text = Convert.ToString(frm2.guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                        frm.txtCost.Text = Convert.ToString(frm2.guna2DataGridView1.Rows[i].Cells["dgvCost"].Value);
                        frm.txtost.Text = Convert.ToString(frm2.guna2DataGridView1.CurrentRow.Cells["dgvost"].Value);
               
                        int a = Convert.ToInt32(frm2.guna2DataGridView1.CurrentRow.Cells["dgvost"].Value);
                        int b = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvCount"].Value);
                        int c = a + b;
                        frm.txtost.Text = Convert.ToString(c);
                        one = 0;
                    }
                    else
                    {

                    }
                }





                frm.ShowDialog();
                GetData();

            }

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {


                DialogResult dialogResult = MessageBox.Show("Вы хотите удалить данные", "Нет", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry = "Delete from OrderP where oid= " + id + "";
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
