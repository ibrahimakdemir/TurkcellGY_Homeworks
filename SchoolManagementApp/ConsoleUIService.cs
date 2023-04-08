using SchoolManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp
{
    public class ConsoleUIService
    {
        public void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to School Management System!");
            Console.ResetColor();
        }

        public int Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Add a new class");
            Console.WriteLine("2. Add a new student");
            Console.WriteLine("3. Add a new teacher");
            Console.WriteLine("4. Get all classes");
            Console.WriteLine("5. Get all students in the selected class");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Exit");
            Console.ResetColor();

            int choice = 0;
            bool isValid = false;

            do
            {
                Console.Write("Enter your choice: ");

                isValid = int.TryParse(Console.ReadLine(), out choice);

                if (!isValid || choice < 1 || choice > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.");
                    Console.ResetColor();
                }

            } while (!isValid || choice < 1 || choice > 6);

            return choice;
        }

        public string GetClassName()
        {
            Console.WriteLine("Enter the class name:");
            string className = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(className))
            {
                Console.WriteLine("Invalid Input! Please enter a valid class name:");
                className = Console.ReadLine();
            }
            return className;
        }

        public string SelectClass()
        {
            var enteredClassName = string.Empty;
            do
            {
                enteredClassName = GetClassName();

            } while (string.IsNullOrEmpty(enteredClassName));

            return enteredClassName;
        }

        public Students GetNewStudentInfo(Classes classes)
        {
            var newStudent = new Students();
            
            newStudent.StudentId = GetId();
            newStudent.Name = GetName();
            newStudent.Surname = GetSurname();
            newStudent.Classes = classes;

            return newStudent;
        }

        private string GetName()
        {
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid Input! Please enter a valid name:");
                name = Console.ReadLine();
            }
            return name;
        }

        private string GetSurname()
        {
            Console.WriteLine("Enter the surname:");
            string surname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Invalid Input! Please enter a valid surname:");
                surname = Console.ReadLine();
            }
            return surname;
        }

        private int GetId()
        {
            int id = 0;
            bool isValid = false;

            do
            {
                Console.WriteLine("Please enter the student ID(pozitive integers): ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out id) && id > 0;

                if (!isValid)
                {
                    Console.WriteLine("Invalid ID! Please enter positive integers");
                }

            } while (!isValid);
            return id;
        }

        public Teachers GetNewTeacherInfo(Classes classes)
        {
            var newTeacher = new Teachers();

            newTeacher.TeacherId = GetId();
            newTeacher.Name = GetName();
            newTeacher.Surname = GetSurname();
            newTeacher.Classes = classes;

            return newTeacher;

        }
    }
}
