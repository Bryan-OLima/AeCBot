using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeCBot.Instructions
{
    internal class AeCConsults
    {
        private AeCAutomation bot;
        public AeCConsults()
        {
            bot = new AeCAutomation();
        }

        public void Start(string entry)
        {
            bot.GoToUrl("https://www.aec.com.br/?s=Automa%C3%A7%C3%A3o");

            bot.StartProgram(entry);

            bot.FindData();
        }
    }
}
