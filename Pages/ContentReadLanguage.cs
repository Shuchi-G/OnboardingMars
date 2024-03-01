using MarsOnboardV2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class ContentReadLanguage : CommonDriver
    {
        //Locating the Language textbox and reading content
        public string ReadLanguage()
        {
            IWebElement languageRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return languageRead.Text;
        }
    }
}
