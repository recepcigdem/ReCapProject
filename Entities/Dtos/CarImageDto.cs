using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class CarImageDto:IDto
    {
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
