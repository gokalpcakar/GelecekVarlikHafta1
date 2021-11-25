using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrometheusAppWebApi.Repository.Abstract;

namespace PrometheusAppWebApi.Repository.Concrete.EntityFramework
{
    // Bu sınıf IUserRepository adlı interface'ten kalıtılıyor.
    public class EfUserRepository : IUserRepository
    {
        // Context sınıfı çağırılıyor.
        private readonly UserDbContext context;
        public EfUserRepository(UserDbContext _context)
        {
            context = _context;
        }

        // Bu kısımdan itibaren interface'te tanımlanmış metodlar implemente ediliyor.
        public async Task<User> AddUser(User user)
        {
            var result = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int id)
        {
            var result = await context.Users.FirstOrDefaultAsync(i => i.UserId == id);

            if (result != null)
            {
                context.Users.Remove(result);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int id)
        {
            return await context.Users.FirstOrDefaultAsync(i => i.UserId == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(i => i.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await context.Users.FirstOrDefaultAsync(i => i.UserId == user.UserId);

            // Kullanıcı varsa olan kullanıcıdaki veriler gelen kullanıcıdaki verilerle değiştirilerek güncelleme işlemi gerçekleştiriliyor.
            if (result != null)
            {
                result.Name = user.Name;
                result.Surname = user.Surname;
                result.PhoneNumber = user.PhoneNumber;
                result.Email = user.Email;
                result.DateOfBirth = user.DateOfBirth;

                await context.SaveChangesAsync();

                return result;
            }

            return null;
        }
        // Bu kısımda interface'te tanımlanmış metodların implemente işlemi sonlanıyor.
    }
}
