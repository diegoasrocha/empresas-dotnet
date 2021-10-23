using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEnterprises.Domain.Models
{
    public class User
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 
        
        [Required]
        [MinLength(6)]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(150)]
        public string Password { get; set; }

        public virtual Investor Investor  { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}
