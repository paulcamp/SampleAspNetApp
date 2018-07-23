using HomeworkPaul.Areas.Registration.Models;

namespace HomeworkPaul.Areas.Registration.Repository
{
    public interface IRegistrationRepository
    {
        int CreateUser(RegistrationDetails registrationDetails);
        bool DoesEmailAlreadyExist(string emailAddress);
    }
}