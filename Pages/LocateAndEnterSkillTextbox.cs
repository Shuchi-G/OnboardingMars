using MarsOnboardV2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class LocateAndEnterSkillTextbox : CommonDriver
    {

        //Locating and sending input to Language textbox
        public void LocateEnterSkillText(string language)
        {
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(language);
        }
    }
}
