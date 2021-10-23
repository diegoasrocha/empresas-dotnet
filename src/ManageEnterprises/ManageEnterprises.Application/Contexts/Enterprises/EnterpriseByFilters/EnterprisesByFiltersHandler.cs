using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using MediatR; 
using System.Collections.Generic; 
using System.Threading;
using System.Threading.Tasks;

namespace ManageEnterprises.Application.Contexts.Enterprises.EnterpriseByFilters
{
    public class EnterprisesByFiltersHandler : IRequestHandler<EnterprisesByFiltersQuery, ICollection<EnterpriseFiltersDTO>>
    {
        private readonly IEnterpriseRepo enterpriseRepo;

        public EnterprisesByFiltersHandler(IEnterpriseRepo enterpriseRepo)
        {
            this.enterpriseRepo = enterpriseRepo;
        }

        public Task<ICollection<EnterpriseFiltersDTO>> Handle(EnterprisesByFiltersQuery request, CancellationToken cancellationToken)
        {
            ICollection<EnterpriseFiltersDTO> enterpriseFiltersDTOs = new List<EnterpriseFiltersDTO>();

            var temp = this.enterpriseRepo.GetAllByFilter(request.Name, request.EnterpriseType);


            IEnumerable<Enterprise> enterprises = temp;

            foreach (var enterprise in enterprises)
            {
                enterpriseFiltersDTOs.Add(new EnterpriseFiltersDTO(enterprise));
            }

            return Task.FromResult(enterpriseFiltersDTOs);
        }
    }
}
