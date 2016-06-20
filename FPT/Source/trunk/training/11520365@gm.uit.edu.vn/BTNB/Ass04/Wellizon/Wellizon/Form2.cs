using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wellizon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        BUSCustomer bus_cust = new BUSCustomer();
        CustomerInfo cust_info = new CustomerInfo();

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus_cust.getData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cust_info.CustName = txtCustomerName.Text.Trim();
            cust_info.CustAge = int.Parse(txtAge.Text);
            cust_info.CustAddress = txtAddress.Text.Trim();
            cust_info.CustEMail = txtEmail.Text;
            cust_info.Problem = txtProblem.Text;
            cust_info.Status = bool.Parse(cboStatus.Text);
            cust_info.Date = dtDate.Value;
            cust_info.DateSolved = dtDateSolved.Value;
            if (bus_cust.Insert(cust_info) == 0)
                MessageBox.Show("Loi khong luu duoc");
            else
            {
                dataGridView1.DataSource = bus_cust.getData();
                MessageBox.Show("Du lieu da duoc luu");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
                return;
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int i = dataGridView1.SelectedRows[0].Index;
            
            txtCustomerName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtAge.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtProblem.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cboStatus.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            dtDate.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
            dtDateSolved.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cust_info.CustomerID = (int)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value;
            cust_info.CustName = txtCustomerName.Text.Trim();
            cust_info.CustAge = int.Parse(txtAge.Text);
            cust_info.CustAddress = txtAddress.Text.Trim();
            cust_info.CustEMail = txtEmail.Text;
            cust_info.Problem = txtProblem.Text;
            cust_info.Status = bool.Parse(cboStatus.Text);
            cust_info.Date = dtDate.Value;
            cust_info.DateSolved = dtDateSolved.Value;

            if (bus_cust.Update(cust_info) == 0)
                MessageBox.Show("Loi khong cap nhat duoc");
            else
            {
                dataGridView1.DataSource = bus_cust.getData();
                MessageBox.Show("Du lieu da duoc luu");
            }

        }
    }
}
