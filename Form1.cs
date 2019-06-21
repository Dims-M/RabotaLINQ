using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RabotaLINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BL bLTest = new BL();

        //при загрузке форма   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        //Кнопка запуска
        private void Button1_Click(object sender, EventArgs e)
        {

            // ChekerZ(); // метод с поискам по умолчания
            // ChekerParams1(textBox2.Text);

            ZapuskMethodLinq(); // работаем с множеством.
        }
        //Кнока Очистить
        private void Button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = "Происходит очистка текста";
            label1.Text = "Происходит очистка журнала событий";

            //Thread.Sleep(1000);

            textBox1.Text ="";
            label1.Text = "";
        }

        //Выход из формы
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        //МЕТОДЫ

      private void ChekerZ()
        {
            var temp_data = bLTest.SelectLinqPlanetDefault("М");

           textBox1.Text = bLTest.VividLista(temp_data);
            label1.Text = "Работа с Листом \t\nКласс BL";
        }


        /// <summary>
        /// Метод поиска из текст бокса 2
        /// </summary>
        /// <param name="paramSeath"></param>
        private void ChekerParams1(string paramSeath)
        {
            var temp_data = bLTest.SelectLinqPlanetDefault(paramSeath);

           textBox1.Text = bLTest.VividLista(temp_data);
            label1.Text = "Работа с Листом \t\nКласс BL";
        }


        private void ZapuskMethodLinq()
        {
          // var temp_data = bLTest.SelectLinqPlanetDefault(paramSeath);

            //textBox1.Text = bLTest.RabLingPrimer1();
           // textBox1.Text = bLTest.testXmlTTN(); // работо с хмл Егаис
            //textBox1.Text = bLTest.TestJobXML_Metanit("TTN8586435953960426846.xml");  
            textBox1.Text = bLTest.TestLig_Meta("TTN8586435953960426846.xml");
            //textBox1.Text = bLTest.XML_Job(); //Работает
            label1.Text = "Работа с Ling №1 \t\nКласс BL";
        }

        //********************************************************
        //Прочитать журнал собыйтий 
        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = bLTest.GetLogVents();
        }

        //Кнопка поиска 
        private void Button5_Click(object sender, EventArgs e)
        {
            ChekerParams1(textBox2.Text);
        }


    }

}
