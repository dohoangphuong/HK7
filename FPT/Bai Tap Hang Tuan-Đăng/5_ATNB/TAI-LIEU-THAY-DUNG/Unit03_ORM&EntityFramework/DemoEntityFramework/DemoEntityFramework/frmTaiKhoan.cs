using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEntityFramework
{
    public partial class frmTaiKhoan : Form
    {
        QLBanHangEntities demoEntity = new QLBanHangEntities();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void FillData()
        {
            //dataGridView1.DataSource = demoEntity.TaiKhoans.ToList();
            dataGridView1.DataSource = demoEntity.TaiKhoans.Where(tk => tk.DiaChi == "Quận 9").ToList();
            //dataGridView1.DataSource = demoEntity.TaiKhoans.Select(tk => new
            //{
            //    username = tk.UserName,
            //    hoten = tk.HoTen,
            //    email = tk.Email,
            //    dienthoai = tk.DienThoai,
            //    diachi = tk.DiaChi,
            //    congty = tk.CongTy
            //}).ToList();

            //var query = (from values in demoEntity.TaiKhoans
            //             where values.DiaChi == "Quận 9"
            //             select values).ToList();
            //dataGridView1.DataSource = query;

            //var query = (from values in demoEntity.TaiKhoans
            //             where values.DiaChi == "Quận 9"
            //             select new{
            //                 username = values.UserName,
            //                 hoten = values.HoTen,
            //                 email = values.Email,
            //                 dienthoai = values.DienThoai,
            //                 diachi = values.DiaChi,
            //                 congty = values.CongTy
            //             }).ToList();
            //dataGridView1.DataSource = query;
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string username = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TaiKhoan tk = demoEntity.TaiKhoans.Single(t => t.UserName.Equals(username));
                txtUsername.Text = tk.UserName;
                txtHoTen.Text = tk.HoTen;
                txtEmail.Text = tk.Email;
                txtDienthoai.Text = tk.DienThoai;
                txtDiachi.Text = tk.DiaChi;
                txtCongty.Text = tk.CongTy;
            }
            catch
            {   
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string username = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult dl = MessageBox.Show("Ban co muon xoa khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == System.Windows.Forms.DialogResult.Yes)
            {
                TaiKhoan tk = demoEntity.TaiKhoans.Single(t => t.UserName.Equals(username));
                demoEntity.TaiKhoans.Remove(tk);
                demoEntity.SaveChanges();
                FillData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = new TaiKhoan();
                tk.UserName = txtUsername.Text;
                tk.Password = txtPassword.Text;
                tk.HoTen = txtHoTen.Text;
                tk.Email = txtEmail.Text;
                tk.DienThoai = txtDienthoai.Text;
                tk.DiaChi = txtDiachi.Text;
                tk.CongTy = txtCongty.Text;
                demoEntity.TaiKhoans.Add(tk);
                demoEntity.SaveChanges();
                FillData();
            }
            catch
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TaiKhoan tk = demoEntity.TaiKhoans.Single(t => t.UserName.Equals(username));
                if (txtPassword.Text.Trim().Length>0)
                    tk.Password = txtPassword.Text;
                tk.HoTen = txtHoTen.Text;
                tk.Email = txtEmail.Text;
                tk.DienThoai = txtDienthoai.Text;
                tk.DiaChi = txtDiachi.Text;
                tk.CongTy = txtCongty.Text;
                demoEntity.SaveChanges();
                FillData();
            }
            catch
            {   
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
        }
    }
}
