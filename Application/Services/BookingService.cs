using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Application.Interfaces.Services;
using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository _bookingRepository;
        public BookingService(IRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public BaseResponse CreateBooking(CreateBookingRequestModel request)
        {
            var booking = new Booking {
                CustomerId = request.CustomerId,
                ArtisanId = request.ArtisanId,
                BookingDate = request.BookingDate,
                EndBookingDate = request.EndBookingDate,
                PaymentStatus = request.PaymentStatus,
                Cost = request.Cost,
                Reason = request.Reason,
                BookingStatus = request.BookingStatus
            };

            if (request.ArtisanId > 0)
            {
                booking.IsApproved = true;
            }
            else
            {
                booking.IsApproved = false;
            }
            _bookingRepository.Add<Booking>(booking);
            _bookingRepository.SaveChanges();
            return new BaseResponse{
                Message = "Booking Created Successfully",
                Status = true
            };
            
        }

        public BaseResponse DeleteBooking(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);

            _bookingRepository.Delete<Booking>(booking);
            // _bookingRepository.Delete<User>(artisan.User);

            _bookingRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Booking deleted sucessfully",
                Status = true
            };
        }

        public BookingResponseModel GetBookingById(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);

            if (booking == null)
            {
                return new BookingResponseModel
                {
                    Message = $"No record found for Booking with Id {id}",
                    Status = false
                };

            }
            return new BookingResponseModel
            {
                BookingDate = booking.BookingDate,
                EndBookingDate = booking.EndBookingDate,
                Reason = booking.Reason,
                CustomerId = booking.CustomerId,
                Customer = booking.Customer,
                ArtisanId = booking.ArtisanId,
                Artisan = booking.Artisan,
                Cost = booking.Cost,
                IsApproved = booking.IsApproved,
                BookingStatus = booking.BookingStatus,
                PaymentStatus = booking.PaymentStatus,
                Status = true
            };
        }

        public IList<BookingResponseModel> GetBookings()
        {
            var bookings = _bookingRepository.GetAllBookings();

            var bookingResponse = bookings.Select(x => new BookingResponseModel
            {
                BookingDate = x.BookingDate,
                EndBookingDate = x.EndBookingDate,
                Reason = x.Reason,
                CustomerId = x.CustomerId,
                Customer = x.Customer,
                ArtisanId = x.ArtisanId,
                Artisan = x.Artisan,
                Cost = x.Cost,
                IsApproved = x.IsApproved,
                BookingStatus = x.BookingStatus,
                PaymentStatus = x.PaymentStatus,
            }).ToList();

            return bookingResponse;
        }

        public BaseResponse UpdateBooking(int id, UpdateBookingRequestModel request)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);

            if(booking.BookingStatus != (BookingStatus)1)
            {
                return new BaseResponse
                {
                    Message = "Edit not allowed. Booking already approved",
                    Status = false
                };
            }
            else
            {
            booking.BookingDate = request.BookingDate;
            booking.EndBookingDate = request.EndBookingDate;
            booking.Cost = request.Cost;
            booking.Reason = request.Reason;
            booking.BookingStatus = request.BookingStatus;
            booking.PaymentStatus= request.PaymentStatus;
            }

            var updateBooking = _bookingRepository.Update<Booking>(booking);
            _bookingRepository.SaveChanges();

            if(updateBooking == null)
            {
                return new BaseResponse
                { 
                    Message = "Record Update Not Succcessful",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Record Updated Succcessfully",
                Status = true
            };
        }

        public BaseResponse ApproveBooking (int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);
            booking.BookingStatus = (BookingStatus)2;

            var bookingUpdate = _bookingRepository.Update<Booking>(booking);
            _bookingRepository.SaveChanges();

            if (bookingUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Booking Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Booking Aprroved",
                Status = true
            };
        }

        public BaseResponse PayForBooking(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);
            booking.PaymentStatus = (PaymentStatus)1;

            _bookingRepository.Update(booking);
            _bookingRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment updated successfully",
                Status = true
            };
        }

        public BaseResponse RejectBooking(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);
            booking.BookingStatus = (BookingStatus)3;

            var bookingUpdate = _bookingRepository.Update<Booking>(booking);
            _bookingRepository.SaveChanges();
            if (bookingUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Booking Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Booking Rejected",
                Status = true
            };
        }

        public BaseResponse CancelBooking(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);
            booking.BookingStatus = (BookingStatus)5;

            var bookingUpdate = _bookingRepository.Update<Booking>(booking);
            _bookingRepository.SaveChanges();
            if (bookingUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Booking Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Booking Cancelled",
                Status = true
            };
        }

        public BaseResponse BookingDone(int id)
        {
            var booking = _bookingRepository.Get<Booking>(x => x.Id == id);
            booking.BookingStatus = (BookingStatus)4;

            var bookingUpdate = _bookingRepository.Update<Booking>(booking);
            _bookingRepository.SaveChanges();
            if (bookingUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Booking Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Booking Done",
                Status = true
            };
        }
    }
}