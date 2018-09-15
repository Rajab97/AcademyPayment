using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Threading.Tasks;
using AcademyPayment.Exceptions;
using AcademyPayment.DAL.QueryGenetare.DbGenerators;

namespace AcademyPayment.DAL.QueryGenetare
{
    public abstract class DbQueryGenerator<T> : IQueryGenerator<T> where T:class
    {
        public abstract int Delete(T item);


        public abstract int Insert(T item);


        public abstract IEnumerable<T> Select();


        public abstract int Update(T item);
        
    }
}
