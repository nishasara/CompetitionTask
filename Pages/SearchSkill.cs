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
    class SearchSkill
    {
        IWebDriver driver;
        int RowNum;
        public SearchSkill(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        public SearchSkill(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);            
        }

        //Identify the search result
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]")]
        private IWebElement SellerInfo { get; set; }

        //Identify the  text box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private IWebElement ServiceInfo { get; set; }

        //Identify the Credit charge
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em")]
        private IWebElement Charge { get; set; }

        //Identify the Service
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private IWebElement Service { get; set; }

        //Identify the SearchResultDisplay
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/h3")]
        private IWebElement SrchDisplay { get; set; }

        public void SkillSrchResult()
        {
            if (ServiceData.ActvStatusData(RowNum) == "Active")
            {
                Thread.Sleep(500);
                if ((SellerInfo.Text == "Sara Susan") && (ServiceData.TitleData(RowNum) == ServiceInfo.Text))
                    TestContext.WriteLine("The service has been found in the search list");
                String CreditCharge = "Charge is :$" + ServiceData.CreditValue(RowNum);
                String CreditActualVal = Charge.Text;
                Assert.That(CreditActualVal, Is.EqualTo(CreditCharge));
                Service.Click();
            }
        }

        public void SrchResultAfterDel()
        {
            //Search for service only if the service is active
            if (ServiceData.ActvStatusData(RowNum) == "Active")
            {
                Wait.wait(1, driver);
                String displayResult = "No results found, please select a new category!";
                Assert.That(SrchDisplay.Text, Is.EqualTo(displayResult));
            }
            
        }
    }
}
