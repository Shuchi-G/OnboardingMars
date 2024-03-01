using MarsOnboardV2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Support
{
    public class LocateClickAddButtonSkill : CommonDriver
    {

        //Locating and clicking Add button
        public void ClickAddButton()
        {

            IWebElement addButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();

        }
    }
}
