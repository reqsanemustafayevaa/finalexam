using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Extentions
{
    public static class Helper
    {
        public static string SaveFille(this IFormFile file, string rootpath, string foldername)
        {
            string filename=file.FileName.Length>64
                ?file.FileName.Substring(file.FileName.Length - 64,64)
                :file.FileName;
            string path=Path.Combine(rootpath,foldername,filename);
            using(FileStream stream=new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
        public static void DeleteFile(string rootpath,string foldername,string ImageUrl)
        {
            string deletepath=Path.Combine(rootpath,foldername,ImageUrl);
           if(File.Exists(deletepath))
            {
                File.Delete(deletepath);
            }

        }
       
    }
}
