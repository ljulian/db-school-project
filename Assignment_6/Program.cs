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
            bool menuSwitch = true;
            addTeacher(businessLayer, "Jim Neutron", 2);
            while (menuSwitch)
            {
                Console.WriteLine("1) See the list of courses");
                Console.WriteLine("2) Update the course");
                Console.WriteLine("3) Delete the course");
                Console.WriteLine("4) Create the course");
                Console.WriteLine("5) See the list of teachers");
                Console.WriteLine("6) Update teachers");
                Console.WriteLine("7) Delete teachers");
                Console.WriteLine("8) Create teachers");
                Console.WriteLine("9) See the list of courses of a teacher");
                Console.WriteLine("10) End the program");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        IList<Course> courses = businessLayer.GetAllCourses();
                        foreach (Course course in courses)
                        {
                            Console.WriteLine("Course Name: {0}, Course ID: {1}, Assigned Teacher ID: {2}",
                                              course.CourseName, course.CourseId, course.TeacherId);
                        }
                        break;

                    case 2:
                        ModifyCourse(businessLayer);
                        break;

                    case 3:
                        Console.WriteLine("1) Delete by searching course ID");
                        Console.WriteLine("2) Delete by searching course name");
                        int selection3 = Convert.ToInt32(Console.ReadLine());
                        switch (selection3)
                        {
                            case 1:
                                Console.Write("Enter the ID of the course: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Course course = businessLayer.GetCourseByID(id);
                                businessLayer.RemoveCourse(course);
                                break;
                            case 2:
                                Console.Write("Enter the name of the course: ");
                                string courseName = Console.ReadLine();
                                Course course2 = businessLayer.GetCourseByName(courseName);
                                businessLayer.RemoveCourse(course2);
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("Enter the name of the new course: ");
                        string newCourseName = Console.ReadLine();
                        Course newCourse = new Course { CourseName = newCourseName};
                        businessLayer.AddCourse(newCourse);
                        break;

                    case 5:
                        IList<Teacher> teachers = businessLayer.GetAllTeachers();
                        foreach (Teacher teacher in teachers)
                        {
                            Console.WriteLine("Teacher Name: " + teacher.TeacherName + ", Teacher ID: " + teacher.TeacherId);
                        }
                        break;
                    case 6:
                        Console.WriteLine("1) Update by searching teacher ID");
                        Console.WriteLine("2) Update by searching teacher name");
                        int searchSelection = Convert.ToInt32(Console.ReadLine());
                        switch (searchSelection)
                        {
                            case 1:
                                Console.Write("Enter the ID of the teacher: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Teacher teacher = businessLayer.GetTeacherByID(id);
                                Console.Write("Enter the new Name for " + teacher.TeacherName + ": ");
                                string newName = Console.ReadLine();
                                teacher.TeacherName = newName;
                                businessLayer.UpdateTeacher(teacher);
                                break;
                            case 2:
                                Console.Write("Enter the name of the teacher: ");
                                string teacherName = Console.ReadLine();
                                Teacher teacher2 = businessLayer.GetTeacherByName(teacherName);
                                Console.Write("Enter the new Name for " + teacher2.TeacherName + ": ");
                                string newName2 = Console.ReadLine();
                                teacher2.TeacherName = newName2;
                                businessLayer.UpdateTeacher(teacher2);
                                break;
                        }
                        break;
                    case 7:
                        Console.WriteLine("1) Delete by searching course ID");
                        Console.WriteLine("2) Delete by searching course name");
                        int deleteSelection = Convert.ToInt32(Console.ReadLine());
                        switch (deleteSelection)
                        {
                            case 1:
                                Console.Write("Enter the ID of the teacher: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Teacher teacher = businessLayer.GetTeacherByID(id);
                                businessLayer.RemoveTeacher(teacher);
                                break;
                            case 2:
                                Console.Write("Enter the name of the teacher: ");
                                string teacherName = Console.ReadLine();
                                Teacher teacher2 = businessLayer.GetTeacherByName(teacherName);
                                businessLayer.RemoveTeacher(teacher2);
                                break;
                        }
                        break;
                    case 8:
                        Console.Write("Enter the name of the new teacher: ");
                        string newTeacherName = Console.ReadLine();
                        Teacher newTeacher = new Teacher { TeacherName = newTeacherName };
                        businessLayer.AddTeacher(newTeacher);
                        newTeacher = null;
                        break;
                    case 9:
                        Console.WriteLine("1) Choose a teacher by searching teacher ID");
                        Console.WriteLine("2) Choose a teacher by searching teacher name");
                        int searchSelection2 = Convert.ToInt32(Console.ReadLine());
                        switch (searchSelection2)
                        {
                            case 1:
                                Console.Write("Enter the ID of the teacher: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Teacher teacher = businessLayer.GetTeacherByID(id);
                                var coursesOfTeacher = businessLayer.GetAllCoursesOfTeacher(teacher);
                                foreach (var something in coursesOfTeacher)
                                {
                                    Console.WriteLine(something);
                                }
                                break;
                            case 2:
                                Console.Write("Enter the name of the teacher: ");
                                string teacherName = Console.ReadLine();
                                Teacher teacher2 = businessLayer.GetTeacherByName(teacherName);
                                Console.WriteLine(businessLayer.GetAllCoursesOfTeacher(teacher2));
                                break;

                        }


                        break;
                    case 10:
                        menuSwitch = false;
                        break;
                }
            } // end of while loop
            
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

        static void ModifyCourse(IBusinessLayer bl)
        {
            bool isQuit = false;
            while (!isQuit)
            {
                string[] menuList = {
                "Change teacher assigned to a course",
                "Change a course's name",
                "Quit"
                };
                PrintMenu(menuList);
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.Write("Enter the ID of the course: ");
                        int courseToReassignId = Convert.ToInt32(Console.ReadLine());
                        Course courseToReasign = bl.GetCourseByID(courseToReassignId);
                        Console.Write("Enter the ID of the teacher: ");
                        int teacherId = Convert.ToInt32(Console.ReadLine());
                        Teacher teacher = bl.GetTeacherByID(teacherId);
                        courseToReasign.TeacherId = teacher.TeacherId;
                        bl.UpdateCourse(courseToReasign);
                        break;

                    case 2:
                        Console.Write("Enter the ID of the course: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Course course = bl.GetCourseByID(id);
                        Console.Write("Enter the new Name for " + course.CourseName + ": ");
                        string newName = Console.ReadLine();
                        course.CourseName = newName;
                        bl.UpdateCourse(course);
                        break;
                    case 3:
                        isQuit = true;
                        break;

                }
            }
        }

        static public void PrintMenu(string[] menuOptions)
        {
            for (int i = 0; i < menuOptions.Length; i++)
            {

                Console.WriteLine((i + 1).ToString() + " " + menuOptions[i]);
            }
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
