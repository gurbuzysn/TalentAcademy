using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Helpers
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string text)
            => text.Replace("ı", "i")
                   .Replace("I", "i")
                   .Replace("İ", "i")

                   .Replace("ö", "o")
                   .Replace("Ö", "o")
                   .Replace("O", "o")

                   .Replace("ü", "u")
                   .Replace("Ü", "u")
                   .Replace("U", "u")

                   .Replace("ğ", "g")
                   .Replace("Ğ", "g")
                   .Replace("G", "g")

                   .Replace("ş", "s")
                   .Replace("Ş", "s")
                   .Replace("S", "s")

                   .Replace("ç", "c")
                   .Replace("Ç", "c")
                   .Replace("C", "c");
    }
}
