﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace diplomrestart.View
{
    public partial class frmOrder : SampleView
    {
        public frmOrder()
        {
            InitializeComponent(); 
        }
        public int id = 0;
        public int cID = 0;
       
        private void btnCreate_Click(object sender, EventArgs e)
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
            //ht.Add("@Name", txtName.Text);
            //ht.Add("@Provider", Convert.ToInt32(cbProvider.SelectedValue));
            //ht.Add("@Cost", txtCost.Text);


            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                //txtName.Text = "";
                //cbProvider.SelectedIndex = -1;
                //txtName.Focus();
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {

            string qry = "Select tid 'id' , tname 'name' from provider";
            MainClass.CBFill(qry, cdNameP);

            if (cID > 0)
            {
                cdNameP.SelectedValue = cID;
            }

            //string value = cdNameP.Text;

            //guna2TextBox1.Text = cdNameP.Text;

            //string qry2 = "select pid 'id',pname 'name',c.tname  from Product p inner join provider c on c.tid = p.pprovider where c.tname like '" + value + "'";
            //MainClass.CBFill(qry2, cbProduct);

            //if (cID > 0)
            //{
            //    cbProduct.SelectedValue = cID;
            //}
        }

        private void cdNameP_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            string value = cdNameP.Text;

            guna2TextBox1.Text = cdNameP.Text;

            string qry2 = "select pid 'id',pname 'name',c.tname  from Product p inner join provider c on c.tid = p.pprovider where c.tname like '" + value + "'";
            MainClass.CBFill(qry2, cbProduct);

            if (cID > 0)
            {
                cbProduct.SelectedValue = cID;
            }
            //int val;
            //Int32.TryParse(cdNameP.SelectedValue.ToString(), out val);
            //string qry = "Select tid,tname from provider where tid = " + val;
            //MainClass.fillCombo(cbProduct, qry, "tname", "tid");

        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string qry = "Select tid,tname from provider ";
            //MainClass.fillCombo(cdNameP, qry, "tid", "tname");
            //cdNameP_SelectedIndexChanged(null, null);
        }
    }
}
