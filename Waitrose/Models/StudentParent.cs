namespace Waitrose.Models
{
    public class StudentParent
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Parent Parent { get; set; }
        public int ParentId { get; set; }
    }
}
