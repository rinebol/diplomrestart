﻿using diplomrestart.OrderView;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomrestart.View
{
    public partial class frmOrder2 : Form
    {
        public frmOrder2()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;



        public static readonly string con_string = @"Data Source=DESKTOP-TE1RSA1\SQLEXPRESS;Initial Catalog=diplom;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);
        //SqlCommand cmd;
        //SqlDataReader dr;




        private void cdNameP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cdNameP.Text;
          

           

            

            string qry2 = "select pid 'id',pname 'name',c.tname  from Product p inner join provider c on c.tid = p.pprovider where c.tname like '" + value + "'";
            MainClass.CBFill(qry2, cbProduct);

            if (cID > 0)
            {
                cbProduct.SelectedValue = cID;
            }



            //txtCost.Text = value2;


            //////////


            //int val;
            //Int32.TryParse(cdNameP.SelectedValue.ToString(), out val);
            //string qry = "Select tid,tname from provider where tid = " + val;
            //MainClass.fillCombo(cbProduct, qry, "tname", "tid");
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string value2 = cbProduct.Text;
            //cmd = new SqlCommand("select pid 'id', pcost 'name' from Product where pname = @ProductN", con);
            //cmd.Parameters.AddWithValue("@ProductN", cbProduct);
            //con.Open();
            //dr = cmd.ExecuteReader();
            //while(dr.Read())
            //{
            //    string txt = dr["@txtCost"].ToString();
            //    txtCost.Text= txt;
            //}
            //con.Close();


            //SqlCommand cmd = new SqlCommand(qry3, con);
            //cmd.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //txtCost.Text = dt.ToString();
            string value2 = cbProduct.Text;
            string qry3 = "select pid 'id', pcost 'name' from Product where pname like '" + value2 + "'";
            MainClass.CBFill2(qry3, cbCost);

            if (cID > 0)
            {
                cbCost.SelectedValue = cID;
            }
        }

        private void frmOrder2_Load(object sender, EventArgs e)
        {
        
            this.productTableAdapter.Fill(this.diplomDataSet.Product);
            string qry = "Select tid 'id' , tname 'name' from provider";
            MainClass.CBFill(qry, cdNameP);

            if (cID > 0)
            {
                cdNameP.SelectedValue = cID;
            }
         

           
            //string sql = "SELECT*FROM Product";
            //cmd = new SqlCommand(sql, con);
            //con.Open();
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    cbProduct.Items.Add(dr["ProductN"]);
            //}
            //con.Close();

            ///////////////////
            //string value = cdNameP.Text;

            //txtCost.Text = value;

            //string qry2 = "select pid 'id',pname 'name',c.tname  from Product p inner join provider c on c.tid = p.pprovider where c.tname like '" + value + "'";
            //MainClass.CBFill(qry2, cbProduct);

            //if (cID > 0)
            //{
            //    cbProduct.SelectedValue = cID;
            //}
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            string qry = "";
            if (id == 0)
            {
                qry = "Insert into OrderP Values(@Name,@Provider,@Count,@Active,@Date,@Cost)";

            }
            else
            {
                qry = "Update OrderP Set oname = @Name, oprovider = @Provider,odate = @Date, ocost = @Cost, oactive = @Active, ocount = @Count where oid = @id ";
            }
            Hashtable ht = new Hashtable();
            string active = "active";
            string date = DateTime.Now.ToString("MM/dd/yyyy"); 
            ht.Add("@id", id);
            //ht.Add("@Name", Convert.ToInt32(cdNameP.SelectedValue));
            ht.Add("@Name", cdNameP.Text);
            //ht.Add("@Provider", Convert.ToInt32(cbProduct.SelectedValue));
            ht.Add("@Provider",cbProduct.Text);
            ht.Add("@Count", txtCount.Text);
            ht.Add("@Active", active);
            ht.Add("@Date", date);
            ht.Add("@Cost", cbCost.Text);




            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                //txtName.Text = "";
                //cbProvider.SelectedIndex = -1;
                //txtName.Focus();
            }

        }
        public void AddControls(Form f)
        {
            ViewPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ViewPanel.Controls.Add(f);
            f.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddControls(new OrderViewProduct());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new OrderViewProvider());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new OrderViewCategoris());
        }

        private void cbCost_SelectedIndexChanged(object sender, EventArgs e)
        {

      


            

        }
    }
}

