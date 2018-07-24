using HomeworkPaul.Areas.Registration;
using HomeworkPaul.Areas.Registration.Models;
using HomeworkPaul.Areas.Registration.Repository;
using HomeworkPaul.Common;
using Moq;
using NUnit.Framework;

namespace HomeworkPaul.Tests
{
    [TestFixture]
    public class RegistrationFacadeTests
    {
        private  Mock<IRegistrationRepository> _mockRegistrationRepository;
        private  Mock<IPasswordHasher> _mockPasswordHasher;
        private RegistrationFacade _registrationFacade;
        private RegistrationDetails _registrationDetails;

        [SetUp]
        public void SetUp()
        {
            _mockRegistrationRepository = new Mock<IRegistrationRepository>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _registrationFacade = new RegistrationFacade(_mockRegistrationRepository.Object, _mockPasswordHasher.Object);
            _registrationDetails = new RegistrationDetails {Email = "x.y@z.com", Password = "PAssword1!"};
        }


        [Test]
        public void RegisterUser_EmailAlreadyExists_DoesNotStoreOrHash()
        {
            //arrange
            _mockRegistrationRepository.Setup(_ => _.DoesEmailAlreadyExist(It.IsAny<string>())).Returns(true);

            //act
            var result = _registrationFacade.RegisterUser(_registrationDetails);

            //assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message);
            _mockRegistrationRepository.Verify(_ => _.CreateUser(It.IsAny<RegistrationDetails>()), Times.Never);
            _mockPasswordHasher.Verify(_ => _.CreateHash(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void RegisterUser_EmailDoesNotExist_HashesPasswordAndStores()
        {
            //arrange
            _mockRegistrationRepository.Setup(_ => _.DoesEmailAlreadyExist(It.IsAny<string>())).Returns(false);
            _mockPasswordHasher.Setup(_ => _.CreateHash(It.IsAny<string>())).Returns("Hashed");
            _mockRegistrationRepository.Setup(_ => _.CreateUser(It.IsAny<RegistrationDetails>())).Returns(1);

            //act
            var result = _registrationFacade.RegisterUser(_registrationDetails);

            //assert
            Assert.True(result.Success);
            Assert.IsNotEmpty(result.Message);
            _mockPasswordHasher.Verify(_ => _.CreateHash(It.IsAny<string>()), Times.Once);
            _mockRegistrationRepository.Verify(_ => _.CreateUser(It.IsAny<RegistrationDetails>()), Times.Once);
        }
    }
}
