using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public string Date { get; set; }
        public List<Student> Students { get; set; }
        public int StudentId { get; set;}
    }
}
