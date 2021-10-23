using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEnterprises.Domain.Models
{
    [Table("EnterpriseTypes")]
    public class EnterpriseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public EnterpriseTypeEnum Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }


        public virtual IEnumerable<Enterprise> Enterprises { get; set; }
    }

    public enum EnterpriseTypeEnum : byte
    {
        [Description("Agro")]
        Agro         = 1,
        
        [Description("Aviation")]                     
        Aviation     = 2,
        
        [Description("Biotech")]                     
        Biotech      = 3,
        
        [Description("Eco")]                     
        Eco          = 4,
        
        [Description("Ecommerce")]                     
        Ecommerce    = 5,
        
        [Description("Education")]                     
        Education    = 6,
        
        [Description("Fashion")]                     
        Fashion      = 7,
        
        [Description("Fintech")]                     
        Fintech      = 8,
        
        [Description("Food")]                     
        Food         = 9,
        
        [Description("Games")]                     
        Games       = 10,
        
        [Description("Health")]                    
        Health      = 11,
        
        [Description("IOT")]                    
        IOT         = 12,
        
        [Description("Logistics")]                    
        Logistics   = 13,
        
        [Description("Media")]                    
        Media       = 14,
        
        [Description("Mining")]                    
        Mining      = 15,
        
        [Description("Products")]                    
        Products    = 16,
        
        [Description("Real Estate")]                    
        Real_Estate = 17,
        
        [Description("Service")]                      
        Service     = 18,
        
        [Description("Smart City")]                    
        Smart_City  = 19,
        
        [Description("Social")]                     
        Social      = 20,
        
        [Description("Software")]                    
        Software    = 21,
        
        [Description("Technology")]                    
        Technology  = 22,
        
        [Description("Tourism")]                     
        Tourism     = 23,
        
        [Description("Transport")]                    
        Transport   = 24
    }
} 