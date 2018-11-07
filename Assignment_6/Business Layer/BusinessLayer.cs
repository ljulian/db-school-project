using Assignment_6.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Business_Layer
{
    class BusinessLayer:IBusinessLayer
    {
        private readonly IStandardRepository _standardRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _teacherRepository = new TeacherRepository();
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
        }

        public IList<Standard> GetAllStandards()
        {
            return (IList<Standard>)_standardRepository.GetAll();
        }

        public Standard GetStandardByID(int id)
        {
            return _standardRepository.GetSingle(
                s => s.StandardId == id,
                s => s.Students);
        }

        public Standard GetStandardByName(string name)
        {
            return _standardRepository.GetSingle(
                s => s.StandardName.Equals(name),
                s => s.Students);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }



        public void UpdateStandard(Standard standard)
        {
            throw new NotImplementedException();
        }

        public void RemoveStandard(Standard standard)
        {
            throw new NotImplementedException();
        }

        public IList<Teacher> GetAllTeachers()
        {
            return (IList<Teacher>)_teacherRepository.GetAll();
        }

        // TODO should this be two functions?
        public Teacher GetTeacherByID(int id)
        {
            return _teacherRepository.GetSingle(t => t.TeacherId == id,
                                                t => t.Courses); 
        }

        public Teacher GetTeacherByName(string name)
        {
            return _teacherRepository.GetSingle(x => x.TeacherName.Equals(name),
                                                x => x.Courses);
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Insert(teacher);
        }
        // TODO do I have to implement two update functions?
        // TODO one that updates using the teacher's id and by name?
        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public IList<Student> GetAllStudents()
        {
            return (IList<Student>)_studentRepository.GetAll();
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Insert(student);
        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student GetStudentByName(string name)
        {
            return _studentRepository.GetSingle(x => x.StudentName.Equals(name),
                                                x => x.Courses);
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public IList<Course> GetAllCourses()
        {
            return (IList<Course>)_courseRepository.GetAll();
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return _courseRepository.GetSingle(x => x.CourseName.Equals(name), x => x.Students);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Insert(course);

        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void RemoveCourse(Course course)
        {
            _courseRepository.Delete(course);
        }
    }
}
