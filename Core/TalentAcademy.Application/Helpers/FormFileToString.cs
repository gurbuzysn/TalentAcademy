using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Helpers
{
    public static class FormFileToString
    {
        public static async Task<string> FileToStringAsync(IFormFile formFile)
        {
            using MemoryStream stream = new MemoryStream();
            await formFile.CopyToAsync(stream);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}
