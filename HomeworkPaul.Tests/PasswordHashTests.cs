
using HomeworkPaul.Common;
using NUnit.Framework;

namespace HomeworkPaul.Tests
{
    [TestFixture]
    public class PasswordHashTests
    {
        private PasswordHasher _passwordHasher;

        public PasswordHashTests()
        {
            _passwordHasher = new PasswordHasher();
        }

        [Test]
        public void CreateHash_EmptyInput_ProducesNonEmptyOutput()
        {
            //arrange
            var input = string.Empty;
            //act
            var output = _passwordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(string.Empty, output);
        }

        [Test]
        public void CreateHash_PasswordInput_ReturnsHashedPassword()
        {
            //arrange
            var input = string.Empty;
            //act
            var output = _passwordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(input, output);
        }

        [Test]
        public void CreateHash_CalledTwiceWithSameInput_ReturnsDifferentOutputs()
        {
            //arrange
            var input = "testString1234";
            //act
            var output1 = _passwordHasher.CreateHash(input);
            var output2 = _passwordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(output1, output2);
        }

        [Test]
        public void ValidatePassword_CalledWithCorrectHash_ReturnsTrue()
        {
            //arrange
            var input = "testString1234";
            var hash = _passwordHasher.CreateHash(input);
            
            //act
            var result = _passwordHasher.ValidatePassword(input, hash);

            //assert
            Assert.True(result);
        }

        [Test]
        public void ValidatePassword_CalledWithTamperedHash_ReturnsFalse()
        {
            //arrange
            var input = "testString1234";
            var hash = _passwordHasher.CreateHash(input);
            var tamperedHash = "1000:+MwX2ZJBJ3hlxx86v19lTRwgWj56Drvi:HUzW/70JXEXtke3vc/cPGh2pedf6slK2";

            //act
            var result = _passwordHasher.ValidatePassword(input, tamperedHash);

            //assert
            Assert.AreNotEqual(tamperedHash, hash);
            Assert.False(result);
        }

    }
}
