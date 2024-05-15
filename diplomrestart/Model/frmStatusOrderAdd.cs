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
    public partial class frmStatusOrderAdd : SampleAdd
    {
        public frmStatusOrderAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {

            string qry = "";
            if (id == 0)
            {
                qry = "Insert into OrderP Values(@Active)";

            }
            else
            {
                qry = "Update OrderP Set  oactive = @Active  where oid = @id ";
            }
            Hashtable ht = new Hashtable();
            string active = cbActive.Text;
            string date = DateTime.Now.ToString("DD/MM/yyyy");
            ht.Add("@id", id);
            //ht.Add("@Name", d);
            //ht.Add("@Name", this);
            ////ht.Add("@Provider", Convert.ToInt32(cbProduct.SelectedValue));
            //ht.Add("@Provider", this);
            //ht.Add("@Count", this);
            ht.Add("@Active", active);
            //ht.Add("@Date", this);
            //ht.Add("@Cost", this);




            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                //txtName.Text = "";
                //cbProvider.SelectedIndex = -1;
                //txtName.Focus();
            }

        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmStatusOrderAdd_Load(object sender, EventArgs e)
        {
            string active = cbActive.Text;
            txtC.Text = cbActive.Text;
        }
    }
}
