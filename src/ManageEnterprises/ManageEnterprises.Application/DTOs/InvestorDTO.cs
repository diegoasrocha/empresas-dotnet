

using ManageEnterprises.Domain.Models;
using System.Linq;

namespace ManageEnterprises.Application.DTOs
{
    public class InvestorDTO
    {
        public InvestorDTO(Investor investor, string email)
        {
            this.id = investor.Id;
            this.investor_name = investor.Name;
            this.email = email;
            this.city = investor.City;
            this.country = investor.Country;
            this.balance = investor.Balance;
            this.photo = investor.Photo;
            this.portfolio = new PortfolioDTO(investor.Portfolio.ToList());
            this.portfolio_value = investor.PortfolioValue;
            this.first_access = investor.FirstAccess;
            this.super_angel = investor.SuperAngel;
        }

        public long id { get; set; }
        public string investor_name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public decimal balance { get; set; }
        public string photo { get; set; }
        public PortfolioDTO portfolio { get; set; }
        public decimal portfolio_value { get; set; }
        public bool first_access { get; set; }
        public bool super_angel { get; set; }

    }

}
