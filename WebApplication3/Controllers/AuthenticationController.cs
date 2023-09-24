using Domainlayer.Model;
using Domainlayer.Model.Authentication.login;
using Domainlayer.Model.Authentication.signup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
      

            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)

        {
            _userManager= userManager;
            _roleManager= roleManager;
            _configuration= configuration;
        }
            

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult>Registeruser([FromBody] register Register, string role)
        {
            //check user exist
            var userExist = await _userManager.FindByEmailAsync(Register.Email);
            if (userExist != null) 
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new response { status = "Error", message = "user already exists" });

            }

          

            IdentityUser user= new()

            {
                Email = Register.Email,
                SecurityStamp=Guid.NewGuid().ToString(),
                UserName= Register.Username
               

  
             };
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user,Register.Password);

                if (!result.Succeeded) {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                            new response { status = "Error", message = "user failed to create" });



                }

                await _userManager.AddToRoleAsync(user,role);
                return StatusCode(StatusCodes.Status200OK,
                    new response { status = "success", message = "user created successfully !" });

              
            }

          else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new response { status = "Error", message = "This Role doesn't exists" });

            }


               

        }


      
        [HttpPost]

        [Route("login")]

        public async Task<IActionResult> Login([FromBody] login login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password)) 
            {
                var authClaims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name,user.UserName),
                    new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),


                };
                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role,role));
                }

                var jwtToken = GetToken (authClaims);

                return Ok(new

                {
                    token =new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration =jwtToken.ValidTo



                });

               
            
            
            }
            return Unauthorized();

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningkey, SecurityAlgorithms.HmacSha256)

                );

            return token;


        }


    }
}

