using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using MediatR; 
using System.Collections.Generic; 

namespace ManageEnterprises.Application.Contexts.Enterprises.EnterpriseByFilters
{
    public class EnterprisesByFiltersQuery : IRequest<ICollection<EnterpriseFiltersDTO>>
    {
        public EnterpriseTypeEnum? EnterpriseType { get; set; }

        public string Name { get; set; }

        public EnterprisesByFiltersQuery(EnterpriseTypeEnum? enterpriseType, string name)
        {
            EnterpriseType = enterpriseType;
            Name = name;
        }
    }
}
