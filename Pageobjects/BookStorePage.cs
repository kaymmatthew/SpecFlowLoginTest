using OpenQA.Selenium;
using SpecFlowLoginTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoginTest.Pageobjects
{
    public class BookStorePage
    {
        IWebDriver driver;
        public BookStorePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement BookStoreApplication => driver.FindElement(By.XPath
               ("//div[contains (@class, 'card mt')][.='Book Store Application']"));
        private IWebElement BookStoreHeaderText => driver.FindElement(By.XPath("//*[@class='main-header']"));


  
        public void ClickBookStoreApplication() => BookStoreApplication.ClickElementViaJs(driver);

        public string GetBookStoreHeaderText()
        {
            Thread.Sleep(3000); 
            return BookStoreHeaderText.Text;
        }
    }
}