using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIapplication
{
    public class Pack
    {
        private static List<string> allCards = new List<string>()
        { "2черви", "2пики", "2крести", "2буби",
          "3черви","3пики", "3крести", "3буби",
          "4черви", "4пики", "4крести", "4буби",
          "5черви", "5пики", "5крести", "5буби",
          "6черви","6пики", "6крести", "6буби",
          "7черви", "7пики", "7крести", "7буби",
          "8черви", "8пики", "8крести", "8буби",
          "9черви","9пики", "9крести", "9буби",
          "10черви", "10пики", "10крести", "10буби",
          "Вчерви", "Впики", "Вкрести", "Вбуби",
          "Дчерви","Дпики", "Дкрести", "Дбуби",
          "Кчерви", "Кпики", "Ккрести", "Кбуби",
          "Тчерви", "Тпики", "Ткрести", "Тбуби",
        };
        
        public string name;
        public int countCards;
        public List<string> cards;

        public Pack(string name, int countCards)
        {
            this.name = name;
            this.countCards = countCards;
            cards = allCards.GetRange(0, this.countCards);
        }

    }
}
