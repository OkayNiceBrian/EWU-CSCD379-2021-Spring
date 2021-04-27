using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // /api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return DeleteMe.Users;
        }

        // /api/users/<index>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return DeleteMe.Users[index];
        }

        //DELETE /api/users/<index>
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            DeleteMe.Users.RemoveAt(index);
        }

        // POST /api/users
        [HttpPost]
        public void Post([FromBody] string userName)
        {
            DeleteMe.Users.Add(FirstName);
        }

        [HttptPut("{index}")]
        public void Put(int index, [FromBody]string firstName)
        {
            DeleteMe.Users[index] = firstName;
        }
    }
}