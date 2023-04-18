using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Transactions;

namespace SeleniumExersice1
{
    public class SeleniumTests
    {
        IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SearchingWikipedia()
        {
            driver.Url = "https://wikipedia.org";
            driver.FindElement(By.Id("searchInput")).SendKeys("QA");
            driver.FindElement(By.Id("searchInput")).SendKeys(Keys.Enter);
            Assert.That(driver.Url, Is.EqualTo("https://bg.wikipedia.org/wiki/%D0%9E%D1%81%D0%B8%D0%B3%D1%83%D1%80%D1%8F%D0%B2%D0%B0%D0%BD%D0%B5_%D0%BD%D0%B0_%D0%BA%D0%B0%D1%87%D0%B5%D1%81%D1%82%D0%B2%D0%BE%D1%82%D0%BE"));

        }

    }
}