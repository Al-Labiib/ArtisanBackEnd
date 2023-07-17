using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Application.Interfaces.Services;
using ArtisanBackEnd.Domain.Entities;

namespace artisanBackEnd.Application.Services
{
    public class ArtisanService : IArtisanService
    {
        private readonly IRepository _artisanRepository;
        public ArtisanService(IRepository artisanRepository)
        {
            _artisanRepository = artisanRepository;
        }
        public BaseResponse CreateArtisan(CreateArtisanRequestModel request)
        {
            if (request == null)
            {
                return new BaseResponse
                {
                    Message = "Information cannot be empty!",
                    Status= false
                };
            }
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
                
            };
            _artisanRepository.Add<User>(user);
            var role = _artisanRepository.Get<Role>(x => x.Name == "artisan");
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id,
            };
            _artisanRepository.Add<UserRole>(userRole);
            var artisan = new Artisan
            {
                ArtisanNumber = $"AR{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                JobCategory = request.jobCategory,
                UserId = user.Id,
                User= user,
                ProfileImage = request.ProfileImage,
                // CertificateImage = request.CertificateImage,
            };
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
            _artisanRepository.Add<Address>(address);
            _artisanRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Artisan Profile Created Successfully",
                Status = true
            };
        }

        public BaseResponse DeleteArtisan(int id)
        {
            var artisan = _artisanRepository.Get<Artisan>(x => x.Id == id);

            _artisanRepository.Delete<Artisan>(artisan);
            _artisanRepository.Delete<User>(artisan.User);

            _artisanRepository.SaveChanges();

            return new BaseResponse
            {
                Message = " Artisan Profie deleted sucessfully",
                Status = true
            };
        }

        public ArtisanResponseModel GetArtisanByArtisanNumber(string artisanNumber)
        {
            var artisan = _artisanRepository.Get<Artisan>(x=> x.ArtisanNumber == artisanNumber);
            if(artisan == null)
            {
                return new ArtisanResponseModel
                {
                    Message = $"No Record found with Artisan Number {artisanNumber}",
                    Status = false
                };
            }

            return new ArtisanResponseModel
            {
                Id = artisan.Id,
                UserId = artisan.UserId,
                FirstName = artisan.User.FirstName,
                LastName = artisan.User.LastName,
                UserName = artisan.User.UserName,
                ArtisanNUmber = artisan.ArtisanNumber,
                JobCategory= artisan.JobCategory,
                Gender = artisan.User.Gender,
                Address = artisan.User.Address,
                DateOfBirth = artisan.User.DateOfBirth,
                Email = artisan.User.Email,
                PhoneNumber = artisan.User.PhoneNumber,
                ProfileImage = artisan.ProfileImage,
                CertificateImage = artisan.CertificateImage,
                Status = true
            };
        }

        public ArtisanResponseModel GetArtisanById(int id)
        {
            var artisan = _artisanRepository.Get<Artisan>(x => x.Id == id);

            if (artisan == null)
            {
                return new ArtisanResponseModel
                {
                    Message = $"No record found for Artisan with Id {id}",
                    Status = false
                };

            }
            return new ArtisanResponseModel
            {
                Id = artisan.Id,
                UserId = artisan.UserId,
                FirstName = artisan.User.FirstName,
                LastName = artisan.User.LastName,
                UserName = artisan.User.UserName,
                ArtisanNUmber = artisan.ArtisanNumber,
                JobCategory= artisan.JobCategory,
                Gender = artisan.User.Gender,
                Address = artisan.User.Address,
                DateOfBirth = artisan.User.DateOfBirth,
                Email = artisan.User.Email,
                PhoneNumber = artisan.User.PhoneNumber,
                ProfileImage = artisan.ProfileImage,
                CertificateImage = artisan.CertificateImage,
                Status = true
            };
        }

        public IList<ArtisanResponseModel> GetArtisans()
        {
            var artisans = _artisanRepository.GetAllArtisans();

            var artisanResponse = artisans.Select(x => new ArtisanResponseModel
            {
                Id = x.Id,
                UserId = x.UserId,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                UserName = x.User.UserName,
                ArtisanNUmber = x.ArtisanNumber,
                JobCategory= x.JobCategory,
                Gender = x.User.Gender,
                Address = x.User.Address,
                DateOfBirth = x.User.DateOfBirth,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                ProfileImage = x.ProfileImage,
                CertificateImage = x.CertificateImage
            }).ToList();

            return artisanResponse;
        }

        public BaseResponse UpdateArtisan(int id, UpdateArtisanRequestModel request)
        {
            var artisan = _artisanRepository.Get<Artisan>(x => x.Id == id);

            artisan.User.PhoneNumber = request.PhoneNumber;
            artisan.User.Address = request.Address;

            var user = _artisanRepository.Update<User>(artisan.User);
            _artisanRepository.SaveChanges();

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
            var artisan = _artisanRepository.Get<Artisan>(x => x.Id == id);

            if (password.Password != null)
            {
                if (password.Password == password.ConfirmPassword)
                {
                    artisan.User.Password = password.Password;
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

            var user = _artisanRepository.Update<Artisan>(artisan);
            _artisanRepository.SaveChanges();

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