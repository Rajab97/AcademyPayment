using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL
{
    internal interface IConnect
    {
         DbConnection dbConnection { get; set; }
         DbProviderFactory providerFactory { get; set; }
    }
}
