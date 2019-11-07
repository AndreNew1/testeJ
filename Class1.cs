using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Class1 
    {
        private IWebDriver Driver;
        private StringBuilder VerificationErrors;
        private string BaseURL;
        private bool AcceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService($"{AppDomain.CurrentDomain.BaseDirectory}", "geckodriver.exe");
            Driver = new FirefoxDriver(service);
            BaseURL = "https://fronttickets.azurewebsites.net/";
            VerificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", VerificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            Driver.Navigate().GoToUrl(BaseURL);
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='E-mail'])[1]/following::input[1]")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Login'])[1]/following::input[1]")).Clear();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Login'])[1]/following::input[1]")).SendKeys("andre@atendente.com");
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).Clear();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::input[1]")).SendKeys("senha1234");
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Senha'])[1]/following::button[1]")).Click();
            Thread.Sleep(5000);
            Driver.FindElement(By.XPath("//div[@id='app']/div/main/div/div/div/div[2]/div/div[2]/div/div[3]")).Click();
            Driver.FindElement(By.XPath("//div[@id='app']/div/main/div/div/div/div[3]/div/div[2]/div/div[2]/div/div[2]/div/button/span")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Clear();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).SendKeys("Velho");
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::button[1]")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Click();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).Clear();
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::textarea[1]")).SendKeys("Velho Velho");
            Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Mensagem'])[1]/following::button[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
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
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (AcceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                AcceptNextAlert = true;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
