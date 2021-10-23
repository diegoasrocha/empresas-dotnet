using ManageEnterprises.Domain.Models;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace ManageEnterprises.Infrastructure.Repositories.Interfaces
{
    public interface IEnterpriseRepo : IRepositoryAsync<Enterprise>
    {
        IEnumerable<Enterprise> GetAllByFilter(string name, EnterpriseTypeEnum? enterpriseType);

        Task<Enterprise> GetByIdIncludeEnterpriseTypes(long id);

        Task<IEnumerable<Enterprise>> GetAllIncludeEnterpriseTypes();
    }
}
