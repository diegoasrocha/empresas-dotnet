using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEnterprises.Domain.Models
{
    [Table("Enterprises")]
    public class Enterprise
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Linkedin { get; set; }

        public string Phone { get; set; }

        [Required]
        public bool OwnEnterprise { get; set; }
 
        public string Photo { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public int Shares { get; set; }

        [Required]
        public decimal SharePrice { get; set; }

        [Required]
        public int OwnShares { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Country { get; set; }   


        [Required]
        [ForeignKey(nameof(EnterpriseType))]
        public EnterpriseTypeEnum EnterpriseTypeId { get; set; }
        public virtual EnterpriseType EnterpriseType { get; set; }
        

        [ForeignKey(nameof(User))]
        public long? UserId { get; set; }
        public virtual User User { get; set; }


        public IEnumerable<Portfolio> Portfolio { get; set; }
    }
}
