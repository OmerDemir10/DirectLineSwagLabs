
using DirectLineSwagLabs.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace DirectLineSwagLabs.Steps;

[Binding]
public class HomePageAction
{
    public HomePage HomePage = new HomePage();
    
    [Then(@"user should be able to see four options")]
    public void ThenUserShouldBeAbleToSeeFourOptions()
    {
        List<string> fourOptions = new List<string>() { "All Items", "About", "Logout", "Reset App State" };
        List<string> currentFourOptions = new List<string>();
        Thread.Sleep(1000);
        currentFourOptions.Add(HomePage.HamburgerMenuAllItems.Text);
        currentFourOptions.Add(HomePage.HamburgerMenuAbout.Text);
        currentFourOptions.Add(HomePage.HamburgerMenuLogout.Text);
        currentFourOptions.Add(HomePage.HamburgerMenuResetAppState.Text);
        /*string concat = string.Join(", ", currentFourOptions);
        Console.WriteLine(concat);
        */
        for (int i = 0; i < fourOptions.Count; i++)
        {
            Assert.AreEqual(fourOptions[i], currentFourOptions[i]); 
        }
    }

    [Then(@"user should be able to close the menu")]
    public void ThenUserShouldBeAbleToCloseTheMenu()
    {
        HomePage.HamburgerMenuCloseButton.Click();
        Assert.NotNull(HomePage.ProductsTitle);
    }

    [When(@"click product sort container button and change the items order from z to a")]
    public void WhenClickProductSortContainerButtonAndChangeTheItemsOrderFromZToA()
    { 
        HomePage.ShoppingCartContainer.Click();
        SelectElement select = new SelectElement( HomePage.ShoppingCartContainer );
        select.SelectByValue("za");
        Thread.Sleep(3000);
    }

    [Then(@"verify that items list is changed z to a")]
    public void ThenVerifyThatItemsListIsChangedZToA()
    {
        string currentFirstItem = HomePage.EveryTimeFirstItemTitle.Text;
        string expectedFirstItem = "Test.allTheThings() T-Shirt (Red)";
        Assert.AreEqual(expectedFirstItem, currentFirstItem);
    }

    [Then(@"click product sort container button and change the items order from low price to high")]
    public void ThenClickProductSortContainerButtonAndChangeTheItemsOrderFromLowPriceToHigh()
    {
        HomePage.ShoppingCartContainer.Click();
        SelectElement select = new SelectElement( HomePage.ShoppingCartContainer );
        select.SelectByValue("lohi");
    }
    
    [Then(@"verify that items list is changed low to high")]
    public void ThenVerifyThatItemsListIsChangedLowToHigh()
    {
        string currentFirstItem = HomePage.EveryTimeFirstItemTitle.Text;
        string expectedFirstItem = "Sauce Labs Onesie";
        Assert.AreEqual(expectedFirstItem, currentFirstItem);
    }

    [When(@"click item to add chart")]
    public void WhenClickItemToAddChart()
    {
        HomePage.AddToCartFirstItemButton.Click();
    }

    [Then(@"verify that shopping cart badge increase one")]
    public void ThenVerifyThatShoppingCartBadgeIncreaseOne()
    {
        Assert.AreEqual("1", HomePage.ShoppingCartBadgeNumber.Text);
    }

    [Then(@"verify that add to cart button replace remove button")]
    public void ThenVerifyThatAddToCartButtonReplaceRemoveButton()
    {
        Assert.AreEqual("Remove", HomePage.RemoveButton.Text);
    }

    [Then(@"click shopping cart icon")]
    public void ThenClickShoppingCartIcon()
    {
        HomePage.AddToCartSecondItemButton.Click();
        HomePage.ShoppingCart.Click();
    }

    [Then(@"verify that correct item is added shopping cart")]
    public void ThenVerifyThatCorrectItemIsAddedShoppingCart()
    {
        string actualItemInCart1 = HomePage.EveryTimeFirstItemTitle.Text;
        string actualItemInCart2 = HomePage.EveryTimeSecondItemTitle.Text;
        
        Assert.AreEqual("Sauce Labs Backpack", actualItemInCart1);
        Assert.AreEqual("Sauce Labs Bike Light", actualItemInCart2);
    }


    [Then(@"verify that user should be able to go back homepage")]
    public void ThenVerifyThatUserShouldBeAbleToGoBackHomepage()
    {
        HomePage.FirstItem.Click();
        HomePage.BackToProductsButton.Click();
        Assert.True(HomePage.ProductsTitle.Displayed);
    }

    
}