
using DirectLineSwagLabs.Drivers;
using DirectLineSwagLabs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DirectLineSwagLabs.Steps;

[Binding]
public class Login
{
    public LoginPage LoginPage = new LoginPage();
    public HomePage HomePage = new HomePage();
    
    [Given(@"Users go to the Log in page")]
    public void GivenUsersGoToTheLogInPage()
    {
        Driver.GetDriver().Url = "https://www.saucedemo.com/";
    }

    [When(@"Type ""(.*)"" and ""(.*)"" in the input boxes")]
    public void WhenTypeAndInTheInputBoxes(string username, string password)
    {
       LoginPage.Login(username, password);
    }

    [When(@"Click Login button")]
    public void WhenClickLoginButton()
    {
        LoginPage.LoginButton.Click();
        
    }

    [Then(@"Verify that user should be able to see url that contains ""(.*)""")]
    public void ThenVerifyThatUserShouldBeAbleToSeeUrlThatContains(string url)
    {
        WebDriverWait wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/span[@class='title']")));
        string currentUrl = Driver.GetDriver().Url;
        Assert.IsTrue(currentUrl.Contains(url));
    }
    
    [When(@"Type ""(.*)"" as username and ""(.*)"" as password")]
    public void WhenTypeAsUsernameAndAsPassword(string username, string password)
    {
        LoginPage.Login(username, password);
    }

    [Then(@"Verify that user should be able to see error message ""(.*)""")]
    public void ThenVerifyThatUserShouldBeAbleToSeeErrorMessage(string errorMessage)
    {
        string actualErrorMessage = LoginPage.ErrorMessage.Text;
        Assert.AreEqual(errorMessage, actualErrorMessage);
    }

    [Then(@"verify that user should be able see entered password as bullet signs")]
    public void ThenVerifyThatUserShouldBeAbleSeeEnteredPasswordAsBulletSigns()
    {
        string inputType = LoginPage.Password.GetAttribute("type");
        Assert.AreEqual("password", inputType);
    }

    
}