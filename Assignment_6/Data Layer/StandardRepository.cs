using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Data_Layer
{
    class StandardRepository:Repository<Standard>, IStandardRepository
    {
        public StandardRepository():base(new SchoolDBEntities())
        {

        }
    }
}
