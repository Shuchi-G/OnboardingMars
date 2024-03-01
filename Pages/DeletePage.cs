using MarsOnboardV2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Pages
{
    public class DeletePage : CommonDriver
    {
        public void DeleteLanguage()
        {

            //Locate Remove icon button and deleting the existing language
            try
            {
                while (true)
                {

                    IWebElement removeIconButton = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    removeIconButton.Click();
                    Thread.Sleep(2000);
                }
            }

            catch (Exception ex)
            {
                Assert.Pass("All the languages has been removed");
            }

        }

    }
}
