using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.Concrete;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _IProductservice = new ProductManager(new NHibernate());
            _ICategoryService = new CategoryManager(new EfCategoryDal());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = _IProductservice.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _ICategoryService.GetAll();
        }
    }
}
