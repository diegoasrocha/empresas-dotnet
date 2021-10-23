using ManageEnterprises.Domain.Models;
using System.Threading.Tasks;

namespace ManageEnterprises.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepo : IRepositoryAsync<User>
    {
        Task<User> GetByEmailIncludeInvestorsEnterprises(string email);
    }
}
