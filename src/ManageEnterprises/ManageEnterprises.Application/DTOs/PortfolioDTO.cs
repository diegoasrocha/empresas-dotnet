using ManageEnterprises.Domain.Models;
using System.Collections.Generic; 

namespace ManageEnterprises.Application.DTOs
{
    public class PortfolioDTO
    {
        public PortfolioDTO(ICollection<Portfolio> portfolio)
        {
            this.enterprises_number = portfolio?.Count ?? 0;
            this.enterprises = new List<EnterpriseDTO>();

            foreach (var item in portfolio)
            {
                enterprises.Add(new EnterpriseDTO(item.Enterprise));
            }
        }

        public int enterprises_number { get; set; }
        public List<EnterpriseDTO> enterprises { get; set; }

    }
}
