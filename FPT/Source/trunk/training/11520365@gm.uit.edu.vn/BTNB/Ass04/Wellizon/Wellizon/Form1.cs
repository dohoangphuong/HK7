using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Wellizon
{
    public partial class Form1 : Form
    {
        SqlConnection sqlconCustomer = new SqlConnection("server=DungTA;database=Customer;uid=sa;pwd=123456");
        SqlCommand sqlcomCustomer = new SqlCommand();
        SqlDataAdapter sqldaCustomer = new SqlDataAdapter();
        DataSet dsetCustomer = new DataSet();
        bool blnNew;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            blnNew = true;
            txtCustomerName.Focus();

            txtCustomerName.Text = "";
            txtCustomerName.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Neu them moi
            if (blnNew == true)
            {
                DataRow row = dsetCustomer.Tables[0].NewRow();
                row[1] = txtCustomerName.Text;
                row[2] = txtAge.Text;
                row[3] = txtAddress.Text;
                row[4] = txtEmail.Text;
                row[5] = txtProblem.Text;
                row[6] = cboStatus.Text;
                row[7] = mskDate.Text;
                row[8] = mskDateSolved.Text;
                dsetCustomer.Tables[0].Rows.Add(row);
            }
            else//Update
            {
                int i = lvwCustomers.SelectedItems[0].Index;
                dsetCustomer.Tables[0].Rows[i][1] = txtCustomerName.Text;
                dsetCustomer.Tables[0].Rows[i][2] = txtAge.Text;
                dsetCustomer.Tables[0].Rows[i][3] = txtAddress.Text;
                dsetCustomer.Tables[0].Rows[i][4] = txtEmail.Text;
                dsetCustomer.Tables[0].Rows[i][5] = txtProblem.Text;
                dsetCustomer.Tables[0].Rows[i][6] = cboStatus.Text;
                dsetCustomer.Tables[0].Rows[i][7] = mskDate.Text;
                dsetCustomer.Tables[0].Rows[i][8] = mskDateSolved.Text;
            }
            SqlCommandBuilder sqlcombuilder = new SqlCommandBuilder(sqldaCustomer);
            sqldaCustomer.Update(dsetCustomer, "Customers");
            MessageBox.Show("Data saved!");
            
            DisplayInfo();

        }
        private void lvwCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCustomers.SelectedItems.Count > 0)
            {
                int i = lvwCustomers.SelectedItems[0].Index;
                ListViewItem item = lvwCustomers.Items[i];
                txtCustomerName.Text = item.SubItems[1].Text;
                txtAge.Text = item.SubItems[2].Text;
                txtAddress.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;
                txtProblem.Text = item.SubItems[5].Text;
                cboStatus.Text = item.SubItems[6].Text;
                mskDate.Text = item.SubItems[7].Text;
                mskDateSolved.Text = item.SubItems[8].Text;
            }
        }

        private void DisplayInfo()
        {
            sqldaCustomer = new SqlDataAdapter("SELECT * FROM CustomerDetails", sqlconCustomer);
            dsetCustomer = new DataSet();
            sqldaCustomer.Fill(dsetCustomer, "Customers");
            lvwCustomers.Items.Clear();
            if (dsetCustomer.Tables["Customers"].Rows.Count > 0)
            {
                for (int rows = 0; rows < dsetCustomer.Tables["Customers"].Rows.Count; rows++)
                {
                    lvwCustomers.Items.Add(dsetCustomer.Tables["Customers"].Rows[rows][0].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][1].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][2].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][3].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][4].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][5].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][6].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][7].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows][8].ToString());
                }
                lvwCustomers.Items[0].Selected = true;
                lvwCustomers.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCustomerName.ReadOnly = true;
            blnNew = false;

            DisplayInfo();

            if (dsetCustomer.Tables[0].Rows.Count > 0)
            {
                txtCustomerName.Text = dsetCustomer.Tables[0].Rows[0][1].ToString();
                txtAge.Text = dsetCustomer.Tables[0].Rows[0][2].ToString();
                txtAddress.Text = dsetCustomer.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = dsetCustomer.Tables[0].Rows[0][4].ToString();
                txtProblem.Text = dsetCustomer.Tables[0].Rows[0][5].ToString();
                cboStatus.Text = dsetCustomer.Tables[0].Rows[0][6].ToString();
                mskDate.Text = dsetCustomer.Tables[0].Rows[0][7].ToString();
                mskDateSolved.Text = dsetCustomer.Tables[0].Rows[0][8].ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            blnNew = false;
            txtCustomerName.ReadOnly = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Delete?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                return;

            int i = lvwCustomers.SelectedItems[0].Index;
            dsetCustomer.Tables[0].Rows[i].Delete();

            SqlCommandBuilder sqlcombuilder = new SqlCommandBuilder(sqldaCustomer);
            sqldaCustomer.Update(dsetCustomer, "Customers");
            MessageBox.Show("Data saved!");

            DisplayInfo();
        }
    }
}
