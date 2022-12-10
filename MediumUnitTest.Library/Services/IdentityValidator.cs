namespace MediumUnitTest.Library.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        private const int MinLength = 5;
        public bool IsValid(string fullName)
        {
            if(fullName.Length < MinLength)
            {
                throw new Exception("FullName alanı 5 karakterden fazla olmalıdır");
            }

            return true;
        }
    }
}
