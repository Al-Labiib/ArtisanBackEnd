using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public CustomerController(ICustomerService customerService, IWebHostEnvironment webHostEnvironment)
        {
            _customerService = customerService;
            _webHostEnviroment = webHostEnvironment;
        }
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromForm] CreateCustomerRequestModel request)
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
                    request.ProfileImage= imageName;

                }
            }
            var response = _customerService.CreateCustomer(request);
            return response.Status? Ok(response) : BadRequest(response);
        }
        [HttpGet("getCustomerById/id")]
        public IActionResult GetCustomerById([FromQuery] int id)
        {
            var response = _customerService.GetCustomerById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }
        [HttpGet("getArtisanByCustomerNumber/{customerNumber}")]
        public IActionResult GetCustomerByCustomerNumber([FromRoute] string customerNumber)
        {
            var response = _customerService.GetCustomerByCustomerNumber(customerNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }
        [HttpGet("updateCustomer/{id}")]
        public IActionResult UpdateCustomer([FromRoute] int id)
        {
            var response = _customerService.GetCustomerById(id);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updateCustomer/{id}")]
        public IActionResult UpdateCustomer([FromRoute] int id, UpdateCustomerRequestModel request)
        {
            var response = _customerService.UpdateCustomer(id, request);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updatePassword/{id}")]
        public IActionResult UpdatePassword([FromRoute] int id, UpdatePasswordRequestModel password)
        {
            var response = _customerService.UpdatePassword(id, password);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("getCustomers")]
        public IActionResult GetCustomers()
        {
            var response = _customerService.GetCustomers();
            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("deleteCustomer/id")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            var response = _customerService.DeleteCustomer(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

    }
}