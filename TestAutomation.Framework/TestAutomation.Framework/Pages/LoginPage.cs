using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync() =>
            await _page.GotoAsync("https://example.com/login");

        public async Task EnterUsername(string username) =>
            await _page.FillAsync("#username", username);

        public async Task EnterPassword(string password) =>
            await _page.FillAsync("#password", password);

        public async Task SubmitAsync() =>
            await _page.ClickAsync("#submit");

        public async Task<bool> IsLoginSuccessful() =>
            await _page.IsVisibleAsync("#welcomeMessage");
    }
}
