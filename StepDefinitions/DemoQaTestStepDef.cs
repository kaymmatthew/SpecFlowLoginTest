using BoDi;
using NUnit.Framework;
using SpecFlowLoginTest.Pageobjects;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowLoginTest.StepDefinitions
{
    [Binding]
    public sealed class DemoQaTestStepDef
    {
        BookStorePage bookStorePage;
        LoginPage loginPage;
        WidgetsPage widgetsPage;

        public DemoQaTestStepDef(IObjectContainer _container)
        {
            bookStorePage = _container.Resolve<BookStorePage>();
            loginPage = _container.Resolve<LoginPage>();
            widgetsPage = _container.Resolve<WidgetsPage>();
        }

        [Given(@"User is on demoqa\.com")]
        public void GivenIAmOnDemoqa_Com() => loginPage.NavigateToSite();
   

        [When(@"User click on '(.*)'")]
        public void WhenIClick(string nameAlis) => bookStorePage.ClickBookStoreApplication();


        [When(@"User click on login button")]
        public void WhenIClickLoginButton() => loginPage.Clicklogin();

        //[Then(@"User is on (.*) page")]
        //public void ThenUserIsOnProfilePage(string expectedHeaderText) 
        //{
        //    var actualHeaderText = loginPage.GetProfileHeader();
        //    Assert.AreEqual(expectedHeaderText, actualHeaderText);
        //}
        //[Then(@"User is presented with '([^']*)' page")]
        //public void ThenUserIsPresentedWithPage(string expectedHeaderText)
        //{
        //    var actualHeaderText = loginPage.GetProfileHeader();
        //    Assert.AreEqual(expectedHeaderText, actualHeaderText);   
        //}

        //[Then(@"User click on Go To Book Store button")]
        //public void UserClickOnGoToBookStoreButton() => loginPage.ClickGoToBookStoreBtn();  

        [When(@"User click on New User button")]
        public void WhenIClickNewUserButton()
        {
            loginPage.ClickNewUser();
        }

        [When(@"User enter login user details")]
        public void WhenIEnterLoginUserDetails(Table table)
        {
            dynamic tableDetails = table.CreateDynamicInstance();
            loginPage.EnterLoginDetails(tableDetails.FirstName, tableDetails.LastName, tableDetails.UserName, tableDetails.Password);
        }

        [Then(@"'([^']*)' button is vissible")]
        public void ThenButtonIsVissible(string btnName)
        {
            Assert.IsTrue(loginPage.isBackToLoginBtnDisplayed(), "Not Displayed");
        }

        [Then(@"User is on the (.*) page")]
        public void ThenIAmOnLoginPage(string expectedPageHeader)
        {
            var actualPageHeader = loginPage.GetLoginHeaderText();
            Assert.AreEqual(expectedPageHeader, actualPageHeader);
        }

        [Then(@"User is on '([^']*)' page")]
        public void ThenIAmOnPage(string expectedPageHeader)
        {
            var actualPageHeader = bookStorePage.GetBookStoreHeaderText();
            Assert.AreEqual(expectedPageHeader, actualPageHeader);
        }

        [When(@"User enter user login details")]
        public void WhenIEnterUserLoginDetails(Table table)
        {
            dynamic tableDetails = table.CreateDynamicInstance();
            loginPage.LoginDetails(tableDetails.UserName, tableDetails.Password);
        }

        [Then(@"User should be on the (.*) page")]
        public void ThenIAmOnBookStore(string expectedPageHeader)
        {
            var actualPageHeader = bookStorePage.GetBookStoreHeaderText();
            Assert.AreEqual(expectedPageHeader, actualPageHeader);
        }

        [When(@"User click on LogOut Button")]
        public void WhenIClickLogOutButton() => loginPage.ClickLogOutBtn();

        [When(@"User click on Widgets button")]
        public void WhenUserClickOnWidgets() => widgetsPage.ClickWidgetsBtn();

        [Then(@"User is on Widgets page")]
        public void ThenUserIsOnWidgetsPage()
        {
            var IsWidgetsHeaderTextDisplayed = widgetsPage.GetWidgetsHeaderText();
            Assert.IsTrue(IsWidgetsHeaderTextDisplayed);
        }

        [Then(@"User scroll down to click Menu on Widgets page")]
        public void ScrollDownToClickMenuOnWidgetsPage() => widgetsPage.ClickMenuBtn();

        [Then(@"User is on Menu page")]
        public void ThenUserIsOnMenuPage()
        {
            var IsMenuHeaderTextDisplayed = widgetsPage.GetMenuHeaderText();
            Assert.IsTrue(IsMenuHeaderTextDisplayed);
        }

        [When(@"User hover mouse on (.*) dropdwon menu btn")]
        public void HoverMouseOnMainItemDropdwonMenuBtn(string mhover) => widgetsPage.HoverMouseOnMainItem2();

        [Then(@"User is presented with a dropdown that contains Sub Sub Lists")]
        public void PresentedWithADropdownThatContainsSubSubLists()
        {
            var IsSubSubListsBtnDisplayed = widgetsPage.GetSubSubListBtn();
            Assert.IsTrue(IsSubSubListsBtnDisplayed);
        }

        [Then(@"User hover mouse on Sub Sub Lists")]
        public void ThenUserHoverMouseOnSubSubLists() => widgetsPage.HoverMouseOnSubSubList();

        [Then(@"User is presented with (.*) and (.*)")]
        public void PresentedWithSubSubItemAndSubSubItem(string expectedText1, string expectedText2)
        {
            widgetsPage.HoverMouseOnSubSubItems();
            Assert.Multiple(() =>
            {
                var actualText1 = widgetsPage.GetSubSubItem1Btn();
                Assert.AreEqual(expectedText1, actualText1);
                var actualText12 = widgetsPage.GetSubSubItem2Btn();
                Assert.AreEqual(expectedText2, actualText12);
            });
        }

        [Then(@"User scroll down to click Select Menu on Widgets page")]
        public void ScrollDownToClickSelectMenuOnWidgetsPage()=> widgetsPage.ClickSelectMenuBtn();

        [Then(@"User is on Select Menu page")]
        public void ThenUserIsOnSelectMenuPage()
        {
            var IsSelectMenuHeaderDisplayed = widgetsPage.GetSelectMenuHeaderText();
            Assert.IsTrue(IsSelectMenuHeaderDisplayed);
        }

        [When(@"User click (.*) on Select One dropdown")]
        public void ClickMrFromDropdown(string title) => widgetsPage.EnterTitle(title);

        [Then(@"User should see selected Title (.*) in the Select One field")]
        public void SelectTitleOptionFromDropdown(string expectedtitle)
        {
            var actualTitle = widgetsPage.GetTitleText();
            Assert.IsTrue(actualTitle.Contains(expectedtitle));
        }

        [Then(@"User select (.*) on Old Style Select Menu dropdown")]
        public void SelectColourOptionFromDropdown(string colourOption) => widgetsPage.SelectColourOption(colourOption);

        [Then(@"User should see the colour selected (.*) in the Old Style Select Menu field")]
        public void UserShouldSeeSlectedColour(string expectedColour)
        {
            var actualColour = widgetsPage.GetColourText();
            Assert.IsTrue(actualColour.Contains(expectedColour));
        }
    }
}