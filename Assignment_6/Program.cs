using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_6.Business_Layer;

namespace Assignment_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // AsNoTracking. Ignore changes made of Dbcontext
            //where: function looks for standard. 
            IBusinessLayer businessLayer = new BusinessLayer();

            //addTeacher(businessLayer, "Mike Brown", 2);




            print_all_standards(businessLayer);
            print_all_teachers(businessLayer);
            print_all_students(businessLayer);

            Console.ReadLine();
        }

        static void addTeacher(IBusinessLayer bl, string teacherName, 
                               int standardID)
        {
            Teacher newTeach = new Teacher()
            {
                TeacherName = teacherName
            };

            Standard std = bl.GetStandardByID(standardID);
            if (std != null)
            {
                // TODO Just set the standardID
                // TODO ask about this case.
                newTeach.Standard = std;
            }
            else
            {
                newTeach.Standard = new Standard()
                {
                    StandardName = "New Standard 1"
                };
            }
            bl.AddTeacher(newTeach);
        }

        static void print_all_standards(IBusinessLayer bl)
        {
            IList<Standard> st = bl.GetAllStandards();
            foreach(var elm in st)
            {
                string message = "Name: {0}";
                Console.WriteLine(string.Format(message, elm.StandardName));
            }
        }

        static void print_all_students(IBusinessLayer bl)
        {
            IList<Student> st = bl.GetAllStudents();
            foreach (var elm in st)
            {
                string message = "Name: {0}";
                Console.WriteLine(string.Format(message, elm.StudentName));
            }
        }

        static void print_all_teachers(IBusinessLayer bl)
        {
            IList<Teacher> st = bl.GetAllTeachers();
            foreach (var elm in st)
            {
                string message = "Name: {0}";
                Console.WriteLine(string.Format(message, elm.TeacherName));
            }
        }
    }
}
