using System.IO;
using Microsoft.Extensions.Configuration;

namespace ManageEnterprises.Infrastructure.DBConfiguration
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                var path = $"{Directory.GetParent(Directory.GetCurrentDirectory())}\\ManageEnterprises.Infrastructure";

                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
