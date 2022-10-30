using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowLoginTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SpecFlowLoginTest.Pageobjects
{
    public class WidgetsPage
    {
        IWebDriver driver;
        Actions actions;
        public WidgetsPage(IWebDriver driver)
        {
            this.actions = new Actions(driver);
            this.driver = driver;
        }

        private IWebElement WidgetsBtn => driver.FindThisElement(By.XPath("//*[contains(@class,'card mt')][.='Widgets']"));
        private IWebElement WidgetsHeaderText => driver.FindThisElement(By.XPath("//*[@class='main-header']"));
        private IWebElement MenuBtn => driver.FindThisElement(By.XPath("//*[contains(@class,'btn btn')][.='Menu']"));
        private IWebElement MenuHeaderText => driver.FindThisElement(By.XPath("//*[@class='main-header'][.='Menu']"));
        private IWebElement SelectMenuHeaderText => driver.FindThisElement(By.XPath("//*[@class='main-header']"));
        private IWebElement MainItem2Element => driver.FindThisElement(By.XPath("//*[.='Main Item 2']"));
        private IWebElement SubSubListElement => driver.FindThisElement(By.XPath("//*[.='SUB SUB LIST »']"));
        private IWebElement SubSubItem1Element => driver.FindThisElement(By.XPath("//*[.='Sub Sub Item 1']"));
        private IWebElement SubSubItem2Element => driver.FindThisElement(By.XPath("//*[.='Sub Sub Item 2']"));
        private IWebElement SelectMenuBtn => driver.FindThisElement(By.XPath("//*[contains(@class,'btn btn')][.='Select Menu']"));
        private IList<IWebElement> TitleElement => driver.FindThisElements(By.XPath("//*[contains(@class,'col-md-')]"));
        private IWebElement TitleOption => driver.FindThisElement(By.XPath("//*[@id='react-select-3-input']"));
        private IWebElement OldSelectMenuField => driver.FindThisElement(By.XPath("//*[@id='oldSelectMenu']"));
        private IWebElement TitleAttribute => driver.FindThisElement(By.XPath("//*[contains (@class,'css-1uccc')]"));

        
     
        public void ClickWidgetsBtn() => WidgetsBtn.Click();
        public void ClickSelectMenuBtn() => SelectMenuBtn.ClickElementViaJs(driver);
        public bool GetWidgetsHeaderText() => WidgetsHeaderText.Displayed;
        public bool GetSelectMenuHeaderText() => SelectMenuHeaderText.Displayed;
        public bool GetMenuHeaderText() => MenuHeaderText.Displayed;
        public bool GetSubSubListBtn() => SubSubListElement.Displayed;
        public void ClickMenuBtn() => MenuBtn.ClickElementViaJs(driver);
        public void HoverMouseOnMainItem2() => actions.MoveToElement(MainItem2Element).Perform();
        public void HoverMouseOnSubSubList() => actions.MoveToElement(SubSubListElement).Perform();
        public void HoverMouseOnSubSubItems() 
        {
            actions.MoveToElement(SubSubItem1Element).Perform();
            actions.MoveToElement(SubSubItem2Element).Perform();
        }
        public string GetSubSubItem1Btn() => SubSubItem1Element.Text;
        public string GetSubSubItem2Btn() => SubSubItem2Element.Text;
        public void EnterTitle(string value)
        {
            Thread.Sleep(2000);
            TitleOption.SendKeys(value + Keys.Enter);
        }
        public void SelectColourOption(string text)
        {
            Thread.Sleep(1000);
            new SelectElement(OldSelectMenuField).SelectByText(text);
        }
        public string GetColourText() => OldSelectMenuField.Text;
        public string GetTitleText() => TitleAttribute.Text;
    }
}