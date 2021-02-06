using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        private List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand { Id = 1,BrandName = "Renault"},
                new Brand { Id = 2,BrandName = "Mercedes"},
                new Brand { Id = 3,BrandName = "BMW"}

            };
        }


        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return filter == null
                ? _brands.ToList()
                : _brands.Where(filter.Compile()).ToList();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brands.SingleOrDefault(filter.Compile());
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            var brandUpdated = _brands.SingleOrDefault(b => b.Id == brand.Id);

            brandUpdated.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            var brandDeleted = _brands.SingleOrDefault(b => b.Id == brand.Id);

            _brands.Remove(brandDeleted);
        }
    }
}
