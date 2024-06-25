namespace TalentAcademy.Application.Helpers
{
    public static class ConvertEmailToFullName
    {
        // İki isimli olan kullanıcılar için yanlış sonuç çıkaracak. Tekrar handle edilecek!
        public static string ConvertToFullName(string userName)
        {
            string[] fullName = userName.Split('@')[0].Split('.');

            string firstName = fullName[0];
            string lastName = fullName[1];

            char firstBigChar = char.ToUpper(firstName[0]);
            string remain = firstName.Substring(1);
            firstName = firstBigChar + remain;

            lastName = lastName.ToUpper();

            return $"{firstName} {lastName}";
        }
    }
}
