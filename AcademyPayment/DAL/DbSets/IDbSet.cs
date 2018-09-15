using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.DAL.DbSets
{
    public interface IDbSet<T>:IEnumerable<T>
    {
        int Add(T Element);
        int Remove(T Element);
        int Update(T Element);
        IEnumerable<T> Read();
    }
}
