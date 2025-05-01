using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Drivers
{
    public class IOSDriver : IDriver
    {
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }

        public async Task InitializeAsync(ViewportSize? viewport = null)
        {
            var playwright = await Playwright.CreateAsync();
            var browserOptions = new BrowserTypeLaunchOptions
            {
                Headless = false,  // Optional, set to false for debugging
            };

            // Launch WebKit browser and emulate iOS
            Browser = await playwright.Webkit.LaunchAsync(browserOptions);
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = viewport ?? new ViewportSize { Width = 375, Height = 812 }, // iPhone X screen size
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_5 like Mac OS X) AppleWebKit/537.36 (KHTML, like Gecko) Version/13.0 Mobile/15E148 Safari/604.1"
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
