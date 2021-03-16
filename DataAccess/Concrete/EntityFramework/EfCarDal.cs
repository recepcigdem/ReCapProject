using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join o in context.Colors
                        on c.ColorId equals o.ColorId

                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        Description = c.Description,
                        DailyPrice = c.DailyPrice,
                        BrandName = b.BrandName,
                        ColorName = o.ColorName,
                        BrandId = b.BrandId,
                        ColorId = c.ColorId,
                        ModelYear = c.ModelYear
                    };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Cars.Where(p => p.CarId == carId)
                    join c in context.Colors
                        on p.ColorId equals c.ColorId
                    join d in context.Brands
                        on p.BrandId equals d.BrandId
                    select new CarDetailDto
                    {
                        BrandName = d.BrandName,
                        ColorName = c.ColorName,
                        DailyPrice = p.DailyPrice,
                        Description = p.Description,
                        ModelYear = p.ModelYear,
                        CarId = p.CarId
                    };
                return result.SingleOrDefault();
            }
        }

    }
}
