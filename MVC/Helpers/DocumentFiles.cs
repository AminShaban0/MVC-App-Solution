using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MVC_BL.Helpers
{
    public static class DocumentFiles
    {
        public static string UplodeFile(IFormFile file , string foldername)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files" , foldername);
            string filename =$"{Guid.NewGuid()}{file.FileName}";
            string filepath = Path.Combine(FolderPath,filename);
            var fileStream = new FileStream(filepath, FileMode.CreateNew);
            file.CopyTo(fileStream);
            return filename;
        }
        public static void DeleteFile (string FileName , string foldername)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",foldername,FileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
