using MarsOnboardV2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class DeleteAnExistingLanguage : CommonDriver
    {
        //Deleting an existing language to add new input 
        public void DeletingLanguage()
        {
            IWebElement removeIconButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            removeIconButton.Click();
        }
    }
}
