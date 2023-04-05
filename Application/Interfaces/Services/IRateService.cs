using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface IRateService
    {
        BaseResponse CreateRating(CreateRatingRequestModel request);
        RatingResponseModel GetRatingByArtisanId(int artisanId);
        BaseResponse UpdateRating(int id, UpdateRatingRequestModel request);
        IList<RatingResponseModel> GetRatings();
        BaseResponse DeleteRating(int id);
        RatingResponseModel GetRatingById(int id);

    }
}