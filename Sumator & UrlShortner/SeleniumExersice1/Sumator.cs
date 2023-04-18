using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V109.Input;

namespace SeleniumExersice1
{
    public class Sumator
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            this.driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void TestWithTwoPositiveNumbers()
        {
            driver.FindElement(By.Id("number1")).SendKeys("125");
            driver.FindElement(By.Id("number2")).SendKeys("100");
            driver.FindElement(By.Id("operation")).SendKeys("+");
            driver.FindElement(By.Id("calcButton")).Click();
            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("Result: 225"));
            //driver.FindElement(By.Id("Reset")).Click();

        }
        [Test]
        public void TestInvalidInput()
        {
            driver.FindElement(By.Id("number1")).SendKeys("hello");
            driver.FindElement(By.Id("number2")).SendKeys("100");
            driver.FindElement(By.Id("operation")).SendKeys("+");
            driver.FindElement(By.Id("calcButton")).Click();
            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("Result: invalid input"));
            //driver.FindElement(By.Id("Reset")).Click();

        }
        [Test]
        public void ResetButtonValidation()
        {
            var firstField = driver.FindElement(By.Id("number1"));
            firstField.SendKeys("1");
            var secondField = driver.FindElement(By.Id("number2"));
            secondField.SendKeys("100");
            var operation = driver.FindElement(By.Id("operation"));
            operation.SendKeys("-");
            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            // Assert result is not empty
            var resultField = driver.FindElement(By.Id("result"));
            Assert.IsNotEmpty(resultField.Text);

            // Clear the fields with reset button
            var resetButton = driver.FindElement(By.Id("resetButton"));
            resetButton.Click();

            // Assert fields are empty after reset
            Assert.IsEmpty(resultField.Text);
            Assert.IsEmpty(firstField.Text);
            Assert.IsEmpty(secondField.Text);
        }

    }
}