using ManageEnterprises.Application.DTOs;
using MediatR; 
using System.Collections.Generic; 

namespace ManageEnterprises.Application.Contexts.Enterprises.AllEnterprises
{
    public class AllEnterprisesQuery : IRequest<ICollection<EnterpriseDTO>>
    {
    }
}
