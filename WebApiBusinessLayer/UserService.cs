using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApiDataLayer;
using WebApiDataLayer.Models;

namespace WebApiBusinessLayer
{
    public class UserService : IUserService
    {
        private readonly EntityRepository<User> _entityRepository;

        public UserService(EntityRepository<User> entityRepository)
        {
            _entityRepository = entityRepository;

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _entityRepository.Get();
        }

       
        public async Task<User> GetById(int id)
        {
           return await _entityRepository.GetById(id);
        }

        public async Task CreateUser(User user)
        {
            await _entityRepository.Create(user);
        }

        public async Task UpdateUser(User user)
        {
            await _entityRepository.Update(user);
        }

        public async Task RemoveUser(User user)
        {
            await _entityRepository.Remove(user);
        }
    }
}
