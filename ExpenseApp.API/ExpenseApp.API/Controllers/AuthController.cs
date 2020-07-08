using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.API.Models;
using ExpenseApp.Business.Contracts;
using ExpenseApp.Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseApp.API
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        readonly IUserManager _userManager;
        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<bool> Register([FromBody]User user)
        {
            return await _userManager.Register(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserModel userModel)
        {
            var user = await _userManager.AuthenticateUser(userModel.EmailId, userModel.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
