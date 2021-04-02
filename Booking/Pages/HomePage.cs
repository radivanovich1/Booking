using System;
using OpenQA.Selenium;



namespace Booking
{
    public class HomePage 
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
       
        private IWebElement LanguageIcon => driver.FindElement(By.XPath("//IMG[@class='bui-avatar__image']"));
        private IWebElement EnglishIcon => driver.FindElement(By.XPath("(//DIV[@class='bui-inline-container bui-inline-container--align'])[2]"));
        private IWebElement LanguageText => driver.FindElement(By.CssSelector("#b2indexPage > header > nav.bui-header__bar > div.bui-group.bui-button-group.bui-group--inline.bui-group--align-end.bui-group--vertical-align-middle > div:nth-child(2) > button > span > span"));
        private IWebElement TicketsPageButton => driver.FindElement(By.CssSelector("#b2indexPage > header > nav.bui-tab.bui-header__tab.bui-tab--borderless.bui-tab--light > ul > li:nth-child(2) > a > span.bui-tab__text"));
        private IWebElement CityField => driver.FindElement(By.Id("ss"));
        private IWebElement DateField => driver.FindElement(By.ClassName("xp__dates"));
        private IWebElement GuestField => driver.FindElement(By.ClassName("xp__guests__count"));
        private IWebElement ChildrenPlusButton => driver.FindElement(By.CssSelector("#xp__guests__inputs-container > div > div > div.sb-group__field.sb-group-children > div > div.bui-stepper__wrapper.sb-group__stepper-a11y > button.bui-button.bui-button--secondary.bui-stepper__add-button > span"));
        private IWebElement Date => driver.FindElement(By.XPath($"(//SPAN[@aria-hidden='true'][text()='{date}'])[1]"));
        private IWebElement SearchButton => driver.FindElement(By.ClassName("sb-searchbox__button"));
        private const string city = "Гродно";
        int date;

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://booking.com");
        }

        public void ChangeLanguage()
        {
            LanguageIcon.Click();
            EnglishIcon.Click();
        }

        public bool IsChangeLanguageSuccessful()
        {
            return LanguageText.Text.Contains("Your current language is English (US)");
        }

        public void OpenTicketsPage()
        {
            TicketsPageButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public bool IsOpenTicketsPageSuccessful()
        {
            return driver.Url.Contains("booking.kayak.com");
        }

        public void Filter()
        {
            CityField.SendKeys(city);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            DateField.Click();
            date = DateTime.Now.Day + 7;
            Date.Click();
            date += 2;
            Date.Click();
            GuestField.Click();
            ChildrenPlusButton.Click();
            SearchButton.Click();

        }
        public bool IsFilterSuccessful()
        {
            return driver.Url.Contains("searchresults");
        }

    }
}
