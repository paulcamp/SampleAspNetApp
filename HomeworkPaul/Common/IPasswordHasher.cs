namespace HomeworkPaul.Common
{
    public interface IPasswordHasher
    {
        string CreateHash(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}