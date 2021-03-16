using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class CarDetailAndImagesDto : IDto
    {
        public CarDetailDto Car { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
