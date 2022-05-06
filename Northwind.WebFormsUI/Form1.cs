using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.Concrete;
using Northwind.Bussiness.DependencyInjection.Ninject;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        private IProductService _IProductservice;
        private ICategoryService _ICategoryService;
        public Form1()
        {
            InitializeComponent();
            _IProductservice = InstanceFactory.GetInstance<IProductService>();
            //_IProductservice = new ProductManager(new EfProductDal());
            _ICategoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _ICategoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryIdAdd.DataSource = _ICategoryService.GetAll();
            cbxCategoryIdAdd.DisplayMember = "CategoryName";
            cbxCategoryIdAdd.ValueMember = "CategoryId";

            cbxCategoryNameUpdate.DataSource = _ICategoryService.GetAll();
            cbxCategoryNameUpdate.DisplayMember = "CategoryName";
            cbxCategoryNameUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _IProductservice.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _IProductservice.GetProductsByCategoryId(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {}   
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbxProductName.Text))
                {
                    dataGridView1.DataSource = _IProductservice.GetProductsByProductName(tbxProductName.Text);
                }
                else
                {
                    LoadProducts();
                }
                
            }
            catch
            { 
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _IProductservice.Add(new Product
                {
                    CategoryID = Convert.ToInt32(cbxCategoryIdAdd.SelectedValue),
                    SupplierID = 1,
                    ProductName = tbxProductNameAdd.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStockAdd.Text),
                    QuantityPerUnit = tbxQuantityPerUnitAdd.Text,

                });
                MessageBox.Show("Ürün Eklendi");
                LoadProducts();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxProductNameUpdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxUnitPriceUpdate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxUnitStockUpdate.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            tbxProductIdDelete.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxProductNameDelete.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _IProductservice.Update(new Product
                {
                    ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                    SupplierID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value),
                    CategoryID = Convert.ToInt32(cbxCategoryNameUpdate.SelectedValue),
                    ProductName = tbxProductNameUpdate.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitStockUpdate.Text),
                    QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,

                });
            }
            catch
            {


            }
            MessageBox.Show("Ürün Güncellendi");
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   
            try
            {
                _IProductservice.Delete(new Product
                {
                    ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)

                });
            }
            catch
            {


            }
            MessageBox.Show("Ürün Silindi");
            LoadProducts();
        }
    }
}
