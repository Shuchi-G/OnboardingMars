using MarsOnboardV2.Drivers;
using OpenQA.Selenium.Chrome;
using MarsOnboardV2.Pages;

namespace MarsOnboardV2.Hooks
{
    [Binding]
    public sealed class Hooks1 : CommonDriver
    {

   //     [BeforeScenario("@tag1")]
     //   public void BeforeScenarioWithTag()
       // {

        //}

        [BeforeScenario()]
        public void FirstBeforeScenario()
        {

            driver = new ChromeDriver();
            SignInPage signInPageObj = new SignInPage();
            signInPageObj.LoginActions();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}