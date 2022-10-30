using OpenQA.Selenium;
using SpecFlowLoginTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeTectTest.Support;

namespace SpecFlowLoginTest.Pageobjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement Login => driver.FindElement(By.XPath("//button[contains (@class, 'btn btn')]"));
        private IWebElement NewUser => driver.FindElement(By.XPath("//button[@id='newUser'][.='New User']"));
        private IWebElement FirstName => driver.FindElement(By.XPath("//input[@id='firstname']"));
        private IWebElement LastName => driver.FindElement(By.XPath("//input[@id='lastname']"));
        private IWebElement UserName => driver.FindElement(By.XPath("//input[@id='userName']"));
        private IWebElement Password => driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement Recaptcha => driver.FindElement(By.XPath("//label[@id='recaptcha-anchor-label']"));
        private IWebElement BackToLoginBtn => driver.FindElement(By.Id("gotologin"));
        private IWebElement Register => driver.FindElement(By.XPath("//button[@id='register']"));
        private IWebElement LoginHeaderText => driver.FindElement(By.XPath("//*[@class='main-header'][.='Login']"));
        private IWebElement LogOutBtn => driver.FindElement(By.Id("submit"));
        //private IWebElement ProfileHeaderText => driver.FindElement(By.XPath("//*[@class='main-header']"));
        //private IWebElement GoToBookStoreBtn => driver.FindElement(By.Id("gotoStore"));




        //*[@class='text-center button']
        //public void ClickGoToBookStoreBtn() => GoToBookStoreBtn.Click();
        public void ClickLogOutBtn() => LogOutBtn.ClickElementViaJs(driver);
        //public string GetProfileHeader() => ProfileHeaderText.Text;
        public void LoginDetails(string lName, string lPword)
        {
            UserName.SendKeys(lName);
            Password.SendKeys(lPword);
        }
        public string GetLoginHeaderText() => LoginHeaderText.Text;
        public void NavigateToSite(string url) => driver.Navigate().GoToUrl(url);
        public void Clicklogin() => Login.Click();  
        public void ClickNewUser() => NewUser.Click(); 
        public void EnterLoginDetails(string fname, string lname, string uname, string pword)
        {
            FirstName.SendKeys(fname);
            LastName.SendKeys(lname);
            UserName.SendKeys(uname);
            Password.SendKeys(pword);
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']")));
            Recaptcha.Click();
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
            //BackToLoginBtn.Click();
            Register.Click();
        }
        public bool isBackToLoginBtnDisplayed() => BackToLoginBtn.Displayed;
        public void NavigateToSite() => driver.Navigate().GoToUrl(readTestDataConfig.DemoQaUrl);
    }
}