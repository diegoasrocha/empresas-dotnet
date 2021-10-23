using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEnterprises.Domain.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {         
        public long InvestorId { get; set; }
        public virtual Investor Investor { get; set; }   
        
         
        public long EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
