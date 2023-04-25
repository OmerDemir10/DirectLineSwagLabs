using DirectLineSwagLabs.Drivers;
using OpenQA.Selenium;

namespace DirectLineSwagLabs.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    public LoginPage()
    {
        _driver = Driver.GetDriver();
    }

    public IWebElement UserName => _driver.FindElement(By.Id("user-name"));
    public IWebElement Password => _driver.FindElement(By.Id("password"));
    public IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
    public IWebElement LoginLogo => _driver.FindElement(By.ClassName("login_logo"));
    public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3"));
    public IWebElement ErrorMessageClose => _driver.FindElement(By.XPath("//*[local-name()='svg' and @data-icon='times']/*[local-name()='path']"));

    public void Login(string username, string password)
    {
        UserName.SendKeys(username);
        Password.SendKeys(password);
    }

    public void LoginStandardUser()
    {
        UserName.SendKeys("standard_user");
        Password.SendKeys("secret_sauce"); 
        LoginButton.Click();
    }
}