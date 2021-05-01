using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ShareSkill.Utilities;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace ShareSkill.Pages
{
    class ShareSkillPage
    {
        IWebDriver driver;
        int RowNum = 0;
        public ShareSkillPage(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        //Identify the Title field text box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }

        //Identify the Description text box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
        private IWebElement Description { get; set; }

        //Identify the Category Dropdown box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")]
        private IWebElement Category { get; set; }

        //Identify the Subcategory Dropdown box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")]
        private IWebElement SubCategory { get; set; }

        //Identify the Tags
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tags { get; set; }
        
        //Identify the Radio button 'Hourly basis service' for service Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement HourlyRadioButton { get; set; }
    

        //Identify the Radio button 'One-Off service' for service Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement OneOffServiceRadioButton { get; set; }


        //Identify the Radio button 'On-site' for Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement OnsiteButton { get; set; }

        //Identify the Radio button 'Online' for Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement OnlineButton { get; set; }

        //Identify the Radio button 'Skill-exchange' for Skill Trade
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillExchangeButton { get; set; }

        //Identify the Radio button 'Credit' for Skill Trade
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement CreditButton { get; set; }

        //Identify the Credit text box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement Credit { get; set; }

        //Identify the text box to add tags for 'Skill-Exchange'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchngTag { get; set; }


        //Identify the Radio button for 'Active'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveButton { get; set; }

        //Identify the Radio button for 'Hidden'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement HiddenButton { get; set; }


        //Identify the button for adding 'Work Samples'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement AddWrkSmplButton { get; set; }

        //Identify the 'Start date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input")]
        private IWebElement StartDate { get; set; }

        //Identify the 'End date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")]
        private IWebElement EndDate { get; set; }

        //Identify the 'Save' button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement SaveButton { get; set; }

        //Day Check Box
        [FindsBy(How = How.Name, Using = "Available")]
        private IList<IWebElement> CheckBox { get; set; }

        //Start Time
        [FindsBy(How = How.Name, Using = "StartTime")]
        private IList<IWebElement> StartTime { get; set; }

        //End Time
        [FindsBy(How = How.Name, Using = "EndTime")]
        private IList<IWebElement> EndTime { get; set; }

        //Choose the radio button based on the Type of service rendered
        public void ChooseServiceType(String ServiceType)
        {                                  
          if (ServiceType == "Hourly")
            HourlyRadioButton.Click();
          else
            OneOffServiceRadioButton.Click();
        }

        //Choose the radio button based on the Location Type for the services rendered
        public void ChooseLocationType(String LocationType)
        {
            if (LocationType == "On-Site")
              OnsiteButton.Click();
            else
              OnlineButton.Click();
        }

        //Choose the radio button based on the Skill Trade
        public void ChooseSkillTrade(String SkillTrade, int Cnt)
        {
            if (SkillTrade == "Skill-exchange")
            {
                SkillExchangeButton.Click();
                Thread.Sleep(200);

                String[] Skills = ServiceData.SkillExchangeData(RowNum);
                for (int TagCount = 0; TagCount < Cnt; TagCount++)
                {
                    //Read the data for Tags from excel and enter the data into the Tags field for Skill-Exchange
                    SkillExchngTag.SendKeys(Skills[TagCount]);

                    //Press ENTER key to add the tag
                    SkillExchngTag.SendKeys(Keys.Enter);

                }
            }
            else
            {
                CreditButton.Click();
                Credit.SendKeys(ServiceData.CreditValue(RowNum));
            }
        }

        //Choose the radio button based on the Active Status
        public void ChooseActiveStatus(String Status)
        {
            if (Status == "Active")
              ActiveButton.Click();
            else
              HiddenButton.Click();
        }

        public void FillDetailsOfServiceProvided()
        {
            //Wait for the share skill page to be loaded and until title field text box is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input");

            //Read the data for Title from excel and enter the data into the Title Textbox
            Title.SendKeys(ServiceData.TitleData(RowNum));

            //Read the data for Description from excel and enter the data into the Description Textbox
            Description.SendKeys(ServiceData.DescriptionData(RowNum));

            //Read the Category name from the excel
            var CategoryData = ServiceData.CategData(RowNum);

            //Read the Subcategory name from the excel
            var SubCategoryData = ServiceData.SubCategData(RowNum);

            SelectElement CategorySelect = new SelectElement(Category);

            //Select the required Category from the dropdown
            CategorySelect.SelectByText(CategoryData);

            SelectElement SubCategorySelect = new SelectElement(SubCategory);

            //Select the required SubCategory from the dropdown
            SubCategorySelect.SelectByText(SubCategoryData);

            //Read the Skill exchange tag count from the excel
            var SkillExchngCount = ServiceData.TagsCntData(RowNum);

            int Count = Int32.Parse(SkillExchngCount);
            int TagsCount = Int32.Parse(ServiceData.TagsDataCount(RowNum));

            int DaysCnt = Int32.Parse(ServiceData.AvailableDaysCnt(RowNum));

            //Fill in the Start and End times for all days
            for (int TagCount = 0; TagCount < TagsCount; TagCount++)
            {
                //Read the data for Tags from excel and enter the data into the Tags field
                Tags.SendKeys(ExcelLibHelpers.ReadData((TagCount+ RowNum), "Tags"));

                //Press ENTER key to add the tag
                Tags.SendKeys(Keys.Enter);

            }

            //Read the Service Type data from excel into a variable
            var ServiceTypeData = ServiceData.SrvcTypeData(RowNum);

            //Read the Location Type data from excel into a variable
            var LocationTypeData = ServiceData.LocatnTypeData(RowNum);

            //Read the Skill Trade data from excel into a variable
            var SkillTradeData = ServiceData.SkillTrdeData(RowNum);

            //Read the Active Status data from excel into a variable
            var ActiveStatusData = ServiceData.ActvStatusData(RowNum);

            //Choose Service Type
            ChooseServiceType(ServiceTypeData);

            //Choose Location Type
            ChooseLocationType(LocationTypeData);

            //Choose Skill Trade
            ChooseSkillTrade(SkillTradeData, Count);
       
            //Click on the 'Start date' field
            StartDate.Click();

            //Read the Start Date data from the excel
            var StartDateData = ServiceData.StrtDateData(RowNum);

            //Read the End Date data from the excel
            var EndDateData = ServiceData.EndDateData(RowNum);

            //Initialse the variable that hold StartTime and EndTime 
            var StartTimeData = "000000";
            var EndTimeData ="000000";
                 
            //Clear the field before adding the date
            StartDate.Clear();

            //Enter the data for 'Start date' from excel
            StartDate.SendKeys(StartDateData);

            Wait.wait(1, driver);

            //Click on the 'End date' field
            EndDate.Click();

            //Clear the 'End date'
            EndDate.Clear();

            //Enter the data for 'End date' from excel
            EndDate.SendKeys(EndDateData);


            //Select the Start time, End time, Available Days
            for (int DaysCount = 0; DaysCount < DaysCnt; DaysCount++)
            {
                if (ServiceData.AvailableDays(RowNum) == "Sun")
                {
                    CheckBox[0].Click();
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    StartTime[0].Click();
                    StartTime[0].SendKeys(StartTimeData);
                    EndTime[0].Click();
                    EndTime[0].SendKeys(EndTimeData);
                }
                else if (ServiceData.AvailableDays(RowNum) == "Mon")
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[1].Click();
                    StartTime[1].Click();
                    StartTime[1].SendKeys(StartTimeData);
                    EndTime[1].Click();
                    EndTime[1].SendKeys(EndTimeData);
                }
                else if (ServiceData.AvailableDays(RowNum) == "Tue")
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[2].Click();
                    StartTime[2].Click();
                    StartTime[2].SendKeys(StartTimeData);
                    EndTime[2].Click();
                    EndTime[2].SendKeys(EndTimeData);

                }
                else if (ServiceData.AvailableDays(RowNum) == "Wed")
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[3].Click();
                    StartTime[3].Click();
                    StartTime[3].SendKeys(StartTimeData);
                    EndTime[3].Click();
                    EndTime[3].SendKeys(EndTimeData);
                }
                else if (ServiceData.AvailableDays(RowNum) == "Thu")
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[4].Click();
                    StartTime[4].Click();
                    StartTime[4].SendKeys(StartTimeData);
                    EndTime[4].Click();
                    EndTime[4].SendKeys(EndTimeData);
                }
                else if (ServiceData.AvailableDays(RowNum) == "Fri")
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[5].Click();
                    StartTime[5].Click();
                    StartTime[5].SendKeys(StartTimeData);
                    EndTime[5].Click();
                    EndTime[5].SendKeys(EndTimeData);
                }
                else
                {
                    StartTimeData = ServiceData.StrtTimeData(RowNum);
                    EndTimeData = ServiceData.EndTimeData(RowNum);
                    CheckBox[6].Click();
                    StartTime[6].Click();
                    StartTime[6].SendKeys(StartTimeData);
                    EndTime[6].Click();
                    EndTime[6].SendKeys(EndTimeData);
                }
                    RowNum++;
            }


            //Choose the Active status button            
            ChooseActiveStatus(ActiveStatusData);
    
            //Click on the save button
            SaveButton.Click();

            //Implicit wait
            Wait.wait(1, driver);

        }
    }

}
