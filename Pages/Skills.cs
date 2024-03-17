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
    public class Skills : CommonDriver
    {
        public void DeleteSkill()
        {

            //Locate Remove icon button and deleting the existing skill
            try
            {
                while (true)
                {

                    IWebElement removeIconButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                    removeIconButton.Click();
                    Thread.Sleep(2000);
                }
            }

            catch (Exception)
            {
                Assert.Pass("Skill has been removed");
            }

        }
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
        //Locating and clicking Add New button
        public void LocateClickAddNew()
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
        }
        //Locating the Language textbox and reading content
        public string ReadLanguage()
        {
            IWebElement skillRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return skillRead.Text;
        }

        //Locating and clicking Add button
        public void ClickAddButton()
        {

            IWebElement addButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();

        }

        //Locating and sending input to Language textbox
        public void LocateEnterSkillText(string language)
        {
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(language);
        }
        //Locating and clicking Add New button
       /* public void LocateClickAddNew2()
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
        }*/
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
        //Locate Add new button and click
        public void AddSkill()
        {
            LocateClickAddNew();
        }

        //Add Skills including speacial character,numbers,long characters at different levels
        public void InputSkill(string skill, string level)
        {
            LocateEnterSkillText(skill); //Locate Skill textbox and enter skill
            LevelOptions(level); //Locate and click Choose level dropdown,also locate and click option value
            ClickAddButton();  //Locate Add button and click
        }

        //Giving space as input to Skill textbox
        public void SpaceInput(string skill, string level)
        {
            LocateEnterSkillText(skill);
            LevelOptions(level);  //Locate Choose level dropdown and click
            ClickAddButton();//Locate Add button and click
        }

        //Giving valid input to Skill textbox but not choosing Skill level
        public void NotChoosingLevel(string skill)
        {
            LocateEnterSkillText(skill); //Locate Skill textbox and give input
            ClickAddButton();  //Locate Add button and click
        }

        //Giving duplicate input to Skill textbox 
        public void DuplicateInput(string skill, string level)
        {
            LocateEnterSkillText(skill); //Locate skill textbox and enter data
            LevelOptions(level); //Locate Choose level dropdown and click
            ClickAddButton();  //Locate Add button and click
        }
    }
}
