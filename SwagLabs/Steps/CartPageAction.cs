
using DirectLineSwagLabs.Drivers;
using DirectLineSwagLabs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DirectLineSwagLabs.Steps;

[Binding]
public class CartPageAction
{
    public CartPage CartPage = new CartPage();
    public HomePage HomePage = new HomePage();
    
    [When(@"click shopping cart icon")]
    public void WhenClickShoppingCartIcon()
    {
        HomePage.ShoppingCart.Click();
    }

    [When(@"click continue shopping button")]
    public void WhenClickContinueShoppingButton()
    {
        CartPage.ContinueShoppingButton.Click();
    }

    [When(@"add another item to cart")]
    public void WhenAddAnotherItemToCart()
    {
        HomePage.AddToCartSecondItemButton.Click();
    }

    [Then(@"verify that all items are added to cart")]
    public void ThenVerifyThatAllItemsAreAddedToCart()
    {
        HomePage.ShoppingCart.Click();
        Assert.AreEqual("2", HomePage.ShoppingCartBadgeNumber.Text);
    }

    [When(@"remove all items from cart")]
    public void WhenRemoveAllItemsFromCart()
    {
        HomePage.ShoppingCart.Click();
        CartPage.RemoveButton1.Click();
        CartPage.RemoveButton1.Click();
    }

    [Then(@"verify that all items are removed successfully")]
    public void ThenVerifyThatAllItemsAreRemovedSuccessfully()
    {
        List<WebElement> list = new List<WebElement>();
        try
        {
            list.Add((WebElement)HomePage.ShoppingCartBadgeNumber);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Assert.True(0 == list.Count);
    }

    [When(@"click checkout button")]
    public void WhenClickCheckoutButton()
    {
        CartPage.CheckoutButton.Click();
    }

    [When(@"click cancel button")]
    public void WhenClickCancelButton()
    {
        CartPage.CancelButton.Click();
    }

    [Then(@"verify that url contains ""(.*)""")]
    public void ThenVerifyThatUrlContains(string url)
    {
        string actualUrl = Driver.GetDriver().Url;
        Assert.True(actualUrl.Contains(url));
    }
    
    [Then(@"type first name ""(.*)"" last name ""(.*)"" and zip code ""(.*)""")]
    public void ThenTypeFirstNameLastNameAndZipCode(string firstname, string lastname, string zipcode)
    {
        CartPage.FirstNameBox.SendKeys(firstname);
        CartPage.LastNameBox.SendKeys(lastname);
        CartPage.ZipBox.SendKeys(zipcode);
    }
    
    
    [Then(@"click continue button")]
    public void ThenClickContinueButton()
    {
        CartPage.ContinueButton.Click();
    }
    
    [Then(@"verify that error message is displayed error message")]
    public void ThenVerifyThatErrorMessageIsDisplayedErrorMessage()
    {
        List<string> expectedErrorMessages = new List<string>()
            { "Error: First Name is required", "Error: Last Name is required", "Error: Postal Code is required" };
        
        string actualErrorMessage = CartPage.ErrorMessage.Text;
        Assert.True(expectedErrorMessages.Contains(actualErrorMessage));
    }

    [When(@"type first name ""(.*)"" and last name ""(.*)""")]
    public void WhenTypeFirstNameAndLastName(string john, string doe)
    {
        CartPage.FirstNameBox.SendKeys(john);
        CartPage.LastNameBox.SendKeys(doe);
    }

    [When(@"type zip code ""(.*)""")]
    public void WhenTypeZipCode(string asdfg)
    {
        CartPage.ZipBox.SendKeys(asdfg);
    }

    [Then(@"verify that user should not be able to continue")]
    public void ThenVerifyThatUserShouldNotBeAbleToContinue()
    {
        CartPage.ContinueButton.Click();
        string url = "checkout-step-two.html";
        Assert.False(Driver.GetDriver().Url.Contains(url), "Zip Code Must Contain Digit");
    }

    [When(@"type first name ""(.*)"" last name ""(.*)"" and zip code ""(.*)""")]
    public void WhenTypeFirstNameLastNameAnd(string firstName, string lastName, string zipCode)
    {
        CartPage.FirstNameBox.SendKeys(firstName);
        CartPage.LastNameBox.SendKeys(lastName);
        CartPage.ZipBox.SendKeys(zipCode);
    }
    
    
    [Then(@"verify that user should not be able to move forward")]
    public void ThenVerifyThatUserShouldNotBeAbleToMoveForward()
    {
        CartPage.ContinueButton.Click();
        string url = "checkout-step-two.html";
        Assert.False(Driver.GetDriver().Url.Contains(url), "FirstName and LastName Should Not Have Digits or Special Character and Zip Code Should Not have Special Character");
    }
    

    [When(@"click reset app state button")]
    public void WhenClickResetAppStateButton()
    {
        HomePage.HamburgerMenuResetAppState.Click();
    }

    [Then(@"verify that shopping cart badge number disappear")]
    public void ThenVerifyThatShoppingCartBadgeNumberDisappear()
    {
        List<WebElement> list = new List<WebElement>();
        try
        {
            list.Add((WebElement)HomePage.ShoppingCartBadgeNumber);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Assert.True(0 == list.Count);
    }

    [Then(@"verify that remove button replace add to cart button")]
    public void ThenVerifyThatRemoveButtonReplaceAddToCartButton()
    {
        Assert.IsNull(HomePage.RemoveButton.Text);
    }
    
    [Then(@"verify that remove button replace add to cart button successfully")]
    public void ThenVerifyThatRemoveButtonReplaceAddToCartButtonSuccessfully()
    {
        List<WebElement> list = new List<WebElement>();
        try
        {
            list.Add((WebElement)HomePage.RemoveButton);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Assert.True(0 == list.Count);
    }

    [When(@"click close button")]
    public void WhenClickCloseButton()
    {
        HomePage.HamburgerMenuCloseButton.Click();
    }
    

    [Then(@"verify that total price is correct")]
    public void ThenVerifyThatTotalPriceIsCorrect()
    {
        Double firstItemPrice = Double.Parse(CartPage.Price1.Text.Substring(1));
        Double secondItemPrice = Double.Parse(CartPage.Price2.Text.Substring(1));
        Double taxPrice = Double.Parse(CartPage.Tax.Text.Substring(6));
        Double totalPrice = Double.Parse(CartPage.Total.Text.Substring(8));

        Assert.True(firstItemPrice + secondItemPrice + taxPrice == totalPrice);
    }

    [Then(@"click finish button")]
    public void ThenClickFinishButton()
    {
        CartPage.FinishButton.Click();
    }

    [Then(@"verify that order is completed")]
    public void ThenVerifyThatOrderIsCompleted()
    {
        string expectedMessage = "Thank you for your order!";
        Assert.AreEqual(expectedMessage, CartPage.ThankYou.Text);
    }

    [Then(@"click back home button")]
    public void ThenClickBackHomeButton()
    {
        CartPage.BackHomeButton.Click();
    }

    [Then(@"verify that user should be able to access home page")]
    public void ThenVerifyThatUserShouldBeAbleToAccessHomePage()
    {
        string url = "/inventory.html";
        Assert.True(Driver.GetDriver().Url.Contains(url));
    }


    
}