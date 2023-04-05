using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController
    {
        private readonly IRateService _rateService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public RateController(IRateService rateService, IWebHostEnvironment webHostEnvironment)
        {
            _rateService = rateService;
            _webHostEnviroment = webHostEnvironment;
        }
        // [HttpPost("createRating")]
        // public IActionResult CreateRating ([FromBody] CreateRatingRequestModel request)
        // {
        //     var response = _rateService.CreateRating(request);

        //     return response.Status? Ok(response) : BadRequest(response);
        // }
        
    }
}