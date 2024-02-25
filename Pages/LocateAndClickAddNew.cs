using OpenQA.Selenium;
using MarsOnboardV2.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class LocateAndClickAddNew : CommonDriver
    {
        //Locating and clicking Add New button
        public void LocateClickAddNew()
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
        }
    }
}
