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
    class SignIn
    {
        IWebDriver driver;
        public SignIn(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        //Identify signIn
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement signIn { get; set; }

        //Identify the Email textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email { get; set; }

        //Identify the Password textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement pswrd { get; set; }

        //Identify the Login button and click
        [FindsBy(How = How.XPath, Using = "//html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        private IWebElement login { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement User { get; set; }


        public void LoginSteps()
        {

            //Wait for login page to be loaded and 'Sign In' to become visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a");

            //Click on Sign in button
            signIn.Click();

            ExcelLibHelpers.PopulateInCollection(ServiceData.ExcelPath, "SignUp");

            //Wait for email textbox to be present
            Wait.ElementPresent(driver, "Name", "email");

            //Read the emailID data from excel and enter the data into the Email Textbox
            email.SendKeys(ExcelLibHelpers.ReadData(2, "EmailID"));

            //Read the Password data from excel and enter the data into the Password Textbox
            pswrd.SendKeys(ExcelLibHelpers.ReadData(2, "Password"));
            
            //Click on the Login button
            login.Click();

            //Wait for Home page to be loaded by checking if 'Sign Out' is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");


        }

        public void ValidateHomePage()
        {

            try
            { 
                if (User.Text == "Hi Sara")
                {
                    TestContext.WriteLine($"Logged in successfully and message {User.Text} is displayed on home page");
                }

            }
            catch (Exception e)
            {
                TestContext.WriteLine("Home page not displayed", e.Message);
            }
        }
    }
}
