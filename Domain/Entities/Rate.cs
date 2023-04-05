using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class Rate : BaseEntity
    {
        public string RateComment {get; set;}
        public int RateMarks {get;set;}
        public RateReview RateReview {get;set;}
    }
}