
using HomeworkPaul.Common;
using NUnit.Framework;

namespace HomeworkPaul.Tests
{
    [TestFixture]
    public class PasswordHashTests
    {
        [Test]
        public void CreateHash_EmptyInput_ProducesNonEmptyOutput()
        {
            //arrange
            var input = string.Empty;
            //act
            var output = PasswordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(string.Empty, output);
        }

        [Test]
        public void CreateHash_PasswordInput_ReturnsHashedPassword()
        {
            //arrange
            var input = string.Empty;
            //act
            var output = PasswordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(input, output);
        }

        [Test]
        public void CreateHash_CalledTwiceWithSameInput_ReturnsDifferentOutputs()
        {
            //arrange
            var input = "testString1234";
            //act
            var output1 = PasswordHasher.CreateHash(input);
            var output2 = PasswordHasher.CreateHash(input);
            //assert
            Assert.AreNotEqual(output1, output2);
        }

        [Test]
        public void ValidatePassword_CalledWithCorrectHash_ReturnsTrue()
        {
            //arrange
            var input = "testString1234";
            var hash = PasswordHasher.CreateHash(input);
            
            //act
            var result = PasswordHasher.ValidatePassword(input, hash);

            //assert
            Assert.True(result);
        }

        [Test]
        public void ValidatePassword_CalledWithTamperedHash_ReturnsFalse()
        {
            //arrange
            var input = "testString1234";
            var hash = PasswordHasher.CreateHash(input);
            var tamperedHash = "1000:+MwX2ZJBJ3hlxx86v19lTRwgWj56Drvi:HUzW/70JXEXtke3vc/cPGh2pedf6slK2";

            //act
            var result = PasswordHasher.ValidatePassword(input, tamperedHash);

            //assert
            Assert.AreNotEqual(tamperedHash, hash);
            Assert.False(result);
        }

    }
}
