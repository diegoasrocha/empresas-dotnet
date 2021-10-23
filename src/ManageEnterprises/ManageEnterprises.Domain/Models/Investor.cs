using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEnterprises.Domain.Models
{
    [Table("Investors")]
    public class Investor
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Name { get; set; } 

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Country { get; set; }

        [Required] 
        public decimal Balance { get; set; }

        public string Photo { get; set; }

        [Required]
        public decimal PortfolioValue { get; set; }

        [Required]
        public bool FirstAccess { get; set; }

        [Required]
        public bool SuperAngel { get; set; }


        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        
        public virtual IEnumerable<Portfolio> Portfolio { get; set; }
    }
}
