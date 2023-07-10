namespace Waitrose.Models
{
    public class TeacherClass
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
    }
}
