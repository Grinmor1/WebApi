﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiDataLayer;
using WebApiDataLayer.Models;
using WebApiBusinessLayer;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userService.GetUsers();

            return new ActionResult<IEnumerable<User>>(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        //// POST api/users
        //[HttpPost]
        //public async Task<ActionResult<User>> Post(User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (user.Name == "admin")
        //    {
        //        ModelState.AddModelError("Name", "Недопустимое имя пользователя - admin");
        //    }

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _userService.DbSet.Add(user);
        //    await _userService.SaveChangesAsync();
        //    return Ok(user);
        //}

        //// PUT api/users/
        //[HttpPut]
        //public async Task<ActionResult<User>> Put(User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!_userService.DbSet.Any(x => x.Id == user.Id))
        //    {
        //        return NotFound();
        //    }

        //    _userService.Update(user);
        //    await _userService.SaveChangesAsync();
        //    return Ok(user);
        //}

        //// DELETE api/users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> Delete(int id)
        //{
        //    User user = _userService.DbSet.FirstOrDefault(x => x.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    _userService.DbSet.Remove(user);
        //    await _userService.SaveChangesAsync();
        //    return Ok(user);
        //}
    }
}