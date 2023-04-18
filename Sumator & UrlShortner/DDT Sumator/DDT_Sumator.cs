using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace DDT_Sumator
{
    public class SeleniumTests
    {
        IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcBtn;
        IWebElement resultBtn;
        IWebElement resetBut;
        
        [OneTimeSetUp]
        public void Setup() 
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(options);
            options.AddArgument("--headless");
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
            textBoxFirstNum = driver.FindElement(By.Id("number1"));
            textBoxSecondNum = driver.FindElement(By.Id("number2"));
            dropDownOperation = driver.FindElement(By.Id("operation"));
            calcBtn = driver.FindElement(By.Id("calcButton"));
            resultBtn = driver.FindElement(By.Id("result"));
            resetBut = driver.FindElement(By.Id("resetButton"));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [TestCase("5", "+", "3", "Result: 8")]
        [TestCase("5", "-", "3", "Result: 2")]
        [TestCase("5", "/", "3", "Result: 1.66666666667")]
        [TestCase("5", "*", "3", "Result: 15")]
        [TestCase("5.5", "+", "2", "Result: 7.5")]
        [TestCase("5.5", "-", "2", "Result: 3.5")]
        [TestCase("5.5", "/", "2", "Result: 2.75")]
        [TestCase("5.5", "*", "2", "Result: 11")]
        [TestCase("1.5e53", "*", "150", "Result: 2.25e+55")]
        [TestCase("1.5e53", "/", "150", "Result: 1e+51")]
        [TestCase("Infinity", "+", "Infinity", "Result: Infinity")]
        [TestCase("5", "*", "Result: invalid input", "Result: invalid input")]
        [TestCase("5", "/", "Result: invalid input", "Result: invalid input")]
        [TestCase("5", "+", "Result: invalid input", "Result: invalid input")]
        [TestCase("5", "-", "Result: invalid input", "Result: invalid input")]

        public void TestCalculatorWebApp(string num1, string op, string num2, string expectedResult)
        {
            //Arrange
            resetBut.Click();
            if (num1 != "") textBoxFirstNum.SendKeys(num1);
            if (num2 != "") textBoxSecondNum.SendKeys(num2);
            if(op != "") dropDownOperation.SendKeys(op);

            //Act
            calcBtn.Click();

            //Assert
            Assert.AreEqual(expectedResult, resultBtn.Text);
        }
    }
}