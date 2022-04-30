using Northwind.DataAccess.Abstract;
using Northwind.Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete
{
    public class NHibernate : IProductDal
    {
        public void Add(Product product)
        {
            

        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{ProductID = 1,CategoryID=1, ProductName = "kola",
                    QuantityPerUnit ="1 in a box", UnitPrice = 5, UnitsInStock = 50 }
            };

            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
