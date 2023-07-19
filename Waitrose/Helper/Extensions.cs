using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Waitrose.Helper
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool IsOlder1Mb(this IFormFile file)
        {
            return file.Length / 1024 > 1024;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file, string folder)
        {
            string filename = file.FileName;
            string path = Path.Combine(folder, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
