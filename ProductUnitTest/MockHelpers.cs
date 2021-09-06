using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ProductUnitTest
{
    public class MockHelpers
    {
        public static StringBuilder LogMessage = new StringBuilder(); 

        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class 
        { 
            var store = new Mock<IUserStore<TUser>>(); 
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null); 
            mgr.Object.UserValidators.Add(new UserValidator<TUser>()); 
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>()); return mgr;
        }

        public static ControllerContext FakeControllerContext(bool isLoggedUser = true)
        {
            var claims = new List<Claim>()
            {
                new (ClaimTypes.Name, "username"), 
                new (ClaimTypes.NameIdentifier, "userId"),
                new ("name", "Ola Nordman"),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var user = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext() { User = (isLoggedUser ? user : null)! };
            return new ControllerContext() { HttpContext = httpContext, };
        }
    }
}

