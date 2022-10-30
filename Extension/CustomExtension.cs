using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoginTest.Extension
{
    public static class CustomExtension
    {
        /// <summary>
        /// This method allow to click an element via javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void MoveToElementAndClickJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.Click();
        }
        public static void ScrollIntoViewViaJs(this IWebDriver browser, IWebElement? element) =>
           ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        public static void MoveToElementJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            //driver.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
        }
        public static void ClickElementViaJs(this IWebElement element, IWebDriver driver)
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(ExpectedConditions.ele)
            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        /// <summary>
        /// This method allows for scrolling into view and enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, IWebDriver driver, string value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }
        /// <summary>
        /// Method which allows for entering text without scrolling
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }
        /// <summary>
        /// This method allows to wait untill the element is located
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static IWebElement FindThisElement(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(x => x.FindElement(by));
        }

        public static List<IWebElement> FindThisElements(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(x => x.FindElements(by)).ToList();
        }
        public static IWebElement FindMyElement(this IWebDriver driver, locator locator, string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            if (locator == locator.id)
            {
                return wait.Until(x => x.FindElement(By.Id(element)));

            }
            else if (locator == locator.name)
            {
                return wait.Until(x => x.FindElement(By.Name(element)));

            }
            else if (locator == locator.xpath)
            {
                return wait.Until(x => x.FindElement(By.XPath(element)));

            }
            return FindMyElement(driver, locator, element);
        }
        public static (IWebElement Single, IList<IWebElement> multiple) GetMyElement(this IWebDriver driver, By element1)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return (wait.Until(x => x.FindElement(element1)), wait.Until(x => x.FindElements(element1)));
        }
    }
    public enum locator
    {
        id,
        name,
        xpath
    }
}
