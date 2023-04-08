using SchoolManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp
{
    public class SchoolService
    {
        ClassesRepository _repository;

        public SchoolService()
        {
            _repository = new ClassesRepository();
        }
     
        public void AddClass(string className)
        {
            if (_repository.GetClassByName(className) != null)
            {
                throw new Exception("Class already exists!");
            }

            _repository.Add(new Classes { Name = className });
            Console.WriteLine("Class added!");
        }

        public void AddStudent(string className, Students newStudent)
        {
            Classes selectedClass = new Classes();
            selectedClass = _repository.GetClassByName(className);
            if (selectedClass == null)
            {
                throw new Exception("Class not found!");
            }
            selectedClass.Students.Add(newStudent);
            _repository.Update(selectedClass);
            Console.WriteLine("Student added!");
        }

        public void AddTeacher(string className, Teachers newTeacher)
        {
            var selectedClass = _repository.GetClassByName(className);
            if (selectedClass == null)
            {
                throw new Exception("Class not found!");
            }

            if (selectedClass.Teacher != null)
            {
                Console.WriteLine($"{selectedClass.Teacher.Name} {selectedClass.Teacher.Surname} is the teacher of the {selectedClass.Name}");
            }
            else
            {
                selectedClass.Teacher = newTeacher;
                _repository.Update(selectedClass);
                Console.WriteLine("Teacher added!");
            }
        }

        public List<Classes> GetAllClasses()
        {
            return _repository.GetAll();
        }
        public Classes GetClassByName(string className)
        {
            return _repository.GetClassByName(className);
        }

        public List<Students> GetStudents(string className)
        {
            return _repository.GetClassByName(className).Students.ToList();
        }
        public Teachers GetTeacher(string className)
        {
            return _repository.GetClassByName(className).Teacher;
        }
    }
}
