/*
 * Created by SharpDevelop.
 * User: stelm
 * Date: 30.04.2017
 * Time: 19:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TworzenieKontaGoogle
{
	/// <summary>
	/// Description of RejestracjaKonta.
	/// </summary>
	public class RejestracjaKonta : CreateAccountGoogle
	{
		public IWebDriver driver;
		WebDriverWait wait;
		
		[FindsBy(How = How.Id, Using ="gs_htif0")]
		private IWebElement podajStroneWGoogle;
		
		[FindsBy(How = How.LinkText, Using ="Utwórz konto Google - Google Accounts")]
		private IWebElement ClickStworzenieKontaGoogle;
		
		[FindsBy(How = How.Id, Using ="FirstName")]
		private IWebElement podajImie;
		
		[FindsBy(How = How.Id, Using ="LastName")]
		private IWebElement podajNazwisko;
		
		[FindsBy(How = How.Id, Using ="GmailAddress")]
		private IWebElement podajEmail;
		
		[FindsBy(How = How.Id, Using ="Passwd")]
		private IWebElement podajHaslo;
		
		[FindsBy(How = How.Id, Using ="PasswdAgain")]
		private IWebElement potwierdzHaslo;
		
		[FindsBy(How = How.Id, Using ="BirthYear")]
		private IWebElement podajRokUrodzenia;
		
		[FindsBy(How = How.Id, Using ="BirthDay")]
		private IWebElement podajDzienUrodzenia;
		
		[FindsBy(How = How.XPath, Using="//*[@id='BirthMonth']/div[1]")]
		private IWebElement podajMiesiacUrodzenia;
		
		[FindsBy(How = How.Id, Using="RecoveryPhoneNumber")]
		private IWebElement podajTelefon;
		
		[FindsBy(How = How.Id, Using="RecoveryEmailAddress")]
		private IWebElement podajObecnyEmail;
		
		[FindsBy(How = How.Id, Using="CountryCode")]
		private IWebElement PodajLok;
		
		[FindsBy(How = How.Id, Using="Gender")]
		private IWebElement wybierzPlec;
		
		
		
		public RejestracjaKonta(IWebDriver driver)
		{
			this.driver = driver;
		}
		
		public void WybierzPlec(string plec)
		{
			wybierzPlec.Click();
			driver.FindElement(By.XPath(".//*[@id=':"+plec+ "']")).Click();
		}
		
		public void PodajLokalizacje(string idLokalizacji)
		{
			PodajLok.Click();
			driver.FindElement(By.XPath("//*[@id='" + idLokalizacji + "']/div")).Click();
                   
			                 
		}

		public void PrzejdzDoRejestracji()
		{
			podajStroneWGoogle.SendKeys("Utwórz konto Google");
			ClickStworzenieKontaGoogle.Click();
		}
		public void UzupelnijDane(string imie, string nazwisko, string email, string haslo, string numerTel, string obecnyMail)
		{
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
			podajImie.SendKeys(imie);
			podajNazwisko.SendKeys(nazwisko);
			podajEmail.SendKeys(email);
			podajHaslo.SendKeys(haslo);
			potwierdzHaslo.SendKeys(haslo);
			podajTelefon.SendKeys(numerTel);
			podajObecnyEmail.SendKeys(obecnyMail);
		}
		public void WyborDatyUrodzenia(string rok, string dzien, string numerMiesiaca)
		{
			podajRokUrodzenia.SendKeys(rok);
			podajDzienUrodzenia.SendKeys(dzien);
			podajMiesiacUrodzenia.Click(); 
			driver.FindElement(By.XPath("//*[@id=':" + numerMiesiaca + "']/div")).Click();
			
		}
		
		public static void ZapiszWynikDoPliku(string nazwaCzynosci, string opisTestu)
		{
			string data = DateTime.Today.ToShortDateString();
			data = data.Replace(":","-");
			
			string fileName = @"E:\TESTY\TworzenieKontaGoogle\" + @"raport " + data + ".csv";
			StreamWriter writer;
			using(writer = new StreamWriter(fileName, true, Encoding.UTF8))
			      {
			      	writer.WriteLine("Godzina " + DateTime.Now.ToLongTimeString());
			      	writer.WriteLine(nazwaCzynosci + ";" + opisTestu);
			      }
			
			
		}
		
		
		public void WypelnijPolaRejestracyjne(string plec, string idLokalizacji, string imie, string nazwisko, string email, string haslo,
		                                      string numerTel, string obecnyMail,string rok, string dzien, string numerMiesiaca)
		{
			UzupelnijDane(imie,nazwisko, email, haslo, numerTel, obecnyMail);
			PodajLokalizacje(idLokalizacji);
			WybierzPlec(plec);
			WyborDatyUrodzenia(rok,dzien,numerMiesiaca);
			ZapiszWynikDoPliku("Nazwa testu: ", TestContext.CurrentContext.Test.Name);
			ZapiszWynikDoPliku("Wprowadzone dane: " , "Dla adresu : " + podajEmail.GetAttribute("value" ));
		}
		
		
		
	}
}
