﻿using Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities1.Concrete
{
    public class Product: IEntity
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
