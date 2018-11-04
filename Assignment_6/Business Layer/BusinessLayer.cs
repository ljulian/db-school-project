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
        
        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IList<Standard> GetAllStandards()
        {
            throw new NotImplementedException();
        }

        public IList<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Standard GetStandardByID(int id)
        {
            throw new NotImplementedException();
        }

        public Standard GetStandardByIDWithStudents(int id)
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

        public Student GetStudentByID(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
