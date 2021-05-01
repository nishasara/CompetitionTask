using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace ShareSkill.Pages
{
    class HomePage
    {
        //Declare the driver
        IWebDriver driver;

        //Constructor to initialise the driver and webelements
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        //Identify ShareSkill button on the home page
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]
        private IWebElement ShareSkill { get; set; }

        //Identify ManageListings button on the home page
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[3]")]
        private IWebElement ManageListings { get; set; }


        public void navigateToShareSkill()
        {
            //Click on the Share Skill button in the home page
            ShareSkill.Click();

        }

        public void navigateToManageListings()
        {
            //Click on the Share Skill button in the home page
            ManageListings.Click();
        }

    }
}
