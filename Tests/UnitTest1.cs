using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ShareSkill.Pages;
using ShareSkill.Utilities;
using System;
using System.IO;
using System.Threading;

namespace ShareSkill
{
    [TestFixture]
    public class UnitTest1 : CommonDriver

    {
        //Get the browser option from the resource file
        public static int Browser = Int32.Parse(Resources.ShareSkillResource.Browser);

        //Get the URL from the resource file
        public static string URL = Resources.ShareSkillResource.URL;

        //Declare object for ExtentTest
        public static ExtentTest test;

        //Declare object for ExtentReports
        public static ExtentReports extent;

        public String TestCase_Name;

        [SetUp]
        public void Setup()
        {
            //Choose the browser as per the input from the resource file
            switch(Browser)
            {
                case 1:
                    driver = new FirefoxDriver();
                break;
                case 2:
                    driver = new ChromeDriver();
                    //Navigate to the required URL
                    driver.Navigate().GoToUrl(URL);
                    driver.Manage().Window.Maximize();
               break;
            }
                      
        }

        [OneTimeSetUp]
        //Entent reporting using Extent Reporter 4
        protected void ExtentStart()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = (projectPath + "Reports\\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "Nisha Thomas");
        }

        
        [Test, Description("Checks if user is able to Sign Up with Valide details"), Order(1)]
        public void SignUpFirstTime()
        {
            bool FirstTime = true;
            TestCase_Name = "Register New user";
            test = extent.CreateTest(TestCase_Name);
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(FirstTime, driver);

            //Invoke the register function using the instance of SignUp page
            JoinObj.Register();
        }

        [Test, Description("Checks if user is able to Sign Up with same email second time"), Order(2)]
        public void SignUpWithSameEmailSecondTime()
        {
            bool FirstTime = false;

            TestCase_Name = "Register with same Email ID twice";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(FirstTime,driver);

            //Invoke the register function using the instance of SignUp page
            JoinObj.Register();
        }

        //This test is to check if the user can add details of various service using Share Skill feature in SkillSwap
        //Each of these test cases below adds unique entry for the services rendered
        [Category("Adding Details")]
        [TestCase(2), Order(3)]
        [TestCase(8)]
        [TestCase(15)]

        //Function to add services using Share Skill feature to render services to others
        public void ShareSkill(int rownumber)
        {
            String Title = ServiceData.TitleData(rownumber);

            TestCase_Name = $"Adding services with title {Title}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps();

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Invoke the function to navigate to Share Skill Page
            SkillObj.navigateToShareSkill();

            //Create an instance for the ShareSkillPage
            ShareSkillPage Obj = new ShareSkillPage(driver, rownumber);

            //Invoke the function to fill the details of services rendered
            Obj.FillDetailsOfServiceProvided();

            //Create an instance for the Listing Management page
            ListingManagement listObj = new ListingManagement(driver, rownumber);

            //Invoke the funtion to navigate to Manage Listings
            listObj.ManageListing();

            //Invoke the funtion to view the listings
            listObj.ViewListings();

            //Invoke the funtion to view the details of the listings
            listObj.NavigateToViewAddedDetails();

            //Create an instance for the Service Detail page
            ServiceDetail ViewDetailObj = new ServiceDetail(driver, rownumber);

            //Invoke the funtion to validate the details of services
            ViewDetailObj.ValidateServiceDetail();

            
        }

        [Category("Editing Details for a skill based on title")]
        [TestCase("Yoga Trainer", 22), Order(4)]        
        public void EditSkill(string TitleForServcToBeEdited, int rownumber)
        {
            bool editMatchFound = false;

            TestCase_Name = $"Editing existing services for title {TitleForServcToBeEdited}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps();

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            //Create an instance for the Listing Management page
            ListingManagement obj = new ListingManagement(driver, TitleForServcToBeEdited, rownumber);

            //Invoke the function to check if the service to be edited is available in the Manage Listings
            editMatchFound = obj.NavigateToEditDetails();

            //Create instances for ServiceListing Page and SearchSkill Page
            ServiceListing editObj = new ServiceListing(driver, rownumber);
            SearchSkill SrchObj = new SearchSkill(driver, rownumber);

            //Proceed to Edit service only if the service to be edited is found
            if (editMatchFound)
            {
                //Invoke the function to Edit services
                editObj.EditServices();

                //Implicit wait
                Wait.wait(2,driver);

                //Invoke the function to search for service after edit
                obj.SearchSkillsAfterEdit();

                //Invoke the function to validate the search result
                SrchObj.SkillSrchResult();

                //Implicit wait
                Wait.wait(2, driver);

                //Create an instance for ServiceDetail Page
                ServiceDetail ViewEditdDetailObj = new ServiceDetail(driver, rownumber);

                //Invoke the function to validate the edited details
                ViewEditdDetailObj.ValidateServiceDetail();
            }

        }

        [Test, Description("Checks if user is able to delete the services from the manage Listing page")]
        [TestCase("Blogger"), Order(5)]
        [TestCase("QA Coach")]
        public void DeleteService(string TitleForServcToBeDeleted)
        {
            TestCase_Name = $"Deleting existing services for title {TitleForServcToBeDeleted}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps();

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            //Implicit wait
            Wait.wait(2, driver);

            //Create an instance for ListingManagement
            ListingManagement DeletelistObj = new ListingManagement(driver, TitleForServcToBeDeleted);

            //Invoke Delete Operation
            DeletelistObj.DeleteDetails();

            //Invoke a function to search for the service after deletion
            DeletelistObj.SearchSkillsAfterDelete();
            SearchSkill SrchObj = new SearchSkill(driver);

            //Invoke a function for search
            SrchObj.SrchResultAfterDel();
        }

        [TearDown]
        public void TearDown()
        {
            String fileName;

            DateTime time = DateTime.Now;

            fileName = "Screenshot_" + time.ToString("hh_mm_") + TestCase_Name + ".png";

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus = Status.Pass;
            if (status == TestStatus.Failed)
            {
                logstatus = Status.Fail;
                var mediaEntity = CaptureScreenShot(driver, fileName);
                test.Log(logstatus, "Fail");
                test.Log(Status.Fail, stackTrace + errorMessage);
                /* Usage of MediaEntityBuilder for capturing screenshots */
                test.Pass("ExtentReport 4 Capture: Test Failed", mediaEntity);
            }

            else if (status == TestStatus.Passed)
            {
                logstatus = Status.Pass;
                var mediaEntity = CaptureScreenShot(driver, fileName);
                test.Log(logstatus, "Pass");
                /* Usage of MediaEntityBuilder for capturing screenshots */
                test.Pass("ExtentReport 4 Capture: Test Passed", mediaEntity);
                
            }

            extent.Flush();            
            driver.Quit();

        }
    }
}