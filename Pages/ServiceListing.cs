using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ShareSkill.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ShareSkill.Pages
{
    class ServiceListing
    {
        IWebDriver driver;
        int RowNum;
        
        public ServiceListing(IWebDriver driver, int RownNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RownNum;
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

        //Identify the 'Start time'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement StartTime { get; set; }


        //Identify the 'End time'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")]
        private IWebElement EndTime { get; set; }

        //Identify the 'Save' button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement SaveButton { get; set; }

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

        //Choose the SkillTrade for the services rendered
        public void ChooseSkillTrade(String SkillTrade, int Cnt)
        {
            if (SkillTrade == "Skill-exchange")
            {
                //Click on the SkillExchange radio button
                SkillExchangeButton.Click();

                //Implicit wait
                Wait.wait(1, driver);

                String[] Skills = ServiceData.SkillExchangeData(RowNum);
                //Loop in to read all the tags
                for (int TagCount = 0; TagCount < Cnt; TagCount++)
                {
                  //Read the data for Tags from excel in case the services is edited to add new tags
                  SkillExchngTag.SendKeys(Skills[TagCount]);

                  //Press ENTER key to add the tag
                  SkillExchngTag.SendKeys(Keys.Enter);
                }
            }
            else
            {
                //Delete the Skill Exchange tags if present any
                if (Cnt > 0)
                {
                    for (int TagCount = Cnt; TagCount >= 1; TagCount--)
                        driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/span[" + TagCount + "]/a")).Click();
                    Thread.Sleep(100);
                }
                //Change the Skill Trade option to Credit
                CreditButton.Click();

                //Enter the value for Credit
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

        public void EditServices()
        {
            //Wait for the Page to be loaded to edit by waiting for the title field to be visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input");

            //Clear the title
            Title.Clear();

            //Enter the updated data into the title field
            Title.SendKeys(ServiceData.TitleData(RowNum));

            //Clear the description field
            Description.Clear();

            //Enter the updated description 
            Description.SendKeys(ServiceData.DescriptionData(RowNum));

            //Identify the Category
            SelectElement CategorySelect = new SelectElement(Category);

            //Select the required Category from the dropdown
            CategorySelect.SelectByText(ServiceData.CategData(RowNum));

            //Identify the SubCategory
            SelectElement SubCategorySelect = new SelectElement(SubCategory);

            //Select the required SubCategory from the dropdown
            SubCategorySelect.SelectByText(ServiceData.SubCategData(RowNum));

            //Enter the additional tag to be added
            Tags.SendKeys(ServiceData.TagsData(RowNum));
            Tags.SendKeys(Keys.Enter);

            //Convert the count of Skill Exchange Tags from String to integer
            int Count = Int32.Parse(ServiceData.TagsCntData(RowNum));

            //Invoke the function to choose the Service Type
            ChooseServiceType(ServiceData.SrvcTypeData(RowNum));

            //Invoke the function to choose the Location Type
            ChooseLocationType(ServiceData.LocatnTypeData(RowNum));

            //Invoke the function to choose the Skills Trade Type
            ChooseSkillTrade(ServiceData.SkillTrdeData(RowNum), Count);

            //Clear the field before adding the date
            StartDate.Clear();

            //Enter the data for 'Start date' from excel
            StartDate.SendKeys(ServiceData.StrtDateData(RowNum));
                     
            //Click on the 'End date' field
            EndDate.Click();

            //Clear the 'End date'
            EndDate.Clear();

            //Enter the data for 'End date' from excel
            EndDate.SendKeys(ServiceData.EndDateData(RowNum));

            //Click on the Save button
            SaveButton.Click();
        }
    }
}
