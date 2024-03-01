using OpenQA.Selenium;
using MarsOnboardV2.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class LocateAndEnterLanguageTextbox : CommonDriver
    {
        //Locating and sending input to Language textbox
        public void LocateEnterLangText(string language)
        {
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(language);
        }
    }
}
