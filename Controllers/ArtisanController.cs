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
            BaseResponse response = new BaseResponse();
            try
            {
                System.Console.WriteLine(request.CertificateImage);
            var forms = HttpContext.Request.Form;
            if( forms != null && forms.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnviroment.WebRootPath, "Images");
                Directory.CreateDirectory(imageDirectory);
                    FileInfo pinfo = new FileInfo(forms.Files[0].FileName);
                    FileInfo cinfo = new FileInfo(forms.Files[1].FileName);
                    string pimageName = Guid.NewGuid().ToString() + pinfo.Extension;
                    string cimageName = Guid.NewGuid().ToString() + cinfo.Extension;
                    string path = Path.Combine(imageDirectory, pimageName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        forms.Files[0].CopyTo(fileStream);
                    }
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        forms.Files[1].CopyTo(fileStream);
                    }
                    request.ProfileImage = pimageName;
                    request.CertificateImage = pimageName;
            }
              response = _artisanService.CreateArtisan(request);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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