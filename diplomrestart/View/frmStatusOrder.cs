using diplomrestart.Model;
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

        private void frmStatusOrder_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            //string qry = "Select oid, p.pname,c.tname,ocount,SUM(ocount*p.pcost),oactive,odate from OrderP o inner join Product p on p.pid = o.oprovider inner join provider c on c.tid = p.pprovider where oname like '%" + txtSearch.Text + "%' GROUP BY oactive,ocount,p.pcost,oid, p.pname,c.tname,odate";
            string qry = "Select oid, oprovider,  oname, osklad, ocount, ocost, odate from OrderP where oname like '%" + txtSearch.Text + "%' GROUP BY ocount,ocost,oid,oprovider,oname,odate,osklad";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvProvider);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvCount);
            lb.Items.Add(dgvSklad);

            lb.Items.Add(dgvCost);



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
                frm.cbActive.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvActive"].Value);
                frm.ShowDialog();
                GetData();

            }


            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Вы уверены что хотите удалить данные?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from OrderP where oid= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);


                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Удаление выполнено");
                    GetData();
                }
            }
        }
    }
}
