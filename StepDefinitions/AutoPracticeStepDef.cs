using BoDi;
using NUnit.Framework;
using SpecFlowLoginTest.Pageobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowLoginTest.StepDefinitions
{
    [Binding]
    public class AutoPracticeStepDef
    {
        AutoPracticeHomePage autoPracticeHomePage;

        public AutoPracticeStepDef(IObjectContainer _container)
        {
            autoPracticeHomePage = _container.Resolve<AutoPracticeHomePage>();
        }

        [Given(@"User is on automationpractice\.com")]
        public void GivenUserIsOnAutomationpractice_Com() => autoPracticeHomePage.NavigateToSite();

        [When(@"User scroll down to hover mouse on (.*)")]
        public void ScrollDownToHoverMouseOnBlouse(string name) => autoPracticeHomePage.scrollIntoViewofElement(name);

        [When(@"User click (.*) to add item to basket")]
        public void WhenUserClickAddToCartButton(string btnNameAlias) => autoPracticeHomePage.ClickAddToCartButton();

        [When(@"User click proceed to checkout button")]
        public void WhenUserClickProceedToCheckoutButton() => autoPracticeHomePage.ClickProceed();

        [Then(@"User should see '([^']*)' displayed on the page")]
        public void UserShouldSeeDisplayedOnThePage(string expectedHeaderText)
        {
            var actualHeaderText = autoPracticeHomePage.GetPageHeader();
            Assert.IsTrue(actualHeaderText.Contains(expectedHeaderText));
        }

        [Then(@"User should also see item selected '([^']*)' under discription")]
        public void SeeItemSelectedUnderDiscription(string expectedItem)
        {
            var actualItem = autoPracticeHomePage.GetSelectedItem();
            Assert.IsTrue(actualItem.Contains(expectedItem));
        }

        [Then(@"User should validate that Qty is equal to (.*)")]
        public void ShouldValidateThatQtyIsEqualTo(string expectedValue)
        {
            var IsItemQtyDisplayed = autoPracticeHomePage.GetItemQty();
            Assert.IsTrue(IsItemQtyDisplayed);
            //var actualVlaue = autoPracticeHomePage.GetItemQty();
            //Assert.IsTrue(actualVlaue.Contains((expectedValue).ToString()));
        }

        [Then(@"Following are the price breakdown of the selected item")]
        public void PriceBreakdownOfTheSelectedItem(Table table)
        {
            //dynamic tableDetails = table.CreateDynamicInstance();
            //List<string> priceBreakDown = autoPracticeHomePage.GetPriceBreakDown();
            //Assert.AreEqual(tableDetails.Totalproducts, priceBreakDown[0]);
            //Assert.AreEqual(tableDetails.Totalshipping, priceBreakDown[1]);
            //Assert.AreEqual(tableDetails.Total, priceBreakDown[2]);
            //Assert.AreEqual(tableDetails.Tax, priceBreakDown[3]);

            //bool IsPriceBreakDownEquls = autoPracticeHomePage.GetPriceBreakDown(table);
            //Assert.IsTrue(IsPriceBreakDownEquls);

            dynamic tableDetails = table.CreateDynamicInstance();
            List<dynamic> items = new List<dynamic>();
            //items.Add(tableDetails.Totalproducts);
            //items.Add(tableDetails.Totalshipping);
            //items.Add(tableDetails.Total);
            //items.Add(tableDetails.Tax);

            foreach (var item in table.Rows.FirstOrDefault().Values)
            {
                items.Add(item);
            }
            List<string> priceBreakDown = autoPracticeHomePage.GetPriceBreakDown();
            Assert.AreEqual(items, priceBreakDown);
        }
    }
}