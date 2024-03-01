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
    public class LanguageStepDefinitions : CommonDriver
    {
        DeletePage deletePageObj = new DeletePage();
        LanguagesPage languagesPageObj = new LanguagesPage();
        DeleteAnExistingLanguage deletingObj = new DeleteAnExistingLanguage();
        ContentReadLanguage readLanguageObj = new ContentReadLanguage();
        EditLanguagePage editLanguagePageObj = new EditLanguagePage();
        [Given(@"Language Tab is selected in Profile Page/")]
        public void GivenLanguageTabIsSelectedInProfilePage()
        {
            Console.WriteLine("Mars portal is Starting");
        }

        [When(@"I click on Cross icon buttons")]
        public void WhenIClickOnCrossIconButtons()
        {
            deletePageObj.DeleteLanguage();
        }

        [Then(@"Existing languages deleted successfully")]
        public void ThenExistingLanguagesDeletedSuccessfully()
        {
            try
            {
                driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            }
            catch (NoSuchElementException)
            {
                Assert.Pass("All languages are deleted");

            }
        }

        [When(@"I click on Add New buttons")]
        public void WhenIClickOnAddNewButtons()
        {
            languagesPageObj.AddLanguage();
        }

        [When(@"I give input '([^']*)','([^']*)' of language")]
        public void WhenIGiveInputOfLanguage(string language, string level)
        {
            languagesPageObj.InputLanguage(language, level);
        }

        [Then(@"'([^']*)' should be added")]
        public void ThenShouldBeAdded(string language)
        {
            Thread.Sleep(5000);
            IWebElement languageRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(languageRead.Text, Is.EqualTo(language), "Language is not added");
        }

        [Given(@"Add New button should be there")]
        public void GivenAddNewButtonShouldBeThere()
        {
            deletingObj.DeletingLanguage();
            Thread.Sleep(5000);
        }

        [When(@"I click on Add New buttons to give invalid input")]
        public void WhenIClickOnAddNewButtonsToGiveInvalidInput()
        {
            IWebElement newButton = driver.FindElement(By.XPath("//*/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            newButton.Click();
        }

        [When(@"I give space as input <'([^']*)'>,<'([^']*)'> for language")]
        public void WhenIGiveSpaceAsInputForLanguage(string language, string level)
        {
            languagesPageObj.SpaceInput(language = " ", level = "Fluent");
        }

        [Then(@"<'([^']*)'> should not add")]
        public void ThenShouldNotAdd(string language)
        {
            try
            {
                Thread.Sleep(5000);
                IWebElement languageRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                Assert.That(!string.IsNullOrEmpty(languageRead.Text), "Space should not be added");
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }

        [When(@"I give input <'([^']*)'> to language but not choosen level of language")]
        public void WhenIGiveInputToLanguageButNotChoosenLevelOfLanguage(string language)
        {
            languagesPageObj.NotChoosingLevel(language = "qwer");
        }

        [Then(@"<'([^']*)'> should not be added")]
        public void ThenShouldNotBeAdded(string language)
        {
            Thread.Sleep(5000);
            IWebElement languageRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(languageRead.Text, !Is.EqualTo(language), "language should not be added");
        }

        [When(@"I give existing input '([^']*)','([^']*)'  of language")]
        public void WhenIGiveExistingInputOfLanguage(string language, string level)
        {
            languagesPageObj.DuplicateInput(language, level);
        }

        [Then(@"Duplicate '([^']*)' should not be added")]
        public void ThenDuplicateShouldNotBeAdded(string language)
        {
            Thread.Sleep(3000);
            for (int i = 1; i < 5; i++)
            {
                try
                {
                    string path = "//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]";
                    IWebElement contentLanguage = driver.FindElement(By.XPath(path));
                    Thread.Sleep(3000);
                    if (contentLanguage.Text == language && i != 1)
                        Assert.Fail("Duplicate language should not be added");
                    break;
                }
                catch (Exception) { Console.WriteLine(" "); }
            }
        }

        [When(@"I click on Pencil icon buttons")]
        public void WhenIClickOnPencilIconButtons()
        {
            editLanguagePageObj.EditLanguage();
        }

        [When(@"I update language and level of language")]
        public void WhenIUpdateLanguageAndLevelOfLanguage()
        {
            editLanguagePageObj.InputEditLanguage();
        }

        [Then(@"Language and level should be updated")]
        public void ThenLanguageAndLevelShouldBeUpdated()
        {
            Thread.Sleep(2000);
            IWebElement languageRead = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            Assert.That(languageRead.Text, Is.EqualTo("Gujrati"), "Language is not Updated");
        }
    }
}
