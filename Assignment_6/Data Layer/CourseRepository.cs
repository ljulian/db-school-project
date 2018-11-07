using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Data_Layer
{
    class CourseRepository: Repository<Course>, ICourseRepository
    {
        public CourseRepository() : base(new SchoolDBEntities())
        {

        }
    }
}
