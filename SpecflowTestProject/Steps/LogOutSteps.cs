using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestProject.NewBookModelsPOM;
using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using TechTalk.SpecFlow;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;

namespace SpecflowTestProject.Steps
{
    [Binding]
    public class LogOutSteps
    {
        private readonly IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];
        const string USER_EMAIL = "qweasdasd@qwe.qwea";
        const string PASSWORD = "123qweQWE!";


        [Given(@"Client is log in")]
        public void GivenClientIsLogIn()
        {
            var leadRegistrationData = new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            };

            var authRequests = new AuthRequests();
            var leadRegistrationResponseData = authRequests.SendRequestSignUpPost(leadRegistrationData);
          //  Context.Token = leadRegistrationResponseData.TokenData.Token;

        }
        
        [Given(@"Account Setting page is opened")]
        public void GivenAccountSettingPageIsOpened()
        {
            new AccountSettingPage(_driver).AccountSettingPageIsOpened();
        }
        
        [When(@"I click ""(.*)"" link")]
        public void WhenIClickLink(string p0)
        {
            new AccountSettingPage(_driver).ClickLogOutBtn();
        }
        
        [Then(@"I successfully logout NewBookModels")]
        public void ThenISuccessfullyLogoutNewBookModels()
        {
            
                Thread.Sleep(5000);
                Assert.True(new AccountSettingPage(_driver).LogInBtnDisplayed());
            
        }
    }
}
