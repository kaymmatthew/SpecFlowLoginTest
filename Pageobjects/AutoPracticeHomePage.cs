using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowLoginTest.Drivers;
using SpecFlowLoginTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using XeTectTest.Support;
using static System.Net.Mime.MediaTypeNames;

namespace SpecFlowLoginTest.Pageobjects
{
    public class AutoPracticeHomePage
    {
        IWebDriver driver;
        Actions actions;
        public AutoPracticeHomePage(IWebDriver _driver)
        {
            driver = _driver;
            this.actions = new Actions(driver);
        }
        private IWebElement? ItemToChoose(string name) => driver?
            .FindThisElement(By.XPath($"//*[@id='homefeatured']//li//div//a[contains(text(),'{name}')]//ancestor::li"));
        private IList<IWebElement>? addtobasket => driver.FindThisElements(By.XPath("//*[.='Add to cart']"));
        private IWebElement ProceedElement => driver.FindThisElement(By.XPath("//*[@title='Proceed to checkout']"));
        private IWebElement PageHeaderText => driver.FindThisElement(By.Id("cart_title"));
        private IWebElement SelectedItem => driver.FindThisElement(By.XPath("//*[@class='cart_description']"));
        private IWebElement ItemQty => driver.FindThisElement(By.XPath("//*[@type='text']"));
        private IWebElement TotalProducts => driver.FindThisElement(By.XPath("//*[@id='total_product']"));
        private IWebElement TotalShipping => driver.FindThisElement(By.XPath("//*[@id='total_shipping']"));
        private IWebElement Total => driver.FindThisElement(By.XPath("//*[@id='total_price_without_tax']"));
        private IWebElement Tax => driver.FindThisElement(By.XPath("//*[@id='total_tax']"));



        public bool GetItemQty() => ItemQty.Displayed;
        public string GetSelectedItem() => SelectedItem.Text;
        public string GetPageHeader() => PageHeaderText.Text;
        public void ClickProceed()
        {
            Thread.Sleep(3000);
            ProceedElement.ClickElementViaJs(driver);
        }
        public void scrollIntoViewofElement(string name)
        {
            driver.ScrollIntoViewViaJs(ItemToChoose(name));
            actions.MoveToElement(ItemToChoose(name)).Perform();
        }

        public List<string> GetPriceBreakDown()
        {
            List<string> strings = new List<string>();
            strings.Add(TotalProducts.Text);
            strings.Add(TotalShipping.Text);
            strings.Add(Total.Text);
            strings.Add(Tax.Text);
            return strings;
        }

        public bool GetPriceBreakDown(Table table)
        {
            List<string> strings = new List<string>();
            strings.Add(TotalProducts.Text);
            strings.Add(TotalShipping.Text);
            strings.Add(Total.Text);
            strings.Add(Tax.Text);

            dynamic tableDetails = table.CreateDynamicInstance();
            Assert.AreEqual(tableDetails.Totalproducts, strings[0]);
            Assert.AreEqual(tableDetails.Totalshipping, strings[1]);
            Assert.AreEqual(tableDetails.Total, strings[2]);
            Assert.AreEqual(tableDetails.Tax, strings[3]);

            return true;

        }
        public void ClickAddToCartButton()
        {
            Thread.Sleep(3000);
            addtobasket?[1].ClickElementViaJs(driver);
        }
        public void NavigateToSite() => driver.Navigate().GoToUrl(readTestDataConfig.AutoPracticeUrl);
    }
}