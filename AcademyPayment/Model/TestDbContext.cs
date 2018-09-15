using AcademyPayment.DAL;
using AcademyPayment.DAL.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPayment.Model
{
    internal class TestDbContext:_DbContext
    {
        public TestDbContext() : base("con")
        {
            base.Initialize(this);
        }
        public _DbSet<Person> People { get; set; }
        public _DbSet<Car> Cars { get; set; }
        public string Default { get; set; }
    }
}
