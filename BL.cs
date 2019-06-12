﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabotaLINQ
{

    /// <summary>
    /// Работа с LINQ
    /// </summary>
   public class BL
    {
      private  string logEvents = "Журнал событий";
        List<string> listData;
        string[] planet =
        {
            "Меркурий",
            "Венера",
            "Земля",
            "Марс",
            "Юпитер",
            "Сатурн",
            "Уран",
            "Нептун",
        };

        /// <summary>
        /// Метод ищет в массиве строк нужное значение. Возращает лист
        /// </summary>
        /// <param name="massPlanet">Массив строк</param>
        /// <param name="seach">Поисковое значение</param>
        /// <returns></returns>
    public  List<string> SelectLinqPlanet(string[] massPlanet, string seach )
        {
            List<string> listTemp = new List<string>();

            foreach (string planeta in massPlanet)
            {
                if (planet.Contains(seach))
                {
                    listTemp.Add(planet.ToString());
                }
            }

            return listTemp;
        }


        /// <summary>
        /// Метод использует лист с планетами по умолчанию.
        /// </summary>
        /// <param name="seach">Поисковый параметтр</param>
        /// <returns></returns>
        public List<string> SelectLinqPlanetDefault(string seach)
        {
            logEvents += $"Метод поиска в списока планет {System.Environment.NewLine}";
            List<string> listTemp = new List<string>();

            foreach (string planeta in planet)
            {
                if (planeta.ToUpper().Contains(seach)) // приводим все строки в рехний регист потом ищем на совпадения
                {
                    listTemp.Add(planeta);
                }
   
            }

            if (listTemp.Count() == 0)
            {
             logEvents += $"Метод поиска в списока планет НИЧЕГО НЕ НАЙДЕНО {System.Environment.NewLine}";
            }

            return listTemp;
        }

        /// <summary>
        /// Метод преоброзования в строку всех элементов спика
        /// </summary>
        /// <param name="listSorse">Аригинальный список</param>
        /// <returns></returns>
        public string VividLista(List<string> listSorse)
        {
            string tempSttring = $"Содержимое списка: {System.Environment.NewLine}";
            logEvents += $"Метод вывода списка {System.Environment.NewLine}";
            foreach (var myList in listSorse)
            {
                tempSttring += $"{myList.ToString()} {System.Environment.NewLine}";
            }

            return tempSttring;
        }

        /// <summary>
        /// Метод проччитать журнал событий
        /// </summary>
        /// <returns></returns>
        public string GetLogVents()
        {
            return logEvents;
        }


      public List<string> GetListData()
        {


            return null;
        }


    }
}
