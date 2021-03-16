using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join color in context.Colors on c.ColorId equals color.ColorId
                             join cst in context.Customers on r.CustomerId equals cst.CustomerId
                             join u in context.Users on cst.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorName = color.ColorName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cst.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                                 
                             };
                return result.ToList();
            }
        }
    }
}

