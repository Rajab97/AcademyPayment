using AcademyPayment.DAL.QueryGenetare.DbGenerators;
using AcademyPayment.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.QueryGenetare
{
    public static class DbQueryGenerators<T> where T:class
    {
        private static Dictionary<DbProviderFactory, Type> queryGenerators;

        static DbQueryGenerators()
        {
            FillQueryGenerators();
        }

        /// <summary>
        /// Get DbQueryGenerator by dbProviderFactory parameter
        /// </summary>
        /// <param name="dbProviderFactory"></param>
        /// <returns></returns>
        public static DbQueryGenerator<T> GetQueryGenerator(DbProviderFactory dbProviderFactory)
        {
            return InitializeQueryGenerator(FindQueryGenerator(dbProviderFactory));
        }

        /// <summary>
        /// Find DbQueryGenerator From Dictionary
        /// </summary>
        /// <param name="dbProviderFactory"></param>
        /// <returns></returns>
        private static Type  FindQueryGenerator(DbProviderFactory dbProviderFactory)
        {
            if (dbProviderFactory == null)
                throw new ArgumentException("Value cannot be null", new ArgumentNullException());

            KeyValuePair<DbProviderFactory, Type> providerFactory = queryGenerators.FirstOrDefault(m => m.Key.Equals(dbProviderFactory));

            if (providerFactory.Key == default(DbProviderFactory))
                throw new InvalidProviderException("This provider was not found !!!");

            return providerFactory.Value;
        }

        /// <summary>
        /// Initialize DbQueryGenerator
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static DbQueryGenerator<T> InitializeQueryGenerator(Type type )
        {
            DbQueryGenerator<T> dbQueryGenerator = Activator.CreateInstance(type) as DbQueryGenerator<T>;

            if (dbQueryGenerator == null)
                throw new InvalidQueryGeneratorException("Query generator not instantiated !!!");

            return dbQueryGenerator;
        }

        /// <summary>
        /// Add All Query Generator to Dictionary. This method call at static constructor only once 
        /// </summary>
        private static void FillQueryGenerators()
        {

            queryGenerators = new Dictionary<DbProviderFactory, Type>();

            queryGenerators.Add(GetDbProviderFactory("System.Data.SqlClient"), typeof(SqlQueryGenerator<T>));
        }

        private static DbProviderFactory GetDbProviderFactory(string providerName)
        {
            try
            {
                return DbProviderFactories.GetFactory(providerName);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidProviderException(ex.Message, ex);
            }

        }

    }
}
