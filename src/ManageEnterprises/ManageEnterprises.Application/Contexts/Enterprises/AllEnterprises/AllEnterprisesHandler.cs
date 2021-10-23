using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using MediatR; 
using System.Collections.Generic; 
using System.Threading;
using System.Threading.Tasks;

namespace ManageEnterprises.Application.Contexts.Enterprises.AllEnterprises
{
    public class AllEnterprisesHandler : IRequestHandler<AllEnterprisesQuery, ICollection<EnterpriseDTO>>
    {
        private readonly IEnterpriseRepo enterpriseRepo;

        public AllEnterprisesHandler(IEnterpriseRepo enterpriseRepo)
        {
            this.enterpriseRepo = enterpriseRepo;
        }

        public Task<ICollection<EnterpriseDTO>> Handle(AllEnterprisesQuery request, CancellationToken cancellationToken)
        {
            ICollection<EnterpriseDTO> enterpriseDTOs = new List<EnterpriseDTO>();

            IEnumerable<Enterprise> enterprises = this.enterpriseRepo.GetAllIncludeEnterpriseTypes().Result;

            foreach (var enterprise in enterprises)
            {
                enterpriseDTOs.Add(new EnterpriseDTO(enterprise));
            }

            return Task.FromResult(enterpriseDTOs); 
        }
    }
}
