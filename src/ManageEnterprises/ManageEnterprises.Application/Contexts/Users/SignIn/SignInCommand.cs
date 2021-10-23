using ManageEnterprises.Domain.Models;
using MediatR; 

namespace ManageEnterprises.Application.Contexts.Users.SignIn
{
    public class SignInCommand : IRequest<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
