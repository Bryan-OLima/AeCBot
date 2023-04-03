using AeCBot.Instructions;
using OpenQA.Selenium;

var bot = new AeCConsults();

Console.Write("Hello! I'm AeC Bot. To start press '1':");
Thread.Sleep(1000);
var entry = Console.ReadLine();

bot.Start(entry);