using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface IArtisanService
    {
        BaseResponse CreateArtisan(CreateArtisanRequestModel request);
        ArtisanResponseModel GetArtisanById(int id);
        ArtisanResponseModel GetArtisanByArtisanNumber (string artisanNumber);
        BaseResponse UpdateArtisan(int id, UpdateArtisanRequestModel request);
        BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password);
        IList<ArtisanResponseModel> GetArtisans();
        BaseResponse DeleteArtisan(int id);
    }
}