using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Configuration
{
    public class AppConfiguration : DbConfiguration
    {
        public override string GetConnectionString(string connectionName)
        {
             return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public override string GetProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

     
    }
}
