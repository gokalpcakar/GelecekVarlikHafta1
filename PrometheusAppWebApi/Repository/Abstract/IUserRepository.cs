using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrometheusAppWebApi.Repository.Abstract
{
    // Bu interface'te kullancağımız metodları beyan ediyoruz.
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
