using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class CarDTO
    {
        public int id { get; set; }
        public string model { get; set; }

        public int owner_id { get; set; }

        public string color { get; set; }

        public string brand { get; set; }
        public string br_mod { get; set; }

        public int mileage { get; set; }

        public CarDTO(Car car) { 
            id = car.Id;
            model = car.Model;
            owner_id = car.OwnerId;
            color = car.Color;
            brand = car.Brand;
            br_mod = car.Brand + " " + car.Model;
            mileage = car.Mileage;

        }
    }
}
