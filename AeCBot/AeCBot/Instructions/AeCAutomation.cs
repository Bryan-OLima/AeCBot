using AeCBot.DAL;
using AeCBot.Interfaces;
using AeCBot.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeCBot.Instructions
{
    internal class AeCAutomation
    {
        public IWebDriver Driver { get; set; }
        public IAeCAPIContext AeCDAL { get; set; }

        public AeCAutomation()
        {
            try
            {
                ChromeOptions options = new ChromeOptions(); 
                //options.SetLoggingPreference(LogType.Driver, LogLevel.Off);
                options.AddArgument("--disable-notifications");

                Driver = new ChromeDriver(options);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GoToUrl(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"It was not possible to connect to URL {url}. Please, insert a valid URL.");
            }
        }

        public void FindData()
        {
            try
            {
                IReadOnlyList<IWebElement> cards = Driver.FindElements(By.ClassName("cardPost"));
                AeCModel data;
                string url = "https://localhost:7284/api/Automations";
                int index = 0;

                foreach (IWebElement card in cards)
                {
                    string authorSplitter = card.FindElement(By.TagName("small")).Text;

                    var authorSplitted = authorSplitter.Split("em");

                    data = new AeCModel();

                    string title = card.GetAttribute("title");
                    string area = card.FindElements(By.TagName("span"))[0].Text;
                    string author = authorSplitted[0].Replace("Publicado por", "").Trim();
                    string description = card.FindElement(By.TagName("p")).Text;
                    string publicationDate = authorSplitted[1].Trim();

                    data.Title = title;
                    data.Area = area;
                    data.Description = description;
                    data.PublicationDate = publicationDate;
                    data.Author = author;
                    
                    Console.WriteLine($"Item {index+1}: {data.Title}, {data.Area}, {data.Description}, {data.PublicationDate}, {data.Author}");
                    Console.WriteLine("___________________________________________");

                    PostData(url, data);
                    index++;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task PostData(string url, AeCModel aecModel)
        {
            AeCDAL = new AeCDAL(new HttpClient());
            await AeCDAL.PostConsult(url, aecModel);
        }
        

        public async Task StartProgram(string entry)
        {
            AeCDAL = new AeCDAL(new HttpClient());

            string url = "https://localhost:7284/api/Automations";
            var data = await AeCDAL.GetConsult<List<AeCModel>>(url);

            while (entry != null)
            {
                if (entry == "1")
                {
                    Console.WriteLine("Consulting...");
                }
                else
                {
                    Console.WriteLine($"{entry} is not valid! Try valid options.");
                }
                Console.WriteLine("________________________________");
                Console.WriteLine("Press 1 to retry or 2 to quit");
                Console.WriteLine("________________________________");
                entry = Console.ReadLine();
            }
        }
    }
}
