namespace Waitrose.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int StudentMark { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }

    }
}
