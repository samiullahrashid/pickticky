using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PickyTicky.Helper;
using PickyTicky.Models;

namespace PickyTicky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
       
        public IConfiguration _config;
        public AuthenticationController(IConfiguration config)
        {
            _config = config;
           
        }
        private string GetJetToken(string userEmail, string userId)
        {
            string securityKey = _config.GetSection("EncryptionKey").Value;
            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //add claims
            var claims = new List<Claim>();
           
            claims.Add(new Claim("Id", userId));
            claims.Add(new Claim("Email", userEmail));

            //create token
            var token = new JwtSecurityToken(
                    issuer: "pickyticky.pk",
                    audience: "shoper",
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signingCredentials,
                    claims: claims
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult AuthenticateUser(AuthModel model)
        {
            if (model.email == null)
                return BadRequest();

            return Ok(
                GetJetToken
                (
                    "sami@bravinn.com"
                    ,                       
                    EncryptionHelper.Encrypt
                    ( "126", _config.GetSection("EncryptionKey").Value )
                ));

        }
    }
}