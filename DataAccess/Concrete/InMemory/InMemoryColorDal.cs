using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{ 
    public class InMemoryColorDal:IColorDal
    {
        private List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color() {Id = 1, ColorName = "Mavi"},
                new Color() {Id = 2, ColorName = "Kırmızı"}

            };
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return filter == null
                ? _colors.ToList()
                : _colors.Where(filter.Compile()).ToList();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _colors.SingleOrDefault(filter.Compile());
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Update(Color color)
        {
            Color colorUpdated = _colors.SingleOrDefault(c => c.Id == color.Id);

            colorUpdated.ColorName = color.ColorName;
        }

        public void Delete(Color color)
        {
            Color colorDeleted = _colors.SingleOrDefault(c => c.Id == color.Id);

            _colors.Remove(colorDeleted);
        }
    }
}
