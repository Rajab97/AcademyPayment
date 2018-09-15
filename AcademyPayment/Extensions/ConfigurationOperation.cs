using AcademyPayment.Configuration;
using AcademyPayment.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Extensions
{
    public static class ConfigurationOperation
    {
        private static DbConfiguration dbConfiguration;
        static ConfigurationOperation()
        {
            dbConfiguration = new AppConfiguration();
        }

        public static string GetConnectionString(string connectionName)
        {
            return dbConfiguration.GetConnectionString(connectionName);
        }

        /// <summary>
        /// Get provider factory
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetProviderName(string key)
        {
            //Read providerName from configuration file
            string provider = dbConfiguration.GetProviderName(key);

            if (String.IsNullOrEmpty(provider))
                throw new InvalidProviderException("This key is not valid !!!");

            return provider;
        }
    }
}
