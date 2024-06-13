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

            if (txtName.Text == "" || txtCost.Text == "" || cbProvider.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                if (int.TryParse(txtCost.Text, out int number))
                {
                    string qry = "";
                    if (id == 0)
                    {
                        qry = "Insert into Product Values(@Name,@Provider,@Cost,@Ost)";

                    }
                    else
                    {
                        qry = "Update Product Set pname = @Name, pprovider = @Provider, post = @Ost, pcost = @Cost where pid = @id ";
                    }
                    Hashtable ht = new Hashtable();
                    ht.Add("@id", id);
                    ht.Add("@Name", txtName.Text);
                    ht.Add("@Provider", Convert.ToInt32(cbProvider.SelectedValue));
                    ht.Add("@Cost", txtCost.Text);
                    ht.Add("@Ost", Convert.ToInt32(txtost.Text));

                    if (MainClass.SQL(qry, ht) > 0)
                    {
                        MessageBox.Show("Сохранение выполнено успешно");
                        id = 0;
                        txtName.Text = "";
                        txtCost.Text = "";
                        txtost.Text = "";
                        cbProvider.SelectedIndex = -1;
                        txtName.Focus();
                    }

        }
                else
                {
                    MessageBox.Show("Не верно заполнено поле: Цена");
                }
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

        private void cbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

            //frmProductAdd frm = new frmProductAdd();
            //frmProduct2 frm2 = new frmProduct2();
            //frm2.GetData();
            //frm.cbProvider.SelectedIndex = Convert.ToInt32(frm2.guna2DataGridView1.CurrentRow.Cells["dgvProvider"].Value);
            //cbProvider.SelectedIndex = 2;
        }

    }
}
