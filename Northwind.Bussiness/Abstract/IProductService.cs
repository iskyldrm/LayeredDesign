﻿using Northwind.Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        
    }
}