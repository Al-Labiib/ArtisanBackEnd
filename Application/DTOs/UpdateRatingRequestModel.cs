using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class UpdateRatingRequestModel
    {
        public string RateComment {get; set;}
        public int RateMarks {get;set;}
        public RateReview RateReview {get;set;}
    }
}