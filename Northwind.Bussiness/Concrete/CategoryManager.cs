using Northwind.Bussiness.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _CategoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _CategoryDal = categoryDal;

        }
        public List<Category> GetAll()
        {
            return _CategoryDal.GetAll();
        }

       
    }
}
