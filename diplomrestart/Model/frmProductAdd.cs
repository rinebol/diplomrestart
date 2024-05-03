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
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "Insert into Product Values(@Name,@Provider,@Cost)";

            }
            else
            {
                qry = "Update Product Set pname = @Name, pprovider = @Provider pcost = @Cost where pid = @id ";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Provider", Convert.ToInt32(cbProvider.SelectedValue));
            ht.Add("@Cost", txtCost.Text);


            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                txtName.Text = "";
                cbProvider.SelectedIndex = -1;
                txtName.Focus();
            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            string qry = "Select tid 'id' , tname 'name' from provider";
            MainClass.CBFill(qry, cbProvider);

            if (cID > 0)
            {
                cbProvider.SelectedValue = cID;
            }
        }
    }
}
