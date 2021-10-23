using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.DBConfiguration.EFCore;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManageEnterprises.Infrastructure.Repositories
{
    public class UserRepo : RepositoryAsync<User>, IUserRepo
    {
        public UserRepo(ApplicationContext dbContext) : base(dbContext) { }

        public async Task<User> GetByEmailIncludeInvestorsEnterprises(string email)
        {
            return await dbSet.Include(u => u.Investor)
                              .Include(u => u.Enterprise)
                              .Include(u => u.Investor.Portfolio)
                              .Include("Investor.Portfolio.Enterprise")
                              .Where(u => u.Email.ToLower() == email.ToLower())
                              .FirstOrDefaultAsync();
        }
    }
}
