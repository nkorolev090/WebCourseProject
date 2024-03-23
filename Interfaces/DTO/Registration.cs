using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class RegistrationDTO
    {
        public int id { get; set; }

        public int car_id { get; set; }

        public string? car_name {  get; set; }

        public DateTime? reg_date {  get; set; }

        public string? info { get; set; }

        public int status { get; set; }

        public string? status_name { get; set; }

        public int? client_id {  get; set; }
        public int? reg_price { get; set; }

        public RegistrationDTO(Registration registration) {
            id = registration.Id;
            car_id = registration.CarId;
            car_name = registration.Car.Brand + " " + registration.Car.Model;
            client_id = registration.Car.OwnerId;
            info = registration.Info;
            status = registration.Status;
            status_name = registration.StatusNavigation.Name;
            reg_price = registration.RegPrice;
            reg_date = registration.RegDate;
        }
       
        public RegistrationDTO()
        {
        }

    }
}
