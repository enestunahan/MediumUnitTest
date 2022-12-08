namespace MediumUnitTest.Library.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public bool IsValid(string fullName)
        {
            return true;
        }
    }
}
