using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class JobPost : BaseEntity
    {
        public JobStatus JobStatus {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public string JobName {get; set;}
        public bool IsVeryUrgent {get; set;}
    }
}