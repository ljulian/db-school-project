using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Business_Layer
{
    interface IBusinessLayer
    {
        IList<Standard> GetAllStandards();
        Standard GetStandardByID(int id);
        Standard GetStandardByName(string name);
        void AddStandard(Standard standard);
        void UpdateStandard(Standard standard);
        void RemoveStandard(Standard standard);

        IList<Teacher> GetAllTeachers();
        Teacher GetTeacherByID(int id);
        Teacher GetTeacherByName(string name);
        void AddTeacher(Teacher teacher);
        // TODO do I have to implement two update functions?
        // TODO one that updates using the teacher's id and by name?
        void UpdateTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);

        IList<Student> GetAllStudents();
        Student GetStudentByID(int id);
        Student GetStudentByName(string name);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);

        IList<Course> GetAllCourses();
        Course GetCourseByID(int id);
        Course GetCourseByName(string name);
        void AddCourse(Course cousre);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);
    }
}
