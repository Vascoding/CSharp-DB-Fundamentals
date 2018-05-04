
using PhotoShare.Services;

namespace PhotoShare.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PhotoShare.Client.Core.Commands;
    [TestClass]
    public class RegisterCommandTests
    {
        [TestMethod]
        public void Register_NewUser_Should_SuccessMessage()
        {
            var commandParam = new string[] {"Username", "123Pass", "123Pass", "user@abv.bg"};
            RegisterUserCommand registerUser = new RegisterUserCommand(new UserService());

            string result = registerUser.Execute(commandParam);

            Assert.AreEqual("User " + commandParam[0] + " was registered successfully!", result);
        } 
    }
}
