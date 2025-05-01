using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Drivers
{
    public class AndroidDriver : IDriver
    {
        public IBrowser? Browser { get; private set; }
        public IBrowserContext? Context { get; private set; }
        public IPage? Page { get; private set; }

        public async Task InitializeAsync(ViewportSize? viewport = null)
        {
            var playwright = await Playwright.CreateAsync();
            var browserOptions = new BrowserTypeLaunchOptions
            {
                Headless = false,  // We can set it to false for debugging purposes
            };

            // Launch Chromium browser and emulate Android
            Browser = await playwright.Chromium.LaunchAsync(browserOptions);
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = viewport ?? new ViewportSize { Width = 360, Height = 640 },  // Android mobile screen size
                UserAgent = "Mozilla/5.0 (Linux; Android 10; Pixel 3 XL) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Mobile Safari/537.36"
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
