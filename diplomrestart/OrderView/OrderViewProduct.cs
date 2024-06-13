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

namespace diplomrestart.OrderView
{
    public partial class OrderViewProduct : Form
    {
        public OrderViewProduct()
        {
            InitializeComponent();
        }

        private void OrderViewProduct_Load(object sender, EventArgs e)
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
  

   

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            GetData();
        }

        

      
    }
}
