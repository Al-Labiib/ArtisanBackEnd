using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtisanController : ControllerBase
    {
        private readonly IArtisanService _artisanService;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ArtisanController(IArtisanService artisanService, IWebHostEnvironment webHostEnvironment)
        {
            _artisanService = artisanService;
            _webHostEnviroment = webHostEnvironment;
        }
        [HttpPost("CreateArtisan")]
        public IActionResult CreateArtisan([FromForm] CreateArtisanRequestModel request)
        {
            var forms = HttpContext.Request.Form;
            if(forms.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnviroment.WebRootPath, "Images"); ;
                foreach(var file in forms.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string imageName = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, imageName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    path = imageName;
                }
            }
            var response = _artisanService.CreateArtisan(request);
            return response.Status? Ok(response) : BadRequest(response);
        }
        [HttpGet("getArtisanById/id")]
        public IActionResult GetArtisanById([FromQuery] int id)
        {
            var response = _artisanService.GetArtisanById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }
        [HttpGet("getArtisanByArtisanNumber/{artisanNumber}")]
        public IActionResult GetArtisanByArtisanNumber([FromRoute] string artisanNumber)
        {
            var response = _artisanService.GetArtisanByArtisanNumber(artisanNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }
        [HttpGet("updateArtisan/{id}")]
        public IActionResult UpdateArtisan([FromRoute] int id)
        {
            var response = _artisanService.GetArtisanById(id);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updateArtisan/{id}")]
        public IActionResult UpdateArtisan([FromRoute] int id, UpdateArtisanRequestModel request)
        {
            var response = _artisanService.UpdateArtisan(id, request);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updatePassword/{id}")]
        public IActionResult UpdatePassword([FromRoute] int id, UpdatePasswordRequestModel password)
        {
            var response = _artisanService.UpdatePassword(id, password);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("getArtisans")]
        public IActionResult GetArtisans()
        {
            var response = _artisanService.GetArtisans();
            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("deleteArtisan/id")]
        public IActionResult DeleteArtisan([FromRoute] int id)
        {
            var response = _artisanService.DeleteArtisan(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

    }
}