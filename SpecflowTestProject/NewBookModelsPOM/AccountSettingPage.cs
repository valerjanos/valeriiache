using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestProject.NewBookModelsPOM
{
    public class AccountSettingPage
    {
        private readonly IWebDriver _driver;

        public AccountSettingPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private static readonly By LogOutBtn = By.CssSelector("nb-link[type=logout]");
        public void ClickLogOutBtn()
        {
            _driver.FindElement(LogOutBtn).Click();
        }
        public void AccountSettingPageIsOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }


        private static readonly By LogInBtn = By.CssSelector("button[class^=SignInForm]");
        public bool LogInBtnDisplayed()
        {
            return _driver.FindElement(LogInBtn).Displayed;
        }

        private static readonly By AccountSettingBtn = By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/common-header/section/nb-main-header/common-react-bridge/header/div/div/div[2]/a[3]/div/div");

            public void ClickAccountSettingBtn()
        {
            _driver.FindElement(AccountSettingBtn).Click();
        }
    }
}
