using MarsOnboardV2.Drivers;
using MarsOnboardV2.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.FedCm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsOnboardV2.Pages
{
    public class Language : CommonDriver
    {
        public IWebElement element;
        public string xpathlasttable;
        public string xpathduplicate1;
        public string xpathduplicate2;
        public string xpathupdate;

        public Language()
        {
            element = null;
            xpathlasttable = "//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]";
            xpathduplicate1 = "//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[";
            xpathduplicate2 = "]/tr/td[1]";
            xpathupdate = "//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]";

        }

        public IWebElement GetElement(string path)
        {
            element = driver.FindElement(By.XPath(path));
            return element;
        }
        public string GetElementText(string path)
        {
            element = driver.FindElement(By.XPath(path));
            return element.Text;
        }

        public void DeleteLanguage3()
        {
            Thread.Sleep(3000);

            //Locate Remove icon button and deleting the existing language
            try
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
                Thread.Sleep(2000);
            }

            catch (Exception)
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
                element.Click();
                Assert.Pass("Last languages has been removed");
                Thread.Sleep(5000);
            }

        }

        public void DeleteLanguage2()
        {

            //Locate Remove icon button and deleting the existing language

            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
            element.Click();
            Thread.Sleep(2000);

        }


        public void DeletingExitingLanguage()
        {
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i");
            element.Click();

        }
        public string ReadLanguage()
        {
            GetElement("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
            return element.Text;

        }
        public void EditLanguage()
        {

            //Locate Pencil icon button and click
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i");
            element.Click();
            Thread.Sleep(3000);
        }
        public void InputEditLanguage()

        {

            //Locate existing language, remove it and add new language
            IWebElement updateLanguageTextbox = driver.FindElement(By.Name("name"));
            updateLanguageTextbox.Clear();
            updateLanguageTextbox.SendKeys("Gujrati");

            //Locate Update level dropdown, click and choose fluent
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select");
            element.Click();
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]");
            element.Click();


            //Locate Update button and click
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]");
            element.Click();

        }
        public void ClickAddButton()
        {
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
            element.Click();

        }
        public void LocateEnterLangText(string language)
        {
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(language);
        }
        public void LocateClickAddNew()
        {
            GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
            element.Click();

        }
        public void LevelOptions(string level)
        {
            IWebElement levelDropdown = driver.FindElement(By.Name("level"));
            levelDropdown.Click();

            //Navigating through the level options
            if (level == "Basic")
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]");
                element.Click();

            }
            if (level == "Native")
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[5]");
                element.Click();

            }
            if (level == "Fluent")
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]");
                element.Click();

            }
            if (level == "Conversational")
            {
                GetElement("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[3]");
                element.Click();

            }
        }
        public void AddLanguage()
        {
            LocateClickAddNew();
        }
        public void InputLanguage(string language, string level)
        {
            LocateEnterLangText(language); //Locate Language textbox and enter language
            LevelOptions(level); //Locate and click Choose level dropdown,also locate and click option value
            ClickAddButton();  //Locate Add button and click
        }
        public void SpaceInput(string language, string level)
        {
            LocateEnterLangText(language);
            LevelOptions(level);  //Locate Choose level dropdown and click
            ClickAddButton();//Locate Add button and click
        }
        public void NotChoosingLevel(string language)
        {
            LocateEnterLangText(language); //Locate language textbox and enter data
            ClickAddButton();  //Locate Add button and click
        }
        //Giving duplicate input to language textbox 
        public void DuplicateInput(string language, string level)
        {
            LocateEnterLangText(language); //Locate language textbox and enter data
            LevelOptions(level); //Locate Choose level dropdown and click
            ClickAddButton();  //Locate Add button and click
        }

        //Try catch 
        public void DeleteConfirmation()
        {
            try
            {
                GetElement("//*/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i");

            }
            catch (NoSuchElementException)
            {
                Assert.Pass("All languages are deleted");

            }

        }
        public void LanguageCheck(string language)
        {
            GetElement("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
            Assert.That(element.Text, Is.EqualTo(language), "Language is not added");

        }
        public void ClickAdd()
        {
            GetElement("//*/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
            element.Click();

        }

        public string SpaceCheck(string language)
        {
            GetElement("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
            return element.Text;

        }

        public string UpdateLevel()
        {
            GetElement("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]");
            return element.Text;

        }
        public string FindLanguageElement(string path)
        {
            GetElement(path);
            return element.Text;

        }
    }

}

