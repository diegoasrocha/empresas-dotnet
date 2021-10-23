using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ManageEnterprises.Application.Contexts.Users.SignIn;
using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ManageEnterprises.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        private IConfiguration config;

        public UsersController(IMediator mediator, IConfiguration config)
        {
            this.mediator = mediator;
            this.config = config;
        }

        [HttpPost]
        [Route("auth/sign_in")]
        public ActionResult SignIn(SignInDTO user)
        {
            User result = this.mediator.Send(new SignInCommand(user.Email, user.Password)).Result;

            if (result == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    errors = new[] { "Invalid login credentials. Please try again." }
                });
            }
            else
            {
                var claims = new[] { 
                    new Claim("Id", result.Id.ToString())
                   };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(claims: claims, signingCredentials: signIn);
                 
                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
                 
                Response.Headers.Add("access-token", tokenStr);
                Response.Headers.Add("client", "client");
                Response.Headers.Add("uid", result.Email);

                return Ok(new
                {
                    investor = result.Investor != null ? new InvestorDTO(result.Investor, result.Email) : null,
                    enterprise = result.Enterprise != null ? new EnterpriseDTO(result.Enterprise) : null,
                    sucesso = true
                });
            }
        }
    }
}
