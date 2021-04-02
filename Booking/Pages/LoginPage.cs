using System;
using OpenQA.Selenium;

namespace Booking
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement OpenLoginPageButton => driver.FindElement(By.CssSelector("#b2indexPage > header > nav.bui-header__bar > div.bui-group.bui-button-group.bui-group--inline.bui-group--align-end.bui-group--vertical-align-middle > div:nth-child(6) > a > span"));
        private IWebElement EmailField => driver.FindElement(By.Id("username"));
        private IWebElement SubmitEmailButton => driver.FindElement(By.CssSelector("#root > div > div.app > div.access-container.bui_font_body > div > div > div > div > div > div > form > div:nth-child(3) > button"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("#root > div > div.app > div.access-container.bui_font_body > div > div > div > div > div > div > form > button"));
        private IWebElement UserButton => driver.FindElement(By.CssSelector("#profile-menu-trigger--title"));
        private IWebElement ManageAccountButton => driver.FindElement(By.CssSelector("#b2indexPage > header > nav.bui-header__bar > div.bui-group.bui-button-group.bui-group--inline.bui-group--align-end.bui-group--vertical-align-middle > div:nth-child(6) > div > div > div > ul > li:nth-child(1) > a > span.bui-icon.bui-dropdown-menu__icon.bui-icon--medium"));

        private const string email = "radivanovich1@gmail.com";
        private const string password = "";

        public void Login()
        {
            OpenLoginPageButton.Click();
            EmailField.SendKeys(email);
            SubmitEmailButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            PasswordField.SendKeys(password);
            LoginButton.Click();         
        }

        public bool ILoginSuccessful()
        {
            return UserButton.Enabled;
        }

        public void OpenPersonalAccount()
        {
            UserButton.Click();
            ManageAccountButton.Click();
        }

        public bool IsOpenPersonalAccounteSuccessful()
        {
            return driver.Url.Contains("account.booking.com");
        }
    }
}
