
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DirectLineSwagLabs.Drivers
{
    public class Driver
    {
        private Driver(){}

        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                string browserType = "chrome";

                switch (browserType.ToLower())
                {
                    case "chrome" :
                        _driver = new ChromeDriver("/Users/omerdemir/Downloads/chromedriver_mac64/chromedriver");
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver();
                        break;
                    default:
                        throw new Exception("Invalid browser type: " + browserType);
                }
                
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

            return _driver;
        }

        public static void CloseDriver()
        {
            if (_driver != null)
            {
              _driver.Quit();
              _driver = null;
            }
        }
        
        
    }
}