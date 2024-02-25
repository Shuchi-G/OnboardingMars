using MarsOnboardV2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class SkillLevelOptions : CommonDriver
    {
        //Locating and clicking the Level dropdown
        public void LevelOptions(string level)
        {
            IWebElement levelDropdown = driver.FindElement(By.Name("level"));
            levelDropdown.Click();

            //Navigating through the level options
            if (level == "Beginner")
            {
                IWebElement optionValue = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
                optionValue.Click();
            }
            if (level == "Intermediate")
            {
                IWebElement optionValue = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
                optionValue.Click();
            }
            if (level == "Expert")
            {
                IWebElement optionValue = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[4]"));
                optionValue.Click();

            }

        }
    }
}
