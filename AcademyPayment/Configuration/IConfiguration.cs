using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Configuration
{
    public interface IConfiguration
    {
        string GetProviderName(string connectionName);
    }
}
