using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Tcm.Domain.IdentityModel;

namespace Tcm.Persistence.Ef.Identity
{
    public class AspIdentityServices
    {
      
        public class ApplicationRoleManager : RoleManager<Role>
        {
            public ApplicationRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
            {
            }
        }
        public class ApplicationRoleStore : RoleStore<Role, TcmContext, int, UserRole, RoleClaim>
        {
            public ApplicationRoleStore(TcmContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }


        }
        public class ApplicationSignInManager : SignInManager<ApplicationUser>
        {
            public ApplicationSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
            {
            }
        }
        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
            {
            }
        }
        public class ApplicationUserStore : UserStore<ApplicationUser, Role, TcmContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
        {
            public ApplicationUserStore(TcmContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }


        }



    }
}
