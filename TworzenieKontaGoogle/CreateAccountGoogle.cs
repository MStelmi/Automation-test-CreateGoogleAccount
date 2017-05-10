/*
 * Created by SharpDevelop.
 * User: stelm
 * Date: 30.04.2017
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TworzenieKontaGoogle
{
	[TestFixture]
	public class CreateAccountGoogle
	{
		private IWebDriver driver;      
		private string baseURL;
        WebDriverWait wait;
        private string numer = "4";
        private string idLokalizacji = ":n";
        private string plec = "f";
        [SetUp]
        public void SetupTest()
        {
        	driver = new FirefoxDriver();
        	
        	baseURL = "https://www.google.pl/?gws_rd=ssl";
        //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        
        driver.Navigate().GoToUrl(baseURL);
			driver.FindElement(By.Id("gs_htif0")).SendKeys("Tworzenie Konta Google");
			PoczekajNaZaladowanieElementu(By.LinkText("Utwórz konto Google - Google Accounts")).Click();
        }
        
		[Test]
		public void TestRejestracjaKontaGoogle()
		{
			
			
			//PoczekajNaZaladowanieElementu(By.Id("FirstName")).SendKeys("Michał");
			//driver.FindElement(By.Id("Gender")).Click();
			//driver.FindElement(By.Id(plec)).Click();
				
			//driver.FindElement(By.XPath("//*[@id='BirthMonth']/div[1]")).Click();
			//PoczekajNaZaladowanieElementu(By.XPath("//*[@id=':" + numerMiesiaca + "']/div")).Click();
			//PoczekajNaZaladowanieElementu(By.Id("CountryCode")).Click();
			//PoczekajNaZaladowanieElementu(By.XPath("//*[@id='" + idLokalizacji + "']/div")).Click();
			
			
			//*[@id=':5c']/div

			
		}
		[Test]
		public void WypelnianieDanychRejestracyjnychGoogle()
		{
			
			RejestracjaKonta Rej = new RejestracjaKonta(driver);
			PageFactory.InitElements(driver,Rej);
			Rej.WypelnijPolaRejestracyjne(plec,idLokalizacji,"Michał","Stelmach","stelmi1993","haslohaslo123123","781987498","michala.stelmach@gmail.com",
			                              "1993","24",numer);
			

		}
		
		public IWebElement PoczekajNaZaladowanieElementu(By by, int sekundy = 10)
        {
        	wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sekundy));
            IWebElement element = wait.Until(x=> driver.FindElement(by));
            
            return element;
        }
		public IWebElement SprawdzCzyElementJestWidoczny(By by, int sekundy = 10)
        {
        	wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sekundy));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            
            return element;
        }
	}
}
