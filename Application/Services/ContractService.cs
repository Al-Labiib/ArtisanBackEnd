using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Application.Interfaces.Services;
using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IRepository _contractRepository;
        public ContractService(IRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public BaseResponse CreateContract(CreateContractRequestModel request)
        {
            var contract = new Contract
            {
                ArtisanId = request.ArtisanId,
                CustomerId = request.CustomerId,
                ContractStatus = request.ContractStatus,
                PaymentStatus = request.PaymentStatus,
            };
            if (request.ArtisanId > 0)
            {
                contract.IsDone = true;
            }
            else
            {
                contract.IsDone = false;
            }
            _contractRepository.Add<Contract>(contract);
            _contractRepository.SaveChanges();
            return new BaseResponse{
                Message = "Contract Created Successfully",
                Status = true
            };
        }

        public BaseResponse DeleteContract(int id)
        {
            var contract = _contractRepository.Get<Contract>(x => x.Id == id);

            _contractRepository.Delete<Contract>(contract);
            _contractRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Contract deleted sucessfully",
                Status = true
            };
        }

        public ContractResponseModel GetContractById(int id)
        {
            var contract = _contractRepository.Get<Contract>(x => x.Id == id);

            if (contract == null)
            {
                return new ContractResponseModel
                {
                    Message = $"No record found for Contract with Id {id}",
                    Status = false
                };

            }
            return new ContractResponseModel
            {
                ArtisanId = contract.ArtisanId,
                Artisan = contract.Artisan,
                CustomerId = contract.CustomerId,
                Customer = contract.Customer,
                ContractStatus = contract.ContractStatus,
                PaymentStatus = contract.PaymentStatus,
                Status = true
            };
            
        }

        public IList<ContractResponseModel> GetContracts()
        {
            var contract = _contractRepository.GetAllContracts();

            var contractResponse = contract.Select(x => new ContractResponseModel
            {                
                CustomerId = x.CustomerId,
                Customer = x.Customer,
                ArtisanId = x.ArtisanId,
                Artisan = x.Artisan,
                PaymentStatus = x.PaymentStatus,
            }).ToList();

            return contractResponse;
        }

        public BaseResponse PayForContract(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateContract(int id, UpdateContractRequestModel request)
        {
            var contract = _contractRepository.Get<Contract>(x=> x.Id == id);
            if(contract.ContractStatus != (ContractStatus)1)
            {
                return new BaseResponse
                {
                    Message = "Edit not allowed. Contract already approved",
                    Status = false
                };
            }
            else
            {
            contract.ContractStatus = request.ContractStatus;
            contract.IsDone = request.IsDone;
            }

            var updateContract = _contractRepository.Update<Contract>(contract);
            _contractRepository.SaveChanges();

            if(updateContract == null)
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

        }
    }
