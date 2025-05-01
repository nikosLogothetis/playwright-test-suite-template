using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Framework.Drivers
{
    public interface IDriver
    {
        IBrowser Browser { get; }
        IBrowserContext Context { get; }
        IPage Page { get; }

        Task InitializeAsync(ViewportSize? viewport = null);
        Task DisposeAsync();
    }
}
