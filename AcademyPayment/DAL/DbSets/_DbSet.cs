using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.DbSets
{
    public class _DbSet<T> :IConnect, IDbSet<T> where T:class
    {
        DbConnection IConnect.dbConnection { get; set; }
        DbProviderFactory IConnect.providerFactory { get; set; }
        public int Add(T Element)
        {
            throw new NotImplementedException();
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public int Remove(T Element)
        {
            throw new NotImplementedException();
        }

        public int Update(T Element)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
