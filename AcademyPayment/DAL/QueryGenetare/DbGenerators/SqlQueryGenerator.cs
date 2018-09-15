using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.QueryGenetare.DbGenerators
{
    public class SqlQueryGenerator<T> : DbQueryGenerator<T> where T : class
    {
        public override int Delete(T item)
        {
            throw new NotImplementedException();
        }

        public override int Insert(T item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Select()
        {
            throw new NotImplementedException();
        }

        public override int Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
