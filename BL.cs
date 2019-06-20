using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        string[] arr2 =
       {
            "Земля",
            "Плутон",
            "Цицера",
            
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

        /// <summary>
        /// Работаем с Linq и с разностью множеств.
        /// </summary>
        /// <returns></returns>
        public string RabLingPrimer1()
        {
            string tempM = $"Cодержимое множест {System.Environment.NewLine}";
            //В список попадают только уникальные элемены. дубли убираются.
            var result = planet.Except(arr2); // разность множест

            foreach (var strTemp in result)
            {
                tempM +=  $"{strTemp} {System.Environment.NewLine}";

            }

            result = planet.Intersect(arr2);
            tempM += $"Совпадения в множествах {System.Environment.NewLine}";

            foreach (var strTemp in result)
            {
                tempM += $"{strTemp} {System.Environment.NewLine}";
            }

            tempM += $"Cовмещение в множествах из других колекций{System.Environment.NewLine}";
            result = planet.Union(arr2);
            foreach (var strTemp in result)
            {
                tempM += $"{strTemp} {System.Environment.NewLine}";
            }
            logEvents += $"Метод отбора Множеств \n {System.Environment.NewLine} ";

            return tempM;
        }

        //РАбота XML документами

       public string XML_Job()
        {
            string pathFileXml = @"C:\Users\Dim\source\repos\RabotaLINQ\Sp.xml";

            XDocument sputniks = XDocument.Load(pathFileXml);

            var Sputniks = from sp in sputniks.Element("sputniks").Elements("sputnik") // Выбираем сначало корневой элемент. Потом нужные дочерние элементы
                           select new Sputnik // новый обьект для хранения 
                           {
                               id = int.Parse(sp.Attribute("id").Value), // получаем атрибуты из xml страницы. 
                               planet_id = int.Parse(sp.Element("planet_id").Value), // получаем конкретные елементы(строки) xml страницы.
                               name = sp.Element("name").Value //// получаем конкретные елементы(строки)

                           };

            string tempCount = "Содержимое хмл" + Environment.NewLine;

            foreach (var temEgais in Sputniks)
            {
                tempCount += $"ID Планеты:{temEgais.id}, ID:{temEgais.planet_id} Название планеты {temEgais.name} {Environment.NewLine}";
            }

            return tempCount;
        }

        public string testXmlTTN()
        {
            //TestEgais testEgais;

            string pathFileXml = @"C:\Users\Dim\source\repos\RaboraXML\RaboraXML\TTN8586435953960426846.xml";
            //string pathFileXml = @"C:\Users\Dim\source\repos\RabotaLINQ\Sp.xml";
            //string pathFileXml = @"C:\Users\Dim\source\repos\RabotaLINQ\users.xml"; //Работает
            //string pathFileXml = @"users.xml";

            string temStr = "";

            XDocument EGAIS_Document = XDocument.Load(pathFileXml); // загружаем хмл файл

          //  var Egais = from egais in EGAIS_Document.Element("users").Elements("user")
            var Egais = from egais in EGAIS_Document.Element("Documents").Elements("Header")
                        select new TestEgais
                        {
                            ttn = egais.Element("NUMBER").Value,
                            FullName = egais.Element("Type").Value

                        }
                        ;


            string tempCount ="Содержимое хмл"+ Environment.NewLine;

            foreach (var temEgais in Egais)
            {
                tempCount += $"Номер накладной:{temEgais.ttn}, Имя продукции:{temEgais.FullName} {Environment.NewLine}";
            }

            return tempCount;
        }


      public List<string> GetListData()
        {


            return null;
        }



    }
}
 