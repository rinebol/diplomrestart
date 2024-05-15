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
using System.Xml.Linq;

namespace diplomrestart.Model
{
    public partial class frmProviderAdd : SampleAdd
    {
        public frmProviderAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtAdress.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                string qry = "";
                if (id == 0)
                {
                    qry = "Insert into provider Values(@Name,@Adress)";

                }
                else
                {
                    qry = "Update provider Set tname = @Name, tadress = @Adress where tid = @id ";
                }
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@Adress", txtAdress.Text);

                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Saved successfully..");
                    id = 0;
                    //txtName.Text = "";
                    //txtAdress.Text = "";
                    //txtName.Focus();
                }
            }
        }
    }
}
