using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Application.Interfaces.Services;
using ArtisanBackEnd.Domain.Entities;

namespace ArtisanBackEnd.Application.Services
{
    public class RateService : IRateService
    {
        private readonly IRepository _rateRepository;
        public RateService(IRepository rateRepostory)
        {
            _rateRepository = rateRepostory;
        }
        public BaseResponse CreateRating(CreateRatingRequestModel request)
        {
            var rate = new Rate{
                RateMarks = request.RateMarks,
                RateComment = request.RateComment,
                RateReview = request.RateReview
            };
            _rateRepository.Add<Rate>(rate);
            _rateRepository.SaveChanges();
            return new BaseResponse
            {
                Message = "Rating Created Successfully",
                Status = true
            };
        }

        public BaseResponse DeleteRating(int id)
        {
            throw new NotImplementedException();
        }

        public RatingResponseModel GetRatingByArtisanId(int artisanId)
        {
            throw new NotImplementedException();
        }

        public RatingResponseModel GetRatingById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<RatingResponseModel> GetRatings()
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateRating(int id, UpdateRatingRequestModel request)
        {
            
            var rate = _rateRepository.GetRate(x => x.Id == id);
            rate.RateMarks = request.RateMarks;
            rate.RateComment = request.RateComment;
            rate.RateReview = request.RateReview;
            rate.DateUpdated = DateTime.Now;

            var update = _rateRepository.Update<Rate>(rate);
            _rateRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "Rating Updated Succcessfully",
                Status = true
            };
        }
    }
}