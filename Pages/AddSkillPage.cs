using MarsOnboardV2.Drivers;
using MarsOnboardV2.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardV2.Pages
{
    public class AddSkillPage : CommonDriver
    {

        SkillLevelOptions levelOptionObj = new SkillLevelOptions();
        LocateAndClickAddNewSkill locateCickObj = new LocateAndClickAddNewSkill();
        LocateAndEnterSkillTextbox locateEnterTextObj = new LocateAndEnterSkillTextbox();
        LocateClickAddButtonSkill clickAddButtonObj = new LocateClickAddButtonSkill();

        //Locate Add new button and click
        public void AddSkill()
        {
            locateCickObj.LocateClickAddNew();
        }

        //Add Skills including speacial character,numbers,long characters at different levels
        public void InputSkill(string skill, string level)
        {
            locateEnterTextObj.LocateEnterSkillText(skill); //Locate Skill textbox and enter skill
            levelOptionObj.LevelOptions(level); //Locate and click Choose level dropdown,also locate and click option value
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }

        //Giving space as input to Skill textbox
        public void SpaceInput(string skill, string level)
        {
            locateEnterTextObj.LocateEnterSkillText(skill);
            levelOptionObj.LevelOptions(level);  //Locate Choose level dropdown and click
            clickAddButtonObj.ClickAddButton();//Locate Add button and click
        }

        //Giving valid input to Skill textbox but not choosing Skill level
        public void NotChoosingLevel(string skill)
        {
            locateEnterTextObj.LocateEnterSkillText(skill); //Locate Skill textbox and give input
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }

        //Giving duplicate input to Skill textbox 
        public void DuplicateInput(string skill, string level)
        {
            locateEnterTextObj.LocateEnterSkillText(skill); //Locate skill textbox and enter data
            levelOptionObj.LevelOptions(level); //Locate Choose level dropdown and click
            clickAddButtonObj.ClickAddButton();  //Locate Add button and click
        }
    }
}
