using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Booking
{
    public class Tests
    {
        HomePage homePage;
        LoginPage loginPage;
        ChromeDriver driver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://booking.com");
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void TestLanguage()
        {
            homePage.OpenHomePage();
            homePage.ChangeLanguage();
            Assert.True(homePage.IsChangeLanguageSuccessful());
        }

        [Test]
        public void TestTicketsPage()
        {
            homePage.OpenHomePage();
            homePage.OpenTicketsPage();
            Assert.True(homePage.IsOpenTicketsPageSuccessful());
        }

        [Test]
        public void TestUserAccount()
        {
            homePage.OpenHomePage();
            loginPage.Login();
            Assert.True(loginPage.ILoginSuccessful());
            loginPage.OpenPersonalAccount();
            Assert.True(loginPage.IsOpenPersonalAccounteSuccessful());
        }

        [Test]
        public void TestFilter()
        {
            homePage.OpenHomePage();
            homePage.Filter();
            Assert.True(homePage.IsFilterSuccessful());
        }
    }
}