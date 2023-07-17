using ArtisanBackEnd.Application.Interfaces.Repositories;
using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Infastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
namespace ArtisanBackEnd.Infastructure.Persistence.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly ArtisanBackendContext _artisanBackendDbContext;
        public BaseRepository(ArtisanBackendContext artisanBackendContext)
        {
            _artisanBackendDbContext = artisanBackendContext;
        }
        public T Add<T>(T entity) where T : class, new()
        {
            _artisanBackendDbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class, new()
        {
            _artisanBackendDbContext.Set<T>().Remove(entity);
            return entity;
        }

        public T Get<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            return _artisanBackendDbContext.Set<T>().FirstOrDefault(expression);
        }

        public T Update<T>(T entity) where T : class, new()
        {
            _artisanBackendDbContext.Set<T>().Update(entity);
            return entity;
        }
        public IList<T> GetAll<T> (Expression<Func<T, bool>> expression = null) where T : class, new()
        {
            return _artisanBackendDbContext.Set<T>().ToList();
        }
        
        public int SaveChanges()
        {
            return _artisanBackendDbContext.SaveChanges();
        }

        public Artisan GetArtisan(Expression<Func<Artisan, bool>> expression)
        {
            return _artisanBackendDbContext.Artisans.Include(x => x.User).SingleOrDefault(expression);
        }

        public IList<Artisan> GetAllArtisans(Expression<Func<Artisan, bool>> expression = null)
        {
            return _artisanBackendDbContext.Artisans.Include(x => x.User).ToList();
        }
        public Customer GetCustomer(Expression<Func<Customer, bool>> expression)
        {
            return _artisanBackendDbContext.Customers.Include(x=> x.User).SingleOrDefault(expression);
        }
        public IList<Customer> GetAllCustomers(Expression<Func<Artisan, bool>> expression = null)
        {
            return _artisanBackendDbContext.Customers.Include(x => x.User).ToList();
        }

        public Role GetRole(Expression<Func<Role, bool >> expression)
        {
            return _artisanBackendDbContext.Roles.SingleOrDefault(expression);
        }
        public Role GetAllRoles(Expression<Func<Role, bool>> expression)
        {
            return _artisanBackendDbContext.Roles.SingleOrDefault(expression);
        }
        public Booking GetBooking(Expression<Func<Booking, bool>> expression)
        {
            return _artisanBackendDbContext.Bookings.SingleOrDefault(expression);
        }

        public IList<Booking> GetAllBookings(Expression<Func<Booking, bool>> expression = null)
        {
            return _artisanBackendDbContext.Bookings.ToList();
        }

        public Contract GetContract(Expression<Func<Contract, bool>> expression = null)
        {
            return _artisanBackendDbContext.Contracts.SingleOrDefault(expression);
        }

        public IList<Contract> GetAllContracts(Expression<Func<Contract, bool>> expression = null)
        {
            return _artisanBackendDbContext.Contracts.ToList();
        }

        public Rate GetRate(Expression<Func<Rate, bool>> expression = null)
        {
            return _artisanBackendDbContext.Rates.SingleOrDefault(expression);
        }

        public IList<Rate> GetAllRatings(Expression<Func<Rate, bool>> expression = null)
        {
            return _artisanBackendDbContext.Rates.ToList();
        }

        IList<Role> IRepository.GetAllRoles(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}