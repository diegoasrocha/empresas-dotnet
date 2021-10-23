using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using MediatR; 
using System.Threading;
using System.Threading.Tasks;

namespace ManageEnterprises.Application.Contexts.Enterprises.EnterprisesById
{
    public class EnterpriseByIdHandler : IRequestHandler<EnterpriseByIdQuery, EnterpriseDTO>
    {
        private readonly IEnterpriseRepo enterpriseRepo;

        public EnterpriseByIdHandler(IEnterpriseRepo enterpriseRepo)
        {
            this.enterpriseRepo = enterpriseRepo;
        }

        public Task<EnterpriseDTO> Handle(EnterpriseByIdQuery request, CancellationToken cancellationToken)
        {  
            Enterprise enterprise = this.enterpriseRepo.GetByIdIncludeEnterpriseTypes(request.EnterpriseId).Result;
              
            return Task.FromResult(enterprise != null ? new EnterpriseDTO(enterprise) : null);
        }
    }
}
