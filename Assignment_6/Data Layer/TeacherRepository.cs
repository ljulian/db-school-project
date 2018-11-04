using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Data_Layer
{
    class TeacherRepository:Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(): base(new SchoolDBEntities())
        {

        }
    }
}
