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
                Console.WriteLine("Class already exists!");
            }
            else
            {
                _repository.Add(new Classes { Name = className });
                Console.WriteLine("Class added!");
            }
            
        }

        public void AddStudent(string className, Students newStudent)
        {
            Classes selectedClass = new Classes();
            selectedClass = _repository.GetClassByName(className);
            if (selectedClass == null)
            {
                Console.WriteLine("Class not found!");
            }
            else
            {
                selectedClass.Students.Add(newStudent);
                Console.WriteLine("Student added!");
            }
            
        }

        public void AddTeacher(string className, Teachers newTeacher)
        {
            var selectedClass = _repository.GetClassByName(className);
            if (selectedClass == null)
            {
                Console.WriteLine("Class not found!");
            }
            else
            {
                if (selectedClass.Teacher != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{selectedClass.Teacher.Name} {selectedClass.Teacher.Surname} is the teacher of the class '{selectedClass.Name}'");
                    Console.ResetColor();
                }
                else
                {
                    selectedClass.Teacher = newTeacher;
                    Console.WriteLine("Teacher added!");
                }
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
