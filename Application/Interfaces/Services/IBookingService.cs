using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface IBookingService
    {
        BaseResponse CreateBooking(CreateBookingRequestModel request);
        BookingResponseModel GetBookingById(int id);
        BaseResponse UpdateBooking(int id, UpdateBookingRequestModel request);
        IList<BookingResponseModel> GetBookings();
        BaseResponse DeleteBooking(int id);
        BaseResponse ApproveBooking(int id);
        BaseResponse RejectBooking (int id);
        BaseResponse CancelBooking (int id);
        BaseResponse BookingDone (int id);
        BaseResponse PayForBooking (int id);
    }
}