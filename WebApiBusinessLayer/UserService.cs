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

    }
}
