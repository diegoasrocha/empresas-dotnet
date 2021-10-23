using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using MediatR; 
using System.Threading;
using System.Threading.Tasks;

namespace ManageEnterprises.Application.Contexts.Users.SignIn
{
    public class SignInHandler : IRequestHandler<SignInCommand, User>
    {
        private IUserRepo userRepo;

        public SignInHandler(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            User user = userRepo.GetByEmailIncludeInvestorsEnterprises(request.Email).Result;

            return Task.FromResult( (user?.Password == request.Password) ? user : null );
        }
    }
}
