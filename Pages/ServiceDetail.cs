using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ShareSkill.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ShareSkill.Pages
{
    class ServiceDetail
    {
        IWebDriver driver;
        int RowNum;
        public ServiceDetail(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        //Identify the 'Title'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement titleServiceDetail { get; set; }

        //Identify the 'Description'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement DescServiceDetail { get; set; }

        //Identify the 'Category'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")]
        private IWebElement CategoryServiceDetail { get; set; }
        
        //Identify the 'Start Date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[1]/div/div[2]")]
        private IWebElement StartDateServiceDetail { get; set; }

        //Identify the 'Subcategory'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]")]
        private IWebElement SubCategoryServiceDetail { get; set; }

        //Identify the 'End Date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/div[2]")]
        private IWebElement EndDateServiceDetail { get; set; }

        //Identify the 'Service Type'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[3]/div/div[2]")]
        private IWebElement ServTypeServiceDetail { get; set; }

        //Identify the 'Location Type'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")]
        private IWebElement LocationTypeServiceDetail { get; set; }

        //Identify the 'Search box'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[1]/div[1]/input")]
        private IWebElement SearchBox { get; set; }

        //Identify the Charge displayed
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em")]
        private IWebElement Charge { get; set; }

        //Identify the SkillsTrade displayed
        [FindsBy(How = How.XPath, Using = "//*[@id='no-skills-specified']")]
        private IWebElement SkillsTradeDisplay { get; set; }

        //Identify the ManageListings from service detail page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/section[1]/div/a[3]")]
        private IWebElement ManageLstings { get; set; }

        //Identify the ManageListings from search page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/section[1]/div/a[3]")]
        private IWebElement MngLstngs { get; set; }

        
               
        public void ValidateServiceDetail()
        {
            //Wait until the page loads and description is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[1]");

            //Read the Skill exchange tag count from the excel
            var SkillExchngCount = ServiceData.TagsCntData(RowNum);

            //Convert the count of the skill exchange tags from String to integer
            int Count = Int32.Parse(SkillExchngCount);         
            
            //Convert the Start Date and End Data format from (dd/mm/yyyy to yyyy-mm-dd)
            String StartDate = (ServiceData.StrtDateData(RowNum).Substring(4, 4)) + "-" + (ServiceData.StrtDateData(RowNum).Substring(2, 2)) + "-" + (ServiceData.StrtDateData(RowNum).Substring(0, 2));
            String EndDate = (ServiceData.EndDateData(RowNum).Substring(4, 4)) + "-" + (ServiceData.EndDateData(RowNum).Substring(2, 2)) + "-" + (ServiceData.EndDateData(RowNum).Substring(0, 2));

            //Validate the expected and actual values of the different fields in the services
            Assert.Multiple(() =>
            {
                Assert.That(titleServiceDetail.Text, Is.EqualTo(ServiceData.TitleData(RowNum)));
                Assert.That(DescServiceDetail.Text, Is.EqualTo(ServiceData.DescriptionData(RowNum)));
                Assert.That(CategoryServiceDetail.Text, Is.EqualTo(ServiceData.CategData(RowNum)));
                Assert.That(SubCategoryServiceDetail.Text, Is.EqualTo(ServiceData.SubCategData(RowNum)));
                Assert.That(ServTypeServiceDetail.Text, Is.EqualTo(ServiceData.SrvcTypeData(RowNum)));
                Assert.That(StartDateServiceDetail.Text, Is.EqualTo(StartDate));
                Assert.That(EndDateServiceDetail.Text, Is.EqualTo(EndDate));                
                Assert.That(LocationTypeServiceDetail.Text, Is.EqualTo(ServiceData.LocatnTypeData(RowNum)));
            });

            //If the skill trade is chosen as "Skill-exchange" then need to validate the Skill exchange tags
            if (ServiceData.SkillTrdeData(RowNum) == "Skill-exchange")
            {
                String[] SkillsTradeData = new String[Count];
                String[] SkillExchangeData = ServiceData.SkillExchangeData(RowNum);
                for (int Counter = 0; Counter < Count; Counter++)
                {
                    SkillsTradeData[Counter] = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[2]/span[" + (Counter + 1) + "]")).Text;
                    TestContext.WriteLine(SkillsTradeData[Counter]);
                    Assert.That(SkillsTradeData[Counter], Is.EqualTo(SkillExchangeData[Counter]));
                }

                //Click on the Manage Listings
                ManageLstings.Click();

                //Wait until the Listings are available in the Manage Listing page
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[4]");
            }

            //If the Skill Exchange is chosen as 'Credit' then validate the credit charge value displayed
            else if (ServiceData.SkillTrdeData(RowNum) == "Credit")
            {
                try
                {
                    String SkillsTrade = SkillsTradeDisplay.Text;

                    //Enter the title in the serach Box
                    SearchBox.SendKeys(ServiceData.TitleData(RowNum));

                    //Press enter key to search for the skill
                    SearchBox.SendKeys(Keys.Enter);

                    //Implicit wait for the registeration pop up to be available
                    Wait.wait(2, driver);

                    String CreditCharge = "Charge is :$" + ServiceData.CreditValue(RowNum);
                    String CreditActualVal = Charge.Text;
                    Assert.Multiple(() =>
                    {
                        Assert.That(CreditActualVal, Is.EqualTo(CreditCharge));
                        Assert.That(SkillsTrade, Is.EqualTo("None Specified"));
                    });

                    //Click on the Manage Listings
                    MngLstngs.Click();

                    //Wait until the Listings are available in the Manage Listing page
                    Wait.ElementIsVisible(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[4]");
                }catch (Exception e)
                {
                    Assert.Fail("One or more webelements could not be found", e.Message);
                }
                
            }

        }
    }
}
