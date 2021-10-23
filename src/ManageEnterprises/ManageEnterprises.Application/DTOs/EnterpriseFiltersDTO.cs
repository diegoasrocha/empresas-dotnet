
using ManageEnterprises.Domain.Models;

namespace ManageEnterprises.Application.DTOs
{ 
    public class EnterpriseFiltersDTO
    {
        public EnterpriseFiltersDTO(Enterprise enterprise)
        {
            this.id = enterprise.Id;
            this.email_enterprise = enterprise.Email;
            this.facebook = enterprise.Facebook;
            this.twitter = enterprise.Twitter;
            this.linkedin = enterprise.Linkedin;
            this.phone = enterprise.Phone;
            this.own_enterprise = enterprise.OwnEnterprise;
            this.enterprise_name = enterprise.Name;
            this.photo = enterprise.Photo;
            this.description = enterprise.Description;
            this.city = enterprise.City;
            this.country = enterprise.Country;
            this.value = enterprise.Value;
            this.share_price = enterprise.SharePrice;
            this.enterprise_type = new EnterpriseTypeDTO
            {
                id = (byte)enterprise.EnterpriseType.Id,
                enterprise_type_name = enterprise.EnterpriseType.Name
            };
        }

        public long id { get; set; }
        public string email_enterprise { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string linkedin { get; set; }
        public string phone { get; set; }
        public bool own_enterprise { get; set; }
        public string enterprise_name { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public decimal value { get; set; }
        public decimal share_price { get; set; }
        public EnterpriseTypeDTO enterprise_type { get; set; }
    }   
}
