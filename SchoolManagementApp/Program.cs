using SchoolManagementApp;


SchoolService schoolService = new SchoolService();

ConsoleUIService consoleUIService = new ConsoleUIService();
consoleUIService.Welcome();

int choice = 0;
int n;
do
{
    choice = consoleUIService.Menu();
    switch (choice)
    {
        case 1:
            Console.Clear();
            schoolService.AddClass(consoleUIService.GetClassName());
            break;
        case 2:
            Console.Clear();
            n = 1;
            if (schoolService.GetAllClasses().Count >= 1)
            {
                schoolService.GetAllClasses().ForEach(c => Console.WriteLine($"{n++}- {c.Name}"));
                var selectedClassName = consoleUIService.SelectClass();
                var selectedClass = schoolService.GetClassByName(selectedClassName);
                var newStudent = consoleUIService.GetNewStudentInfo(selectedClass);
                schoolService.AddStudent(selectedClassName, newStudent);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No classes found!\n");
                Console.ResetColor();
            }

            break;
        case 3:
            Console.Clear();
            n = 1;
            if (schoolService.GetAllClasses().Count >= 1)
            {
                schoolService.GetAllClasses().ForEach(c => Console.WriteLine($"{n++}- {c.Name}"));
                var selectedClassNameForTeacher = consoleUIService.SelectClass();
                var selectedClassForTeacher = schoolService.GetClassByName(selectedClassNameForTeacher);
                var newTeacher = consoleUIService.GetNewTeacherInfo(selectedClassForTeacher);
                schoolService.AddTeacher(selectedClassNameForTeacher, newTeacher);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No classes found!\n");
                Console.ResetColor();
            }
            break;
        case 4:
            Console.Clear();
            n = 1;
            if (schoolService.GetAllClasses().Count >= 1)
            {
                schoolService.GetAllClasses().ForEach(c => Console.WriteLine($"{n++}- {c.Name}"));
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No classes found!\n");
                Console.ResetColor();
            }

            break;
        case 5:

            Console.Clear();
            n = 1;

            if (schoolService.GetAllClasses().Count >= 1)
            {
                schoolService.GetAllClasses().ForEach(c => Console.WriteLine($"{n++}- {c.Name}"));
                var selectedClassName = consoleUIService.SelectClass();
                var students = schoolService.GetStudents(selectedClassName);

                if (students.Count >= 1)
                {
                    n = 1;
                    Console.Clear();
                    Console.WriteLine($"Class: {selectedClassName}");
                    if(schoolService.GetClassByName(selectedClassName).Teacher != null)
                        Console.WriteLine($"Teacher: {schoolService.GetTeacher(selectedClassName).Name} {schoolService.GetTeacher(selectedClassName).Surname}");
                    Console.WriteLine("Name - Surname - School Id");

                    students.ForEach(students => Console.WriteLine($"{n++}- {students.Name} - {students.Surname} - {students.StudentId}"));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No students found!\n");
                    Console.ResetColor();
                }
                Console.WriteLine("\n\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No classes found!\n");
                Console.ResetColor();
            }
            break;
        default:
            Console.WriteLine("Invalid Choice!");
            break;
    }

} while (choice != 6);