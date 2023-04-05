using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class CreateContractRequestModel
    {
        public int ArtisanId {get; set;}
        public int CustomerId {get; set;}
        public ContractStatus ContractStatus {get; set;}
        public PaymentStatus PaymentStatus {get; set;}
        public bool IsDone {get; set;}
    }
}