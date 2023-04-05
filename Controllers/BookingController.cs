using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanBackEnd.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public BookingController(IBookingService bookingService, IWebHostEnvironment webHostEnvironment)
        {
            _bookingService = bookingService;
            _webHostEnviroment = webHostEnvironment;
        }
        [HttpPost("createBooking")]
        public IActionResult CreateBooking ([FromBody] CreateBookingRequestModel request)
        {
            var response = _bookingService.CreateBooking(request);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("approveBooking/{id}")]
        public IActionResult ApproveBooking([FromRoute] int id)
        {
            var response = _bookingService.ApproveBooking(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("rejectBooking/{id}")]
        public IActionResult RejectBooking([FromRoute] int id)
        {
            var response = _bookingService.RejectBooking(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("cancelBooking/{id}")]
        public IActionResult CancelBooking([FromRoute] int id)
        {
            var response = _bookingService.CancelBooking(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpGet("getBookingById/id")]
        public IActionResult GetBookingById([FromQuery] int id)
        {
            var response = _bookingService.GetBookingById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }

        [HttpPut("payForBooking/{id}")]
        public IActionResult PayForBooking([FromRoute] int id)
        {
            var response = _bookingService.PayForBooking(id);

            return response.Status? Ok(response) : BadRequest(response);
        }
        

    }
}