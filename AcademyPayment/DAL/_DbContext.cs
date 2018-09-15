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
using AcademyPayment.DAL.DbSets;
using System.Reflection;

namespace AcademyPayment.DAL
{
    public abstract class _DbContext : IDbContext , IConnect
    {
     

        DbConnection IConnect.dbConnection { get; set; }
        DbProviderFactory IConnect.providerFactory { get; set; }

        //private DbConfiguration dbConfiguration;

        public _DbContext(string connectionName)
        {
            if (String.IsNullOrEmpty(connectionName))
                throw new ArgumentException("Argument shouldn't be null!!!", new ArgumentNullException());

            Connect(connectionName);
        }

        /// <summary>
        /// Initialize DbSets
        /// </summary>
        /// 
        public void Initialize(_DbContext context)
        {
            #region Exs
            //Type derivedType = this.GetType();

            //IEnumerable<PropertyInfo> dbSets = GetDbSets(derivedType);

            //foreach (PropertyInfo dbSet in dbSets)
            //{
            //    IConnect dbSetInstance = (IConnect)Activator.CreateInstance(dbSet.GetType());


            //    //Burada qaldig
            //    foreach (PropertyInfo dbSetProperty in dbSet.GetType().GetProperties())
            //    {
            //        if (dbSetProperty.GetType() == ((IConnect)this).dbConnection.GetType())
            //        {
            //            dbSetInstance.dbConnection = ((IConnect)this).dbConnection;
            //        }
            //        else if (dbSetProperty.GetType() == ((IConnect)this).providerFactory.GetType())
            //        {
            //            dbSetInstance.providerFactory = ((IConnect)this).providerFactory;
            //        }
            //    }
            //}
            #endregion
            IEnumerable<PropertyInfo> InitializedDbSets = InitializeDbSets(context);
            //Burda qaldim
        }
        private IEnumerable<PropertyInfo> InitializeDbSets(_DbContext derivedClass)
        {
            IEnumerable<PropertyInfo> properties = derivedClass.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo item in properties)
            {
                if (item.PropertyType.IsGenericType)
                {
                    Type GenericDefinition = item.PropertyType.GetGenericTypeDefinition();
                    if (GenericDefinition == typeof(_DbSet<>))
                    {
                        Type[] types = item.PropertyType.GetGenericArguments();
                        Type constructed = GenericDefinition.MakeGenericType(types);
                        item.SetValue(derivedClass, Activator.CreateInstance(constructed));
                        yield return item;
                    }
                }
            }
        }
        /// <summary>
        /// connect to database 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="providerKey"></param>
        private void Connect(string connectionName)
        {
            //Get provider factory

            ((IConnect)this).providerFactory = GetDbFactory(connectionName);

            //Read connection from configuration file
            string connection = ConfigurationOperation.GetConnectionString(connectionName);

            if (String.IsNullOrEmpty(connection))
                throw new InvalidConnectionException("This connection name is not valid !!!");

            try
            {
                //Create DbConnection instance and open it
                ((IConnect)this).dbConnection = ((IConnect)this).providerFactory.CreateConnection();
                ((IConnect)this).dbConnection.ConnectionString = connection;
                ((IConnect)this).dbConnection.Open();
            }
            catch (DbException ex)
            {
                throw new InvalidConnectionException(ex.Message,ex);
            }
        }

        private DbProviderFactory GetDbFactory(string connectionName)
        {
            try
            {
                //Get provider factory from factories
                return DbProviderFactories.GetFactory(ConfigurationOperation.GetProviderName(connectionName));
            }
            catch (ArgumentException ex)
            {
                throw new InvalidProviderException(ex.Message, ex);
            }
        }

        //Dispose connection
        public virtual void Dispose()
        {
            ((IConnect)this).dbConnection.Close();
        }
    }
}
