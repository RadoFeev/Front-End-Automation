using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace URLshortner
{
    public class UrlTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            this.driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://shorturl.softuniqa.repl.co/";
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void PageTitleValidation()
        {
            Assert.That(driver.Title, Is.EqualTo("URL Shortener"));
        }
        [Test]
        public void UrlValidation()
        {
            driver.FindElement(By.CssSelector("body > header > a:nth-child(3)")).Click();

            var originalUrl = driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(1) > a")).Text;
            Assert.That(originalUrl, Is.EqualTo("https://nakov.com"));

            var shortUrl = driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(2) > a")).Text;
            Assert.That(shortUrl, Is.EqualTo("http://shorturl.softuniqa.repl.co/go/nak"));
        }
    }
}