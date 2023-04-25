using DirectLineSwagLabs.Drivers;
using OpenQA.Selenium;


namespace DirectLineSwagLabs.Pages;

public class CartPage
{
    private readonly IWebDriver _driver;
    public CartPage()
    {
        _driver = Driver.GetDriver();
    }

    public IWebElement ContinueShoppingButton => _driver.FindElement(By.Id("continue-shopping"));
    public IWebElement RemoveButton1 => _driver.FindElement(By.XPath("//button[@class='btn btn_secondary btn_small cart_button']"));
    public IWebElement RemoveButton2 => _driver.FindElement(By.XPath("(//button[@class='btn btn_secondary btn_small cart_button'])[2]"));
    public IWebElement RemoveButton3 => _driver.FindElement(By.XPath("(//button[@class='btn btn_secondary btn_small cart_button'])[3]"));
    public IWebElement RemoveButton4 => _driver.FindElement(By.XPath("(//button[@class='btn btn_secondary btn_small cart_button'])[4]"));
    public IWebElement RemoveButton5 => _driver.FindElement(By.XPath("(//button[@class='btn btn_secondary btn_small cart_button'])[5]"));
    public IWebElement RemoveButton6 => _driver.FindElement(By.XPath("(//button[@class='btn btn_secondary btn_small cart_button'])[6]"));
    public IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));
    public IWebElement CancelButton => _driver.FindElement(By.Id("cancel"));
    public IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));
    public IWebElement FirstNameBox => _driver.FindElement(By.Id("first-name"));
    public IWebElement LastNameBox => _driver.FindElement(By.Id("last-name"));
    public IWebElement ZipBox => _driver.FindElement(By.Id("postal-code"));
    public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//div/h3[@data-test='error']"));
    // Error: First Name is required - Error: Last Name is required - Error: Postal Code is required
    public IWebElement FinishButton => _driver.FindElement(By.Id("finish"));
    public IWebElement Price1 => _driver.FindElement(By.XPath("//div/div[@class='inventory_item_price']"));
    public IWebElement Price2 => _driver.FindElement(By.XPath("(//div/div[@class='inventory_item_price'])[2]"));
    public IWebElement Price3 => _driver.FindElement(By.XPath("(//div/div[@class='inventory_item_price'])[3]"));
    public IWebElement Price4 => _driver.FindElement(By.XPath("(//div/div[@class='inventory_item_price'])[4]"));
    public IWebElement Tax => _driver.FindElement(By.XPath("//div[@class='summary_tax_label']"));
    public IWebElement Total => _driver.FindElement(By.XPath("//div[@class='summary_info_label summary_total_label']"));
    public IWebElement ThankYou => _driver.FindElement(By.XPath("//div[@id='checkout_complete_container']/h2"));
    public IWebElement BackHomeButton => _driver.FindElement(By.Id("back-to-products"));
    
    
    
    
}