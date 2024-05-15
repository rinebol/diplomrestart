using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace diplomrestart.Model
{
    public partial class userAdd : SampleAdd
    {
        public userAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;

        private void userAdd_Load(object sender, EventArgs e)
        {

        }
        public override void btnSave_Click(object sender, EventArgs e)
        {

            if (txtLogin.Text == "" || txtPass.Text == "" || txtFIO.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                if (int.TryParse(txtPhone.Text, out int number))
                {
                    string qry = "";
                    if (id == 0)
                    {
                        qry = "Insert into users Values(@Login,@Pass,@FIO,@Phone)";

                    }
                    else
                    {
                        qry = "Update users Set username = @Login, upass = @Pass, uName = @FIO, uphone = @Phone where userID = @id ";
                    }
                    Hashtable ht = new Hashtable();
                    ht.Add("@id", id);
                    ht.Add("@Login", txtLogin.Text);
                    ht.Add("@Pass", txtPass.Text);
                    ht.Add("@FIO", txtFIO.Text);
                    ht.Add("@Phone", txtPhone.Text);

                    if (MainClass.SQL(qry, ht) > 0)
                    {
                        MessageBox.Show("Saved successfully..");
                        id = 0;
                        //txtName.Text = "";
                        //txtCost.Text = "";
                        //cbProvider.SelectedIndex = -1;
                        //txtName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Не верно заполнено поле: Телефон");
                }
            }
        }
    }
}
