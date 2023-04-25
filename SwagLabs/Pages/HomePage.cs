
using DirectLineSwagLabs.Drivers;
using OpenQA.Selenium;

namespace DirectLineSwagLabs.Pages;

public class HomePage
{
    
    private readonly IWebDriver _driver;
    public HomePage()
    {
        _driver = Driver.GetDriver();
    }
    
    public IWebElement HamburgerMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));
    public IWebElement HamburgerMenuAllItems => _driver.FindElement(By.XPath("//a[@id='inventory_sidebar_link']"));
    public IWebElement HamburgerMenuAbout => _driver.FindElement(By.Id("about_sidebar_link"));
    public IWebElement HamburgerMenuLogout => _driver.FindElement(By.Id("logout_sidebar_link"));
    public IWebElement HamburgerMenuResetAppState => _driver.FindElement(By.Id("reset_sidebar_link"));
    public IWebElement HamburgerMenuCloseButton => _driver.FindElement(By.Id("react-burger-cross-btn"));
    public IWebElement ShoppingCart => _driver.FindElement(By.Id("shopping_cart_container"));
    public IWebElement ShoppingCartContainer => _driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
    public IWebElement FirstItem => _driver.FindElement(By.Id("item_4_title_link"));
    public IWebElement LastItem => _driver.FindElement(By.Id("item_3_title_link"));
    public IWebElement AddToCartFirstItemButton => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
    public IWebElement AddToCartSecondItemButton => _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
    public IWebElement BackToProductsButton => _driver.FindElement(By.Id("back-to-products"));
    public IWebElement ProductsTitle => _driver.FindElement(By.XPath("//div/span[@class='title']"));
    public IWebElement EveryTimeFirstItemTitle => _driver.FindElement(By.XPath("//div[@class='inventory_item_name']"));
    public IWebElement EveryTimeSecondItemTitle => _driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])[2]"));
    public IWebElement EveryTimeFirstItemAddToCartButton => _driver.FindElement(By.XPath("//button[@class='btn btn_primary btn_small btn_inventory']"));
    public IWebElement LowestPriceItem => _driver.FindElement(By.XPath("//a[@id='item_2_title_link']/div"));
    public IWebElement ShoppingCartBadgeNumber => _driver.FindElement(By.XPath("//a/span[@class='shopping_cart_badge']"));
    public IWebElement RemoveButton => _driver.FindElement(By.XPath("//button[@class='btn btn_secondary btn_small btn_inventory']"));



    /*
      List<string> str = new List<string>();
        foreach (var homePageHamburgerMenuOption in HomePage.HamburgerMenuOptions)
        {
            str.Add(homePageHamburgerMenuOption.Text);
        }
        List<string> word = new List<string>(){"All Items", "About", "Logout", "Reset App State"};
        Assert.AreEqual(str, word);
        
        Console.WriteLine(str);
     */
    
    
    
    public LoginPage LoginPage = new LoginPage();
    
    public void Login(string username, string password)
    {
        LoginPage.UserName.SendKeys(username);
        LoginPage.Password.SendKeys(password);
        LoginPage.LoginButton.Click();
    }
    
}

