using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Drivers
{
    public class MobileDriver : IDriver
    {
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }

        public async Task InitializeAsync(ViewportSize? viewport = null)
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = viewport ?? new ViewportSize { Width = 375, Height = 812 }, // iPhone X
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_5 like Mac OS X)"
            });

            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await Context?.CloseAsync();
            await Browser?.CloseAsync();
        }
    }
}
