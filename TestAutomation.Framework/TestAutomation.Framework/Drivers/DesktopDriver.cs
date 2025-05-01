using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Drivers
{
    public class DesktopDriver : IDriver
    {
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }

        public async Task InitializeAsync(ViewportSize? viewport = null)
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            var contextOptions = new BrowserNewContextOptions();
            if (viewport != null)
                contextOptions.ViewportSize = viewport;

            Context = await Browser.NewContextAsync(contextOptions);
            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
