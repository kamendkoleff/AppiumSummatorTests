using AppiumSummatorTests.Window;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests.Tests
{
    public class AppiumSumatorTests
    {
        private WindowsDriver<WindowsElement> driver;

        //private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        private AppiumLocalService appiumLocal;


        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\user\Downloads\WindowsFormsApp");
            appiumLocal = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocal.Start();

            this.driver = new WindowsDriver<WindowsElement>(appiumLocal, options);
        }
        [TearDown]

        public void ShutDown()
        {
            driver.Quit();
            appiumLocal.Dispose();
        }
        [Test]
        public void Test_Sum_Two_PositiveNumbersPOM()
        {
            var window = new SummatorWindow(driver);
            string value1 = "5";
            string value2 = "15";
            string result = window.Calculate(value1, value2);
            Assert.That(result, Is.EqualTo("20"));

        }
        [Test]
        public void Test_Two_Invalid_Inputs()
        {
            var window = new SummatorWindow(driver);
            string value1 = "sgs";
            string value2 = "ghg";
            string result = window.Calculate(value1, value2);
            Assert.That(result, Is.EqualTo("error"));
        }
        
    }
}


