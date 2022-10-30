using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowLoginTest.Drivers;
using System.Diagnostics;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecFlowLoginTest.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer container;
        ChromeOptions options;
        public Hooks(IObjectContainer _container)
        {
            container = _container;
            options = new ChromeOptions();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), 
                VersionResolveStrategy.MatchingBrowser);
            options.AddArguments("start-maximized", "incognito");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
            using (var process = Process.GetCurrentProcess())
            {
                if (process.ToString() == "chromedriver")
                {
                    process.Kill(true);
                }
                driver?.Dispose(); driver = null;
            }
        }
    }
}