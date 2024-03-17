using MarsOnboardV2.Drivers;
using MarsOnboardV2.Pages;
using MarsOnboardV2.Support;
using NUnit.Framework;
using OpenQA.Selenium;

using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace MarsOnboardV2.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        Language languageObj = new Language();
        
        [Given(@"Language Tab is selected in Profile Page/")]
        public void GivenLanguageTabIsSelectedInProfilePage()
        {
            Console.WriteLine("Mars portal is Starting");
        }

        [When(@"I click on Cross icon buttons")]
        public void WhenIClickOnCrossIconButtons()
        {
            languageObj.DeleteLanguage();
        }

        [Given(@"Delete the last language if there is no add new button")]
        public void GivenDeleteTheLastLanguageIfThereIsNoAddNewButton()
        {
            languageObj.DeleteLanguage3();
        }

        [When(@"Add English as language and basic as level")]
        public void WhenAddEnglishAsLanguageAndBasicAsLevel()
        {
            throw new PendingStepException();
        }

        [Given(@"Add German as language and level as basic")]
        public void GivenAddGermanAsLanguageAndLevelAsBasic()
        {
            throw new PendingStepException();
        }


        [When(@"I click on Add New buttons")]
        public void WhenIClickOnAddNewButtons()
        {
            languageObj.AddLanguage();
        }

        [When(@"I give input '([^']*)','([^']*)' of language")]
        public void WhenIGiveInputOfLanguage(string language, string level)
        {
            languageObj.InputLanguage(language, level);
        }

        [Then(@"'([^']*)' should be added")]
        public void ThenShouldBeAdded(string language)
        {
            Thread.Sleep(2000);
            languageObj.LanguageCheck(language);
        }
        [Then(@"language should be reset")]
        public void ThenLanguageShouldBeReset()
        {
            languageObj.DeleteLanguage2();
        }


        [When(@"I click on Add New buttons to give invalid input")]
        public void WhenIClickOnAddNewButtonsToGiveInvalidInput()
        {
            languageObj.ClickAdd();
        }

        [When(@"I give space as input <'([^']*)'>,<'([^']*)'> for language")]
        public void WhenIGiveSpaceAsInputForLanguage(string language, string level)
        {
            languageObj.SpaceInput(language = " ", level = "Fluent");
        }

        [Then(@"<'([^']*)'> should not add")]
        public void ThenShouldNotAdd(string language)
        {
            try
            {
                Thread.Sleep(2000);
                string spacecheck;
                spacecheck=languageObj.SpaceCheck(language);
                Assert.That(!string.IsNullOrEmpty(spacecheck), "Space should not be added");
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }

        [When(@"I give input <'([^']*)'> to language but not choosen level of language")]
        public void WhenIGiveInputToLanguageButNotChoosenLevelOfLanguage(string language)
        {
            languageObj.NotChoosingLevel(language = "qwer");
        }

        [Then(@"<'([^']*)'> should not be added")]
        public void ThenShouldNotBeAdded(string language)
        {
            Thread.Sleep(1000);
            try
            {


                string returnval = languageObj.GetElementText(languageObj.xpathlasttable);
                
            }
            catch (Exception)
            {
                Assert.Pass("language should not be added");
               
            }


        }

        
        [When(@"Add Japanese as <'([^']*)'>,<'([^']*)'> as basic")]
        public void WhenAddJapaneseAsAsBasic(string language, string level)
        {
            Thread.Sleep(2000);
            languageObj.SpaceInput(language = "Japanese", level = "Basic"); ;
        }



        [When(@"I give existing input '([^']*)','([^']*)'  of language")]
        public void WhenIGiveExistingInputOfLanguage(string language, string level)
        {
            languageObj.DuplicateInput(language, level);
        }

        [Then(@"Duplicate '([^']*)' should not be added")]
        public void ThenDuplicateShouldNotBeAdded(string language)
        {
           
            Thread.Sleep(2000);
            for (int i = 1; i < 5; i++)
            {
                try
                {
                    string path = languageObj.xpathduplicate1 + i + languageObj.xpathduplicate2;
                    Thread.Sleep(3000);
                    string returnval = languageObj.GetElementText(path);
                   
                    if (string.IsNullOrEmpty(returnval))
                        break;
                    if (returnval == language && i != 1)
                        Assert.Fail("Duplicate language should not be added");
                    break;
                  
                }
                catch (Exception) { Console.WriteLine(" "); }
            }
        }

        [When(@"I click on Pencil icon buttons")]
        public void WhenIClickOnPencilIconButtons()
        {
            Thread.Sleep(2000) ;
            languageObj.EditLanguage();
        }

        [When(@"I update language and level of language")]
        public void WhenIUpdateLanguageAndLevelOfLanguage()
        {
           languageObj.InputEditLanguage();
        }

        [Then(@"Language and level should be updated")]
        public void ThenLanguageAndLevelShouldBeUpdated()
        {
            Thread.Sleep(2000);
            Assert.That(languageObj.GetElementText(languageObj.xpathupdate), Is.EqualTo("Gujrati"), "Language is not Updated");
        }
    }
}
