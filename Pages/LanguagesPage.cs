using MarsOnboardV2.Drivers;
using MarsOnboardV2.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Pages
{
    public class LanguagesPage : CommonDriver
    {
        LanguageLevelOptions levelOptionObj = new LanguageLevelOptions();
        LocateAndClickAddNew locateCickObj = new LocateAndClickAddNew();
        LocateAndEnterLanguageTextbox locateEnterTextObj = new LocateAndEnterLanguageTextbox();
        LocateClickAddButton clickAddButtonObj = new LocateClickAddButton();

        //Locate Add new button and click
        public void AddLanguage()
        {
            locateCickObj.LocateClickAddNew();
        }

        //Add 4 languages including speacial character,numbers,long characters at different levels
        public void InputLanguage(string language, string level)
        {
            locateEnterTextObj.LocateEnterLangText( language); //Locate Language textbox and enter language
            levelOptionObj.LevelOptions( level); //Locate and click Choose level dropdown,also locate and click option value
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }

        //Giving space as input to language textbox
        public void SpaceInput( string language, string level)
        {
            locateEnterTextObj.LocateEnterLangText(language);
            levelOptionObj.LevelOptions(level);  //Locate Choose level dropdown and click
            clickAddButtonObj.ClickAddButton();//Locate Add button and click
        }

        //Giving valid input to language textbox but not choosing language level
        public void NotChoosingLevel( string language)
        {
            locateEnterTextObj.LocateEnterLangText(language); //Locate language textbox and enter data
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }

        //Giving duplicate input to language textbox 
        public void DuplicateInput(string language, string level)
        {
            locateEnterTextObj.LocateEnterLangText(language); //Locate language textbox and enter data
            levelOptionObj.LevelOptions(level); //Locate Choose level dropdown and click
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }
    }
}

