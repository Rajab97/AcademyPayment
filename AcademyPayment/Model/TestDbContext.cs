using AcademyPayment.DAL;
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
            base.Initialize();
        }
    }
}
