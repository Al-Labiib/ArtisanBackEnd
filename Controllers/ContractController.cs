using ArtisanBackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController
    {
        private readonly IContractService _contractService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public ContractController(IContractService contractService, IWebHostEnvironment webHostEnvironment)
        {
            _contractService = contractService;
            _webHostEnviroment = webHostEnvironment;
        }
    }
}