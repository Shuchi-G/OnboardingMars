using MarsOnboardV2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Pages
{
    public class EditSkillPage : CommonDriver
    {
        public void EditSkill()
        {

            //Locate Pencil icon button and click
            IWebElement pencilButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            pencilButton.Click();
            Thread.Sleep(3000);
        }
        public void InputEditSkill(IWebDriver driver)

        {

            //Locate existing skill, remove it and add new skill
            IWebElement updateSkillTextbox = driver.FindElement(By.Name("name"));
            updateSkillTextbox.Clear();
            updateSkillTextbox.SendKeys("Selenium");

            //Locate Update level dropdown, click and choose fluent
            IWebElement updateLevelDropdown = driver.FindElement(By.Name("level"));
            updateSkillTextbox.Click();
            IWebElement chooseOption = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select/option[3]"));
            chooseOption.Click();

            //Locate Update button and click
            IWebElement updateButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            updateButton.Click();

        }
    }
}
