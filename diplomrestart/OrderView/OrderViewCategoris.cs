using System;
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
    public partial class OrderViewCategoris : Form
    {
        public OrderViewCategoris()
        {
            InitializeComponent();
        }

        private void OrderViewCategoris_Load(object sender, EventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
