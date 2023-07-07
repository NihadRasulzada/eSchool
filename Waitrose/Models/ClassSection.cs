namespace Waitrose.Models
{
    public class ClassSection
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
    }
}
