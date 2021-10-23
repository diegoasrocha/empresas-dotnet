using ManageEnterprises.Application.DTOs; 
using MediatR; 

namespace ManageEnterprises.Application.Contexts.Enterprises.EnterprisesById
{
    public class EnterpriseByIdQuery : IRequest<EnterpriseDTO>
    {
        public long EnterpriseId { get; set; }

        public EnterpriseByIdQuery(long enterpriseId)
        {
            EnterpriseId = enterpriseId;
        }
    }
}
