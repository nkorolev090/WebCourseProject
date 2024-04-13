using DomainModel;

namespace Interfaces.DTO
{
    public class ClientDTO
    {
        public int id { get; set; }

        public int discount_id { get; set; }

        public string discount_name { get; set; }

        public int discount_points { get; set; }

        public DateTime? birth_date { get; set; }
        public string birth_short { get; set; }

        public ClientDTO(Client client) {
            id = client.Id;
            discount_id = client.DiscountId;
            if(client.Discount != null)
                discount_name = client.Discount.Name;
            discount_points = client.DiscountPoints;
            birth_date = client.BirthDate;
            if(birth_date != null)
                birth_short = birth_date?.ToShortDateString();
        }
    }
}
