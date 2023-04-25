
using DirectLineSwagLabs.Drivers;
using DirectLineSwagLabs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace DirectLineSwagLabs.Steps;

[Binding]
public class Logout
{
    public HomePage HomePage = new HomePage();
    public LoginPage LoginPage = new LoginPage();
    
    [Given(@"Users go to the Login page")]
    public void GivenUsersGoToTheLoginPage()
    {
        Driver.GetDriver().Url = "https://www.saucedemo.com/";
    }

    [When(@"Users login with valid credentials")]
    public void WhenUsersLoginWithValidCredentials()
    {
        HomePage.Login("standard_user", "secret_sauce");
    }

    [When(@"click hamburger menu that is top left on the homepage")]
    public void WhenClickHamburgerMenuThatIsTopLeftOnTheHomepage()
    {
        HomePage.HamburgerMenu.Click();
    }

    [When(@"click Logout button")]
    public void WhenClickLogoutButton()
    {
        HomePage.HamburgerMenuLogout.Click();
    }

    [Then(@"verify that user should be able to log out")]
    public void ThenVerifyThatUserShouldBeAbleToLogOut()
    {
        string currentUrl = Driver.GetDriver().Url;
        Assert.IsFalse(currentUrl.Contains("inventory.html"));
    }

    [When(@"open new tab and login with same credentials")]
    public void WhenOpenNewTabAndLoginWithSameCredentials()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.GetDriver();
        js.ExecuteScript("window.open()");
        List<string> sessionIDs = new List<string>(Driver.GetDriver().WindowHandles);
        Driver.GetDriver().SwitchTo().Window(sessionIDs[1]);
        Driver.GetDriver().Url = "https://www.saucedemo.com/";
        LoginPage.LoginStandardUser();
    }

    [Then(@"verify that user should NOT be able to do anything in the another open homepage")]
    public void ThenVerifyThatUserShouldNotBeAbleToDoAnythingInTheAnotherOpenHomepage()
    {
        List<string> sessionIDs = new List<string>(Driver.GetDriver().WindowHandles);
        Driver.GetDriver().SwitchTo().Window(sessionIDs[0]);
        HomePage.FirstItem.Click();
        string currentUrl = Driver.GetDriver().Url;
        Assert.IsFalse(currentUrl.Contains("inventory.html"));
    }

    [When(@"close the single tab")]
    public void WhenCloseTheSingleTab()
    {
        Driver.CloseDriver();
    }

    [When(@"open new browser and go to login page")]
    public void WhenOpenNewBrowserAndGoToLoginPage()
    {
        Driver.GetDriver().Url = "https://www.saucedemo.com/";
    }

    [Then(@"verify that user should NOT be able to go back home page")]
    public void ThenVerifyThatUserShouldNotBeAbleToGoBackHomePage()
    {
        string currentUrl = Driver.GetDriver().Url;
        Assert.IsFalse(currentUrl.Contains("inventory.html"));
    }

    [When(@"click Log out button")]
    public void WhenClickLogOutButton()
    {
        HomePage.HamburgerMenuLogout.Click();
    }

    [When(@"click back button")]
    public void WhenClickBackButton()
    {
        Driver.GetDriver().Navigate().Back();
    }

    [When(@"press shortcut key to go to previous web page")]
    public void WhenPressShortcutKeyToGoToPreviousWebPage()
    {
        Actions actions = new Actions(Driver.GetDriver());
        actions.MoveToElement(LoginPage.UserName).Click().KeyDown(Keys.Command).SendKeys(Keys.ArrowLeft).Perform();

    }
}