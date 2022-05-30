using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumSummatorTests
{
    public class SummatorTests

    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        [SetUp]
        public void Setup()
        {
            options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\user\Downloads\WindowsFormsApp");
            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }
        [TearDown]

        public void ShutDown()
        {
            driver.Dispose();
            driver.Quit();
        }

        [Test]
        public void Test_Sum_Two_PositiveNumbers()
        {
            //var num1 = driver.FindElement(By.Id("textBoxFirstNum"));
            //Find FirstField Click it, and fill Value 5
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("5");

            //Find Second Field, Click it and fill Value 15
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("15");

            //Find Result Field, 
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.AreEqual("20", result);
        }
        [Test]
        public void Test_Sum_Two_InvalidValues()
        {
            //var num1 = driver.FindElement(By.Id("textBoxFirstNum"));
            //Find FirstField Click it, and fill Value 5
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("Invalid");

            //Find Second Field, Click it and fill Value 15
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("Invalid");

            //Find Result Field, 
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("error"));
        }
    }
}