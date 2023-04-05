using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class InHousePayment : BaseEntity
    {
        public int ArtisanId {get; set;}
        public Artisan Artisan {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public PaymentStatus PaymentStatus {get; set;}
    }
}