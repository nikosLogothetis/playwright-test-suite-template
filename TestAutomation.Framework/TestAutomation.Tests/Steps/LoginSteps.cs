using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomation.Framework.Drivers;
using TestAutomation.Framework.Pages;

namespace TestAutomation.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IDriver _driver;
        private LoginPage _loginPage;

        public LoginSteps()
        {
            _driver = new DesktopDriver(); // Later, use DI or factory for different channels
        }

        [Given(@"the user is on the login page")]
        public async Task GivenTheUserIsOnTheLoginPage()
        {
            await _driver.InitializeAsync();
            _loginPage = new LoginPage(_driver.Page);
            await _loginPage.NavigateAsync();
        }

        [When(@"the user logs in with valid credentials")]
        public async Task WhenTheUserLogsIn()
        {
            await _loginPage.EnterUsername("user");
            await _loginPage.EnterPassword("pass");
            await _loginPage.SubmitAsync();
        }

        [Then(@"the user should see a welcome message")]
        public async Task ThenWelcomeMessageIsVisible()
        {
            Assert.IsTrue(await _loginPage.IsLoginSuccessful());
            await _driver.DisposeAsync();
        }
    }
}
