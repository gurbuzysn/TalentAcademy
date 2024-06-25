namespace TalentAcademy.Application.Helpers
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string text)
            => text.Replace("ı", "i")
                   .Replace("İ", "I")

                   .Replace("ö", "o")
                   .Replace("Ö", "O")

                   .Replace("ü", "u")
                   .Replace("Ü", "U")

                   .Replace("ğ", "g")
                   .Replace("Ğ", "G")

                   .Replace("ş", "s")
                   .Replace("Ş", "S")

                   .Replace("ç", "c")
                   .Replace("Ç", "C");
    }
}
