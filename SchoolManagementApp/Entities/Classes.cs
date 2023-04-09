using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Entities
{
    public class Classes
    {
        public string Name { get; set; }
        public List<Students> Students { get; set; }
        public Teachers Teacher { get; set; }

        public Classes()
        {
            Students = new List<Students>();
        }
    }

    public class ClassesRepository
    {

        List<Classes> classes;
        public ClassesRepository()
        {
            classes = new List<Classes>();
        }

        public void Add(Classes _class)
        {
            classes.Add(_class);
        }

        public List<Classes> GetAll()
        {
            return classes;
        }

        public Classes GetClassByName(string className)
        {
            return classes.FirstOrDefault(c => c.Name == className);
        }
    }
}
