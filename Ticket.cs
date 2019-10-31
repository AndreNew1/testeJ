using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService($"{AppDomain.CurrentDomain.BaseDirectory}", "geckodriver.exe");
            driver = new FirefoxDriver(service);
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://fronttickets.azurewebsites.net/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='E-mail'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Login'])[1]/following::input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Login'])[1]/following::input[1]")).SendKeys("andre@atendente.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).SendKeys("senha1234");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::button[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Aberto'])[1]/following::div[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div/main/div/div/div/div[3]/div/div[2]/div/div[2]/div/div[2]/div/button/span")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).SendKeys("novo");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).SendKeys("novo novo");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::button[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
