using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class Dispute : BaseEntity
    {
        public string DisputeComment {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public int ArtisanId {get; set;}
        public Artisan Artisan {get; set;}
        public DisputeStatus DisputeStatus {get; set;}
    }
}