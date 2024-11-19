using CybageConnect_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CybageConnect_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CybageConnectController : ControllerBase
    {
        CybageConnectDbContext cybConnect = new CybageConnectDbContext();


        [HttpPost("Register")]
        public string Register([FromBody] RegistrationModel user)
        {
            UserRegistration newUser = new UserRegistration
            {
                FullName = user.FullName,
                Email = user.Email,
                UserPassword = user.UserPassword,
                MobileNumber = user.MobileNumber,
                UserName = user.UserName
            };


            cybConnect.UserRegistrations.Add(newUser);
            cybConnect.SaveChanges();

            return "Registration Success";
        }

        [HttpPost("Login")]
        public bool Login([FromBody] UserLoginModel loginUser)
        { 
           bool status = false;
            var UserName= loginUser.UserName;
            var Password = loginUser.UserPassword;

            var userdata = cybConnect.UserRegistrations.SingleOrDefault(user=> user.UserName == UserName && user.UserPassword== Password);

            if (userdata != null)
            {
                status = true;
                
            }
            return status;
        }
    }
}
