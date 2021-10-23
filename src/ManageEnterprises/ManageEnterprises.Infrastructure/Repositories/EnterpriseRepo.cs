using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.DBConfiguration.EFCore;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageEnterprises.Infrastructure.Repositories
{
    public class EnterpriseRepo : RepositoryAsync<Enterprise>, IEnterpriseRepo
    {
        public EnterpriseRepo(ApplicationContext dbContext) : base(dbContext) { }

        public  IEnumerable<Enterprise> GetAllByFilter(string name, EnterpriseTypeEnum? enterpriseType)
        {
            return 
                dbSet.Include(e => e.EnterpriseType)
                     .Where(e =>
                        (
                            ( (enterpriseType.HasValue && e.EnterpriseTypeId == enterpriseType.Value) || !enterpriseType.HasValue)
                                &&
                            ( (!string.IsNullOrEmpty(name) && e.Name.ToLower().Contains((name).ToLower()) || string.IsNullOrEmpty(name)) )
                        )
                        && ( enterpriseType.HasValue || !string.IsNullOrEmpty(name))
                         
                    ).ToList();
        }

        public async Task<Enterprise> GetByIdIncludeEnterpriseTypes(long id)
        {
            return await dbSet.Include(e => e.EnterpriseType)
                              .Where(e => e.Id == id)
                              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Enterprise>> GetAllIncludeEnterpriseTypes()
        {
            return await dbSet.Include(e => e.EnterpriseType).ToListAsync();
        }
    }
}
