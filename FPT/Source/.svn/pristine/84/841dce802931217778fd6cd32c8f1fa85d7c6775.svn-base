/*
 * frmCustomerDetails.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wellizon
{
    /// <summary>
    /// Class frmCustomerDetails is used to demonstrate the use of DataAdapter and DataReader classes.
    /// Class frmCustomerDetails is used to add, save and view customer details.
    /// </summary>
    public partial class frmCustomerDetails : Form
    {
        SqlConnection sqlconCustomer;
        SqlCommand sqlcomCustomer;
        SqlDataReader sqldreaderCustomer;
        SqlDataAdapter sqldaCustomer;
        DataSet dsetCustomer;
        bool blnNew;

        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for accepting the purchase order details. 
        /// </summary>
        public frmCustomerDetails()
        {
            InitializeComponent();
            sqlconCustomer = new SqlConnection("server=thanhha-pc;database=Customer;uid=sa;pwd=123456");
            sqldaCustomer = new SqlDataAdapter();
            dsetCustomer = new DataSet();
        }

        // Loads the frmCustomerDetails form.
        private void frmCustomerDetails_Load(object sender, EventArgs e)
        {
            blnNew = false;
            
            sqldaCustomer = new SqlDataAdapter("SELECT * FROM CustomerDetails", sqlconCustomer);
            sqldaCustomer.Fill(dsetCustomer, "Customers");
            
            DisplayList();

            ClearControls();

            if (dsetCustomer.Tables[0].Rows.Count>0)
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
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        // Displays the customer details in the list.
        void DisplayList()
        {
            lvwCustomers.Items.Clear();

            if (dsetCustomer.Tables["Customers"].Rows.Count > 0)
            {
                for (int rows = 0; rows < dsetCustomer.Tables["Customers"].Rows.Count; rows++)
                {
                    lvwCustomers.Items.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[0].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[1].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[2].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[3].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[4].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[5].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[6].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[7].ToString());
                    lvwCustomers.Items[rows].SubItems.Add(dsetCustomer.Tables["Customers"].Rows[rows].ItemArray[8].ToString());
                }
                lvwCustomers.Items[0].Selected = true;
                lvwCustomers.Focus();
            }
        }

        // Adds a new record.
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            blnNew = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtCustomerName.Focus();
        }

        // Clears the controls.
        void ClearControls()
        {
            txtCustomerName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtProblem.Text = "";
            cboStatus.Text = "";
            mskDateSolved.Text = "";
            mskDate.Text = "";
        }

        // Saves the current record.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidations())
            {
                if (blnNew){
                    DataRow drow = dsetCustomer.Tables["Customers"].NewRow();
                    drow["CustName"] = txtCustomerName.Text;
                    drow["CustAge"] = txtAge.Text;
                    drow["CustAddress"] = txtAddress.Text;
                    drow["CustEmail"] = txtEmail.Text;
                    drow["Problem"] = txtProblem.Text;
                    drow["Status"] = cboStatus.Text;
                    drow["Date"] = mskDate.Text;
                    drow["DateSolved"] = mskDateSolved.Text;
                    dsetCustomer.Tables["Customers"].Rows.Add(drow);
                    blnNew = false;
                }
                else{
                    int i = lvwCustomers.SelectedItems[0].Index;
                    dsetCustomer.Tables["Customers"].Rows[i]["CustName"] = txtCustomerName.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["CustAddress"] = txtAddress.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["CustAge"] = txtAge.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["CustEmail"] = txtEmail.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["Problem"] = txtProblem.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["Status"] = cboStatus.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["Date"] = mskDate.Text;
                    dsetCustomer.Tables["Customers"].Rows[i]["DateSolved"] = mskDateSolved.Text;
                    
                    
                }
                SqlCommandBuilder sqlbiulder = new SqlCommandBuilder(sqldaCustomer);
                sqldaCustomer.Update(dsetCustomer, "Customers");

                MessageBox.Show("The record has been saved successfully.", "Wellizon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayList();
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        // Validates the controls.
        bool CheckValidations()
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter customer name.", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }
            else if (cboStatus.Text == "")
            {
                MessageBox.Show("Please select country.", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboStatus.Focus();
            }
            //else if (msktxtPhone.Text == "(   )    -")
            //{
            //    MessageBox.Show("Please enter phone number.", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    msktxtPhone.Focus();
            //}
            else if (mskDate.Text == "     -")
            {
                MessageBox.Show("Please enter zip code.", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDate.Focus();
            }
            else
            {
                return true;
            }
            return false;
        }

        // Deletes the current record.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCustomers.SelectedItems.Count > 0)
            {
                if (!sqldreaderCustomer.IsClosed)
                    sqldreaderCustomer.Close();
                foreach (ListViewItem lvwitem in lvwCustomers.SelectedItems)
                {
                    dsetCustomer.Tables["Customers"].Rows[lvwitem.Index].Delete();
                }
                sqldaCustomer.Update(dsetCustomer, "Customers");
                DisplayList();
                MessageBox.Show("The record has been deleted successfully.", "Wellizon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dsetCustomer.Tables["Customers"].Rows.Count <= 0)
                {
                    ClearControls();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                }
            }
        }

        // Modifies the current record.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCustomers.SelectedItems.Count > 0)
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                txtCustomerName.Focus();
            }
        }

        // Displays the customer details.
        private void lvwCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCustomers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwCustomers.SelectedItems[0];
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

        // Cancels the current operation.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (blnNew && dsetCustomer.Tables["Customers"].Rows.Count > 0)
            {
                DisplayList();
            }
            blnNew = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        // Closes the form.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
