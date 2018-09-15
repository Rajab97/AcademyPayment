using AcademyPayment.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AcademyPayment.Exceptions;
using AcademyPayment.Extensions;

namespace AcademyPayment.DAL
{
    public abstract class _DbContext : IDbContext
    {
        private DbConnection dbConnection;
        private DbProviderFactory providerFactory;
        //private DbConfiguration dbConfiguration;

        public _DbContext(string connectionName,string providerKey)
        {
            if (String.IsNullOrEmpty(connectionName) || String.IsNullOrEmpty(providerKey))
                throw new ArgumentException("Argument shouldn't be null!!!", new ArgumentNullException());

            Connect(connectionName,providerKey);
        }

        /// <summary>
        /// Initialize DbSets
        /// </summary>
        /// 
        public abstract void Initializer();


        /// <summary>
        /// connect to database 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="providerKey"></param>
        private void Connect(string connectionName,string providerKey)
        {
            //Get provider factory

            providerFactory = GetDbFactory(providerKey);

            //Read connection from configuration file
            string connection = ConfigurationOperation.GetConnectionString(connectionName);

            if (String.IsNullOrEmpty(connection))
                throw new InvalidConnectionException("This connection name is not valid !!!");

            try
            {
                //Create DbConnection instance and open it
                dbConnection = providerFactory.CreateConnection();
                dbConnection.ConnectionString = connection;
                dbConnection.Open();
            }
            catch (DbException ex)
            {
                throw new InvalidConnectionException(ex.Message,ex);
            }
        }

        private DbProviderFactory GetDbFactory(string providerKey)
        {
            try
            {
                //Get provider factory from factories
                return DbProviderFactories.GetFactory(ConfigurationOperation.GetProviderName(providerKey));
            }
            catch (ArgumentException ex)
            {
                throw new InvalidProviderException(ex.Message, ex);
            }
        }

        //Dispose connection
        public virtual void Dispose()
        {
            dbConnection.Close();
        }
    }
}
