using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Waitrose.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeactive { get; set; }
        public List<Student> Students { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }
        public List<Syllabus> Syllabuses { get; set; }
    }
}
