using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class ContractResponseModel
    {
        public int ArtisanId {get; set;}
        public Artisan Artisan {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public ContractStatus ContractStatus {get; set;}
        public PaymentStatus PaymentStatus {get; set;}
    }
}