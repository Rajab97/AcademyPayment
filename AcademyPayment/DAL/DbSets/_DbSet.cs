using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.DbSets
{
    public class _DbSet<T> : IDbSet<T> where T:class
    {
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
