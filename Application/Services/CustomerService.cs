using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Application.Interfaces.Services;
using ArtisanBackEnd.Domain.Entities;

namespace ArtisanBackEnd.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _customerRepository;
        public CustomerService(IRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public BaseResponse CreateCustomer(CreateCustomerRequestModel request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                UserName = request.UserName,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
                // Wallet = 0.00
            };
            _customerRepository.Add<User>(user);
            var role = _customerRepository.Get<Role>(x => x.Name == "customer");
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id,
            };
            _customerRepository.Add<UserRole>(userRole);
            var customer = new Customer
            {
                CustomerNumber = $"CU{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                UserId = user.Id,
                User= user,
                ProfileImage = request.ProfileImage,
            };
            _customerRepository.Add<Customer>(customer);
            var address = new Address
            {
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false,
                NumberLine = request.NumberLine,
                Street = request.Street,
                State = request.State,
                Country = request.Country,
                LocalGovernment = request.LocalGovernment
            };

            _customerRepository.Add<Address>(address);
            _customerRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Customer Profile Created Successfully",
                Status = true
            };
        }

        public BaseResponse DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(x => x.Id == id);

            _customerRepository.Delete<Customer>(customer);
            _customerRepository.Delete<User>(customer.User);

            _customerRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Customer Profie deleted sucessfully",
                Status = true
            };
        }

        public CustomerResponseModel GetCustomerByCustomerNumber(string customerNumber)
        {
            var customer = _customerRepository.GetCustomer(x=> x.CustomerNumber == customerNumber);
            if(customer == null)
            {
                return new CustomerResponseModel
                {
                    Message = $"No Record found with Customer Number {customerNumber}",
                    Status = false
                };
            }

            return new CustomerResponseModel
            {
                Id = customer.Id,
                UserId = customer.UserId,
                FirstName = customer.User.FirstName,
                LastName = customer.User.LastName,
                UserName = customer.User.UserName,
                CustomerNumber = customer.CustomerNumber,
                Gender = customer.User.Gender,
                Address = customer.User.Address,
                DateOfBirth = customer.User.DateOfBirth,
                Email = customer.User.Email,
                PhoneNumber = customer.User.PhoneNumber,
                ProfileImage = customer.ProfileImage,
                Status = true
            };
        }

        public CustomerResponseModel GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomer(x => x.Id == id);

            if (customer == null)
            {
                return new CustomerResponseModel
                {
                    Message = $"No record found for Customer with Id {id}",
                    Status = false
                };

            }
            return new CustomerResponseModel
            {
                Id = customer.Id,
                UserId = customer.UserId,
                FirstName = customer.User.FirstName,
                LastName = customer.User.LastName,
                UserName = customer.User.UserName,
                CustomerNumber = customer.CustomerNumber,
                Gender = customer.User.Gender,
                Address = customer.User.Address,
                DateOfBirth = customer.User.DateOfBirth,
                Email = customer.User.Email,
                PhoneNumber = customer.User.PhoneNumber,
                ProfileImage = customer.ProfileImage,
                Status = true
            };
        }

        public IList<CustomerResponseModel> GetCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            var customerResponse = customers.Select(x => new CustomerResponseModel
            {
                Id = x.Id,
                UserId = x.UserId,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                UserName = x.User.UserName,
                CustomerNumber = x.CustomerNumber,
                Gender = x.User.Gender,
                Address = x.User.Address,
                DateOfBirth = x.User.DateOfBirth,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                ProfileImage = x.ProfileImage,
            }).ToList();

            return customerResponse;
        }

        public BaseResponse UpdateCustomer(int id, UpdateCustomerRequestModel request)
        {
            var customer = _customerRepository.GetCustomer(x => x.Id == id);

            customer.User.PhoneNumber = request.PhoneNumber;
            customer.User.Address = request.Address;

            var user = _customerRepository.Update<User>(customer.User);
            _customerRepository.SaveChanges();

            if(user == null)
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

        public BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password)
        {
            var customer = _customerRepository.GetCustomer(x => x.Id == id);

            if (password.Password != null)
            {
                if (password.Password == password.ConfirmPassword)
                {
                    customer.User.Password = password.Password;
                }
                else
                {
                    return new BaseResponse
                    {
                        Message = "Passwords do not match",
                        Status = false
                    };
                }
            }
            else
            {
                return new BaseResponse
                {
                    Message = "Password is empty. Enter Password",
                    Status = false
                };
            }

            var user = _customerRepository.Update<Customer>(customer);
            _customerRepository.SaveChanges();

            if(user == null)
            {
                return new BaseResponse
                {
                    Message = "Unable to update password",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Password updated successfully",
                Status = true
            };
        }
    }
}