using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowTestProject.NewBookModelsPOM;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestApiProject;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;

namespace SpecflowTestProject
{
    [Binding]
    public class Logout1Steps
    {
        const string USER_EMAIL = "qweasdasd@qwe.qwea";
        const string PASSWORD = "123qweQWE!";
        private readonly IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"client on newbookmodel\.com")]
        public void GivenClientOnNewbookmodel_Com()
        {
                new SignInPage(_driver).SignInPageIsOpened();
        }
        
        [Given(@"is log in")]
        public void GivenIsLogIn()
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
            Context.Token = leadRegistrationResponseData.TokenData.Token;

            var driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
          //  driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{Context.Token}');");
            Thread.Sleep(3000);
        }
        
        [When(@"client go to account setting page")]
        public void WhenClientGoToAccountSettingPage()
        {
            new AccountSettingPage(_driver).AccountSettingPageIsOpened();
        }
        
        [When(@"click logout button")]
        public void WhenClickLogoutButton()
        {
            new AccountSettingPage(_driver).ClickLogOutBtn();
        }
        
        [Then(@"client is signout")]
        public void ThenClientIsSignout()
        {
            Thread.Sleep(5000);
            Assert.True(new AccountSettingPage(_driver).LogInBtnDisplayed());
        }
    }
}
