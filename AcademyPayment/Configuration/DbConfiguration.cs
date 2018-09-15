using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Configuration
{
    public abstract class DbConfiguration : IConfiguration
    {
        public abstract string GetProviderName(string connectionName);

        public abstract string GetConnectionString(string connectionName);

    }
}
