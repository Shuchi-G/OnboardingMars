using MarsOnboardV2.Drivers;
using MarsOnboardV2.Pages;
using MarsOnboardV2.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace MarsOnboardV2.StepDefinitions
{
    [Binding]
    public class SkillStepDefinitions : CommonDriver
    {
        AddSkillPage skillPageObj = new AddSkillPage();
        ContentReadSkill readLanguageObj = new ContentReadSkill();
        LocateAndClickAddNewSkill addButtonObj = new LocateAndClickAddNewSkill();
        DeleteSkillPage deletePageObj = new DeleteSkillPage();
        EditSkillPage editSkillPageObj = new EditSkillPage();

        [Given(@"Skill Tab is selected in Profile Page")]
        public void GivenSkillTabIsSelectedInProfilePage()
        {
           // Navigating to Skill Page
            IWebElement skillTab = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillTab.Click();
            Console.WriteLine("Mars portal is Starting");
        }

        [When(@"I click on cross icon buttons")]
        public void WhenIClickOnCrossIconButtons()
        {
            deletePageObj.DeleteSkill();
        }

        [Then(@"Existing skill delete successfully")]
        public void ThenExistingSkillDeleteSuccessfully()
        {
            try
            {
                driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            }
            catch (NoSuchElementException)
            {
                Assert.Pass("All Skills are deleted");

            }
        }

        [When(@"I click on add New buttons")]
        public void WhenIClickOnAddNewButtons()
        {
            skillPageObj.AddSkill();
        }

        [When(@"I give input '([^']*)','([^']*)' of skill")]
        public void WhenIGiveInputOfSkill(string skill, string level)
        {
            skillPageObj.InputSkill(skill, level);
        }

        [Then(@"'([^']*)' should be added in")]
        public void ThenShouldBeAddedIn(string skill)
        {
            Thread.Sleep(5000);
            IWebElement skillRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(skillRead.Text, Is.EqualTo(skill), "Skill is not added");
        }

        [When(@"I click on add New buttons to give invalid input")]
        public void WhenIClickOnAddNewButtonsToGiveInvalidInput()
        {
            addButtonObj.LocateClickAddNew();
        }

        [When(@"I give space as input <'([^']*)'>,<'([^']*)'> for skill")]
        public void WhenIGiveSpaceAsInputForSkill(string skill, string level)
        {
            skillPageObj.SpaceInput(skill = " ", level = "Expert");
        
    }

        [Then(@"<'([^']*)'> should not added")]
        public void ThenShouldNotAdded(string skill)
        {
            try
            {
                Thread.Sleep(5000);
                IWebElement skillRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                Assert.That(!string.IsNullOrEmpty(skillRead.Text), "Space should not be added");
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }

        [When(@"I give input <'([^']*)'> to skill but not choosen level of skill")]
        public void WhenIGiveInputToSkillButNotChoosenLevelOfSkill(string skill)
        {
            skillPageObj.NotChoosingLevel(skill = "qwer");
        }

        [Then(@"<'([^']*)'> should not be added in")]
        public void ThenShouldNotBeAddedIn(string skill)
        {

            Thread.Sleep(5000);
            IWebElement skillRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(skillRead.Text, !Is.EqualTo(skill), "skill should not be added");
        }
    

        [When(@"I give existing input '([^']*)','([^']*)'  of skill")]
        public void WhenIGiveExistingInputOfSkill(string skill, string level)
        {
            skillPageObj.DuplicateInput(skill, level);
        }

    

    [Then(@"Duplicate '([^']*)' should not be added in")]
        public void ThenDuplicateShouldNotBeAddedIn(string skill)
        {
            Thread.Sleep(3000);

            int i = 1;
            while (true)
            {

                try
                {
                    string path = "//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]";
                    IWebElement contentLanguage = driver.FindElement(By.XPath(path));
                    Thread.Sleep(3000);
                    if (string.IsNullOrEmpty(contentLanguage.Text))
                        break;
                    if (contentLanguage.Text == skill && i != 1)
                        Assert.Fail("Duplicate language should not be added");
                    break;

                    i = i + 1;
                }
                catch (Exception) { Console.WriteLine(" "); }
            }
        }

        [When(@"I click on pencil icon buttons")]
        public void WhenIClickOnPencilIconButtons()
        {
            editSkillPageObj.EditSkill();
        }

        [When(@"I update skill and level of skill")]
        public void WhenIUpdateSkillAndLevelOfSkill()
        {
            editSkillPageObj.InputEditSkill(driver);
        }

        [Then(@"skill and level should be updated")]
        public void ThenSkillAndLevelShouldBeUpdated()
        {
            Thread.Sleep(3000);
            IWebElement skillRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            Assert.That(skillRead.Text, Is.EqualTo("Selenium"), "Skill is not Updated");
        }
    }
}
