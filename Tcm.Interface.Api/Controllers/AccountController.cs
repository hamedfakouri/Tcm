using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tcm.Application.Contract.ApplicationUsers;
using Tcm.Application.Contract.Students;
using Tcm.Domain.Enum;
using Tcm.Domain.IdentityModel;
using Tcm.Persistence.Ef;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [AllowAnonymous]
   
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IStudentService _studentService;
        private readonly TcmContext _applicationDbContext;
        private readonly RoleManager<Role> roleManager;

        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            TcmContext applicationDbContext,
            RoleManager<Role> roleManager,
            IConfiguration configuration,
            IStudentService studentService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
    

            _applicationDbContext = applicationDbContext;
            this.roleManager = roleManager;
            _configuration = configuration;
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize(Roles = "Admin")]
        [Route("users")]
        public IActionResult GetUsers()
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IActionResult> GetUser(string Id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok();
            }

            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{username}")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await this._userManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ApplicationUserDto createUserModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = createUserModel.UserName,
                FirstName =createUserModel.FirstName,
                LastName =createUserModel.LastName,
                NationalCode =createUserModel.NationalCode
                                           
            };


            IdentityResult addUserResult = await _userManager.CreateAsync(user,createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                createUserModel.RoleName = "Student";
                if (string.IsNullOrEmpty(createUserModel.RoleName) == false)
                {
                   
                    IdentityResult addResult = await _userManager.AddToRoleAsync(user, createUserModel.RoleName);

                    if (addResult.Succeeded && createUserModel.RoleName=="Student")
                    {

                        var student = new StudentDto
                        {
                            ApplicationUserId = user.Id,
                            StudentNumber = createUserModel.StudentNumber,
                            FatherName = createUserModel.FatherName,
                            FatherPhone = createUserModel.FatherPhone,
                            HomeAddress = createUserModel.HomeAddress,
                            HomePhone =createUserModel.HomePhone,
                            Phone =createUserModel.Phone,
                            TrackerPhone =createUserModel.TrackerPhone
                        };

                        _studentService.Add(student);

                    }
                }
               


               
            }


            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await _userManager.ConfirmEmailAsync(new ApplicationUser(),"");

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return Ok(result);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
            var result =  _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.UserName);
                if (appUser == null)
                    return NotFound();

                var userRole = await _userManager.GetRolesAsync(appUser);
                return  Ok(GenerateJwtToken(model.UserName, appUser,userRole.FirstOrDefault()));
            }

            return NotFound();
        }
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //IdentityResult result = await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            //if (!result.Succeeded)
            //{
            //    return GetErrorResult(result);
            //}

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return Ok();
                }

                return Ok();

            }

            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IActionResult> AssignRolesToUser( string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(appUser);

            var rolesNotExists = rolesToAssign.Except(roleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await _userManager.RemoveFromRolesAsync(appUser, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await _userManager.AddToRolesAsync(appUser, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/assignclaims")]
        [HttpPut]
        public async Task<IActionResult> AssignClaimsToUser(string id, [FromBody] List<ClaimBindingModel> claimsToAssign)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            //foreach (ClaimBindingModel claimModel in claimsToAssign)
            //{
            //    if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
            //    {

            //        await _userManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            //    }

            //    await _userManager.AddClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            //}

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/removeclaims")]
        [HttpPut]
        public async Task<IActionResult> RemoveClaimsFromUser(string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            //foreach (ClaimBindingModel claimModel in claimsToRemove)
            //{
            //    if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
            //    {
            //        await _userManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            //    }
            //}

            return Ok();
        }

        private string GenerateJwtToken(string email, ApplicationUser user,string role ="")
        {



            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),             
                new Claim("FullName" , user.FirstName + " " + user.LastName),
                new Claim("Role" , role),
                new Claim("SchoolId" , user?.SchoolId.ToString()),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        //[Authorize(Roles = "Admin")]
        [Route("createRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]Role role)
        {

            IdentityResult addUserResult = await roleManager.CreateAsync(role);
            if (addUserResult.Succeeded)
            {
                return Ok();

            }

            throw new Exception("نقش مورد نظر اضافه نشد");
        }

        [HttpGet("GetRoles")]
        [AllowAnonymous]

        public IActionResult GetRoles()
        {

            return Ok(roleManager.Roles);
        }
    }
}