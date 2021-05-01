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
    class ListingManagement
    {
        IWebDriver driver;
        int RowNum = 0;
        String TitleEdit;
        String TitleDelete;
        public ListingManagement(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        public ListingManagement(IWebDriver driver, string TitleEdit, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.TitleEdit = TitleEdit;
            this.RowNum = RowNum;
        }

        public ListingManagement(IWebDriver driver, string TitleDelete)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.TitleDelete = TitleDelete;            
        }

        //Identify the 'Manage Listings' button
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/section[1]/div/a[3]")]
        private IWebElement ManageListings { get; set; }
        
        //Identify the Category field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[2]")]
        private IWebElement CategoryListing { get; set; }

        //Identify the Category field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[3]")]
        private IWebElement TitleListing { get; set; }

        //Identify the 'Description' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[4]")]
        private IWebElement DescriptionListing { get; set; }

        //Identify the 'Service Type' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[5]")]
        private IWebElement ServiceTypeListing { get; set; }

        //Identify the Skill Trade field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[6]/i")]
        private IWebElement SkillTradeListing { get; set; }

        //Identify the 'Active' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[7]/div/input")]
        private IWebElement ActiveStatusListing { get; set; }

        //Identify the 'View Details' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[8]/div/button[1]/i")]
        private IWebElement ViewDetailsIcon { get; set; }

        //Identify the 'Edit Details' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[8]/div/button[2]/i")]
        private IWebElement EditDetailsIcon { get; set; }

        //Identify the 'table' for the Manage Listings
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table")]
        private IWebElement ManageListingsTable { get; set; }
        

        //Identify the 'Delete Details' field of the listing added recently(recelnt listing comes as the first entry)
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[8]/div/button[3]/i")]
        private IWebElement DeleteDetailsIcon { get; set; }

        //Identify the 'Yes' button in the 'Delete Your Service' text box
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement Yes { get; set; }

        //Identify the 'Search skills'
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[1]/div[1]/input")]
        private IWebElement SrchSkills { get; set; }

        //Identify the 'Search'
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[1]/div[1]/i")]
        private IWebElement SearchButton { get; set; }

        public void ManageListing()
        {            
            //Click on the Manage Listings button to view the listings
            ManageListings.Click();
        }
        public void ViewListings()
        {
            //Implicit wait until the listings are visible            
            Wait.wait(2, driver);

            //Validate the Listings in the Manage Listings Page by checking the values displayed for all the fields with the values from excel 

            //Read the data for Title from excel into a variable
            var TitleData = ServiceData.TitleData(RowNum);

            //Read the data for Category from excel into a variable
            var CategoryData = ServiceData.CategData(RowNum);

            //Read the data for Description from excel into a variable
            var DescriptionData = ServiceData.DescriptionData(RowNum);

            String DescriptionDataTrunc ="";
            String Description = "";

            //Truncate the string (only 70 characters of description gets displayed in the Manage listing)
            if (DescriptionData.Length > 70)
            {
              DescriptionDataTrunc = DescriptionData.Substring(0, 70);
              Description = DescriptionListing.Text.Substring(0, 70);
            }
            else
            {
              DescriptionDataTrunc = DescriptionData;
              Description = DescriptionListing.Text;
            }

            //Read the data for Service Type from excel into a variable
            var ServiceTypeData = ServiceData.SrvcTypeData(RowNum);

            //Read the data for Service Type from excel into a variable
            var SkillTradeData = ServiceData.SkillTrdeData(RowNum);

            //Read the data for Service Type from excel into a variable
            var ActiveStatusData = ServiceData.ActvStatusData(RowNum);

            //Set a flag as per the status of Active provided by user
            bool ActiveStatusSet = false;

            if (ActiveStatusData == "Active")
              ActiveStatusSet = true;
            else if (ActiveStatusData == "Hidden")
              ActiveStatusSet = false;

            //Assert statements to validate the various fields of the listings
            Assert.Multiple(() =>
            {
                Assert.That(TitleData, Is.EqualTo(TitleListing.Text));
                Assert.That(DescriptionDataTrunc, Is.EqualTo(Description));
                Assert.That(CategoryData, Is.EqualTo(CategoryListing.Text));
                Assert.That(ServiceTypeData, Is.EqualTo(ServiceTypeListing.Text));
                Assert.That(ActiveStatusSet, Is.EqualTo(ActiveStatusListing.Selected));
            });
        }


        public void NavigateToViewAddedDetails()
        {
            //Click on the view details icon to see the details of the services rendered
            ViewDetailsIcon.Click();
        }

        public bool NavigateToEditDetails()
        {
            bool ServiceMatchFound = false;
            Wait.wait(2, driver);
            try
            {
                //Get the list of rows in the table for the last Page
                IList<IWebElement> ListingRows = ManageListingsTable.FindElements(By.TagName("tr"));

                
                if (ListingRows.Count == 2)
                {
                    if (driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[3]")).Text == TitleEdit)
                    {
                      ServiceMatchFound = true;
                      EditDetailsIcon.Click();
                    }
                    else
                        TestContext.WriteLine("The service to be edited is not present in the Manage listings");
                }
                else
                {
                    //Check for the services to be edited based on the title
                    for (int entry = 1; entry < ListingRows.Count; entry++)
                    {
                        if (driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=" + entry + "]/td[3]")).Text == TitleEdit)
                        {
                            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=" + entry + "]/td[8]/div/button[2]/i")).Click();
                            Thread.Sleep(500);
                            ServiceMatchFound = true;
                            break;
                        }
                    }
                    //If the services to be edited is not present in the listings
                    if (ServiceMatchFound == false)
                        TestContext.WriteLine("The service to be edited is not present in the Manage listings");
                }
            }catch(Exception e) {
                TestContext.WriteLine("There are no services listed in the page", e.Message);
            }
            return ServiceMatchFound;
        }

        public void SearchSkillsAfterEdit()
        {
          //Get the Edited Title
          String Title = ServiceData.TitleData(RowNum);

          //Search the service in the search box
          SrchSkills.SendKeys(Title);
          SrchSkills.SendKeys(Keys.Enter);
        }

        public void SearchSkillsAfterDelete()
        {
            //Check for the service after delete
            SrchSkills.SendKeys(TitleDelete);
            SrchSkills.SendKeys(Keys.Enter);
            
        }

        public void DeleteDetails()
        {
            bool ServiceMatchFound = false;
            try
            {
                //Get the list of rows in the table for the last Page
                IList<IWebElement> ListingRows = ManageListingsTable.FindElements(By.TagName("tr"));

                //If there is a single service listed
                if (ListingRows.Count == 2)
                {
                    if (driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=1]/td[3]")).Text == TitleDelete)
                    {
                        ServiceMatchFound = true;
                        DeleteDetailsIcon.Click();
                    }
                    else
                        TestContext.WriteLine("The service to be deleted is not present in the Manage listings");
                }

                //If there are more than a service listed
                else
                {
                    //Check for the services to be edited based on the title
                    for (int entry = 1; entry < ListingRows.Count; entry++)
                    {
                        if (driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=" + entry + "]/td[3]")).Text == TitleDelete)
                        {
                            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[position()=" + entry + "]/td[8]/div/button[3]/i")).Click();                            
                            Thread.Sleep(500);
                            ServiceMatchFound = true;
                            break;
                        }
                    }
                    //If the services to be deleted is not present in the listings
                    if (ServiceMatchFound == false)
                        TestContext.WriteLine("The service to be deleted is not present in the Manage listings");
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("There are no services listed in the page", e.Message);
            }

            //Proceed to delete only if the match is found
            if (ServiceMatchFound == true)
            {

                //Wait for Delete your service Text Box to be visible
                Wait.ElementIsVisible(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]");

                //Click on 'Yes' button
                Yes.Click();

                //Wait for Delete your service Text Box to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[@class='ns-box-inner']");

                //Get the text from the pop up
                String msg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                String DeletePopUpMsg = $"{TitleDelete} has been deleted";

                //Check for the Pop message for delete
                Assert.That(msg, Is.EqualTo(DeletePopUpMsg));
            }
                     
        }










    }
}
