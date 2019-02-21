using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace SeleniumWD2
{
    [TestClass]
    public class SeleniumWD2
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void startBrowser()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.mailinator.com/");
            driver.FindElement(By.Id("inboxfield")).SendKeys("Yehor_Test@mailinator.com");
            
        }

        [Test]
        public void FindNecessaryEmail()
        {
            string from = "Yehor Samoilenko";
            driver.FindElement(By.XPath("//span[@class='input-group-btn']")).Click();
            string value = driver.FindElement(By.Id("row_yehor_test-1550747942-931251")).Text;

            if (value.Contains(from))
            {
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&aqs=chrome..69i57j0l5.2115j0j7&sourceid=chrome&ie=UTF-8");
            }
        }
        [Test]
        public void From_and_Subject()
        {
            string from = "Yehor Samoilenko";
            string subject = "Test Mail";
            driver.FindElement(By.XPath("//span[@class='input-group-btn']")).Click();
            string value = driver.FindElement(By.Id("row_yehor_test-1550747942-931251")).Text;

            if (value.Contains(from) && value.Contains(subject))
            {
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&aqs=chrome..69i57j0l5.2115j0j7&sourceid=chrome&ie=UTF-8");
            }
        }
        [Test]
        public void CorectlyBody()
        {
            string body = "Hello World!";
            driver.FindElement(By.XPath("//span[@class='input-group-btn']")).Click();
            driver.FindElement(By.Id("row_yehor_test-1550747942-931251")).Click();
            string message = driver.FindElement(By.XPath("//div[@dir='ltr']")).Text;

            if (message.Contains(body))
            {
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD&aqs=chrome..69i57j0l5.2115j0j7&sourceid=chrome&ie=UTF-8");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
