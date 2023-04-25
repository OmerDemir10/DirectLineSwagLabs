using System;
using DirectLineSwagLabs.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DirectLineSwagLabs.Hooks
{
    [Binding]
    public class Hooks
    {
        [After]
        public void TearDown()
        {
            /*
             if (ScenarioContext.Current.TestError != null)
            {
                Console.WriteLine("An error occurred:" + ScenarioContext.Current.TestError.Message);
                Screenshot screenshot = 
                
            }
            {
                
            }
            livingdoc test-assembly /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/bin/Debug/net6.0/SwagLabs.dll -t /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/bin/Debug/net6.0/TestExecution.json -o /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/TestReport
            */
            Driver.CloseDriver();
        }
    }
}