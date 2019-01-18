using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tcm.Application.Users;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    //[Authorize(Roles = "member")]

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository; 
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserCreateViewModel value)
        {


           
           
            var user = new User();

          
            long userId;
            long.TryParse(value.sub, out userId);
            var existedUser = _userRepository.GetById(userId);
            if (existedUser == null)
            {
                user.Id = userId;
                user.Email = value.given_name;


                _userRepository.Add(user);
            }
          
            return Ok(user);
        }

    }
}