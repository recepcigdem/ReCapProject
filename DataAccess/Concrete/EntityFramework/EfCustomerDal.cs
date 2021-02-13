﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName
                        
                    };
                return result.ToList();
            }
        }
    }
}
