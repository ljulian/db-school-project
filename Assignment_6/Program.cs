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
            while (menuSwitch)
            {
                Console.WriteLine("1) See the list of courses");
                Console.WriteLine("2) Update the course");
                Console.WriteLine("3) Delete the course");
                Console.WriteLine("4) Create the course");
                Console.WriteLine("5) End the program");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        IList<Course> courses = businessLayer.GetAllCourses();
                        foreach (Course course in courses)
                        {
                            Console.WriteLine("Course Name: " + course.CourseName + ", Course ID: " + course.CourseId);
                        }
                        break;

                    case 2:
                        Console.WriteLine("1) Update by searching course ID");
                        Console.WriteLine("2) Update by searching course name");
                        int selection2 = Convert.ToInt32(Console.ReadLine());
                        switch (selection2)
                        {
                            case 1:
                                Console.Write("Enter the ID of the course: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Course course = businessLayer.GetCourseByID(id);
                                Console.Write("Enter the new Name for " + course.CourseName + ": ");
                                string newName = Console.ReadLine();
                                course.CourseName = newName;
                                businessLayer.UpdateCourse(course);
                                break;
                            case 2:
                                Console.Write("Enter the name of the course: ");
                                string courseName = Console.ReadLine();
                                Course course2 = businessLayer.GetCourseByName(courseName);
                                Console.Write("Enter the new Name for " + course2.CourseName + ": ");
                                string newName2 = Console.ReadLine();
                                course2.CourseName = newName2;
                                businessLayer.UpdateCourse(course2);
                                break;
                        }
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
                        menuSwitch = false;
                        break;
                }
            } // end of while loop

        }
    }
}
