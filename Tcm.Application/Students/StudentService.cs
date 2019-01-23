using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Tcm.Application.Contract.Students;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.Students
{
    public class StudentService : IStudentService
    {

        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(StudentDto studentDto)
        {
            var student = new Student() {
             ApplicationUserId = studentDto.ApplicationUserId,

                 StudentNumber = studentDto.StudentNumber
            };

            _studentRepository.Add(student);
           
        }

        public void Delete(long Id)
        {
            var student = Get(Id);
            if(student!=null)
            _studentRepository.Delete(student.Mapper());
        }

        public StudentDto Get(long id)
        {
           return  _studentRepository.GetById(id).Mapper();

           
        }

        public List<StudentDto> GetAll(UserParams userParams)
        {
            var items = _studentRepository.GetAll().Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList().Mapper();

            return null;

        }

        public List<Student> GetAll(Expression<Func<Student, bool>> expression)
        {
            return _studentRepository.GetAll(expression).ToList();
        }

        public void Update(long Id, StudentDto model)
        {
            var student = _studentRepository.GetById(Id);
           
            if (student != null)
            {
              

                _studentRepository.Update(student);
            }
        }
    }

    public static class StudentMapper
    {
        public static List<StudentDto> Mapper(this List<Student> students)
        {
            var items = new List<StudentDto>();
            students.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static StudentDto Mapper(this Student student)
        {


            var dto = new StudentDto();

            if (student != null)
            {
              
            }          

            return dto;
        }
        public static List<Student> Mapper(this List<StudentDto> students)
        {
            var items = new List<Student>();
            students.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static Student Mapper(this StudentDto student)
        {


            var dto = new Student();

            if (student != null)
            {
              
            }

            return dto;
        }
    }
    
}
