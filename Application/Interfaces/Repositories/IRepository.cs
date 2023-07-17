using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Domain.Entities;
using System.Linq.Expressions;
namespace ArtisanBackEnd.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : class, new();
        T Delete<T>(T entity) where T : class, new();
        T Update<T>(T entity) where T : class, new();
        T Get<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IList<T> GetAll<T>(Expression<Func<T, bool>> expression = null) where T : class, new();
        // Artisan GetArtisan(Expression<Func<Artisan, bool>> expression);
        IList<Artisan> GetAllArtisans(Expression<Func<Artisan, bool>> expression = null);
        // Customer GetCustomer(Expression<Func<Customer, bool>> expression);
        IList<Customer> GetAllCustomers(Expression<Func<Artisan, bool>> expression = null);
        // Booking GetBooking(Expression<Func<Booking, bool>> expression);
        IList<Booking> GetAllBookings(Expression<Func<Booking, bool>> expression = null);
        // Contract GetContract (Expression<Func<Contract, bool>> expression = null);
        IList<Contract> GetAllContracts(Expression<Func<Contract, bool>> expression = null);
        // Rate GetRate(Expression<Func<Rate, bool>> expression = null);
        IList<Rate> GetAllRatings(Expression<Func<Rate, bool>> expression = null);
        // Role GetRole(Expression<Func<Role, bool>> expression = null);
        IList<Role> GetAllRoles(Expression<Func<Role, bool>> expression = null);

        int SaveChanges();
    }
}