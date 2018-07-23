using HomeworkPaul.Areas.Registration.Models;
using HomeworkPaul.Areas.Registration.Repository;
using HomeworkPaul.Common;

namespace HomeworkPaul.Areas.Registration
{
    public class RegistrationFacade
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegistrationFacade(IRegistrationRepository registrationRepository, IPasswordHasher passwordHasher)
        {
            _registrationRepository = registrationRepository;
            _passwordHasher = passwordHasher;
        }

        public RegistrationResult RegisterUser(RegistrationDetails registrationDetails)
        {
            var exists = _registrationRepository.DoesEmailAlreadyExist(registrationDetails.Email);
            if (exists)
            {
                return new RegistrationResult {Success = false, Message = "The Email is already registered"};
            }

            var hashed = _passwordHasher.CreateHash(registrationDetails.Password);
            registrationDetails.Password = hashed;

            var result = _registrationRepository.CreateUser(registrationDetails);
            return result > 0
                ? new RegistrationResult {Success = true, Message = "Registration was successful"}
                : new RegistrationResult {Success = false, Message = "Registration was unsuccessful, please try again later" };
        }
    }
}