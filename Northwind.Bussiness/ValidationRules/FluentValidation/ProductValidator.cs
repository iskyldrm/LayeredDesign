using FluentValidation;
using Northwind.Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty();
            RuleFor(p=>p.CategoryID).NotEmpty();
            RuleFor(p=>p.UnitPrice).NotEmpty();

            RuleFor(p => p.UnitPrice)
                .GreaterThan(100)
                .When(p => p.CategoryID == 8).
                WithMessage("Fiyat 100 den büyük olmalı"); 

            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün A ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
