using StockTracking.BLL;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmProductList : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            CleanFilters();
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            if (txtProductName.Text.Trim() != null)
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedIndex)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rbProductEqual.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbProductMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbProductLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criteria from price group");
            }
            if (txtStock.Text.Trim() != "")
            {
                if (rbStockEqual.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbStockMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbStockLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criteria from Stock group");
            }
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
            rbProductEqual.Checked = false;
            rbProductMore.Checked = false;
            rbProductLess.Checked = false;
            rbStockEqual.Checked = false;
            rbStockMore.Checked = false;
            rbStockLess.Checked = false;
            dataGridView1.DataSource = dto.Products;
        }
    }
}
