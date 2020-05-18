using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDataLayer.Models;

namespace WebApiBusinessLayer
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetById(int id);

        Task CreateUser(User user);
        Task UpdateUser(User user);

        Task RemoveUser(User user);

    }
}