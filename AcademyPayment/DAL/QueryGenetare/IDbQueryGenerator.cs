using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.QueryGenetare
{
    internal interface IQueryGenerator<T>
    {
        int Insert(T item);
        int Delete(T item);
        int Update(T item);
        IEnumerable<T> Select();
    }
}
