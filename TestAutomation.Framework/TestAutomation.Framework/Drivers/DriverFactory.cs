using TestAutomation.Framework.Drivers;

namespace TestAutomation.Tests
{
    public static class DriverFactory
    {
        public static IDriver Create(DriverType driverType)
        {
            return driverType switch
            {
                DriverType.Desktop => new DesktopDriver(),
                DriverType.Mobile => new MobileDriver(),
                DriverType.Android => new AndroidDriver(),
                DriverType.iOS => new IOSDriver(),
                _ => throw new NotImplementedException("Driver type not supported")
            };
        }
    }
