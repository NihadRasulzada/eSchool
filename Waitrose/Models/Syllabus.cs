using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waitrose.Models
{
    public class Syllabus
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public int Downloaded { get; set; }
        public string File { get; set; }
        [NotMapped]
        public IFormFile Document { get; set; }
    }
}
