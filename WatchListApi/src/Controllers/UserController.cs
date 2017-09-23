using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList.Models;

namespace WatchList.Controllers
{
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly MovieContext _ctx;

        public UserController(MovieContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _ctx.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]User value)
        {
            _ctx.Users.Add(value);
            _ctx.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            var user = Get(id);
            user.Name = value.Name;
            user.Email = value.Email;

            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = Get(id);

            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
        }
    }
}