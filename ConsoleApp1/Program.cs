using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        struct Month
        {
            public string month;
            public int dayofMonth;
        };
        
        static void Main(string[] args)
        {
            int DayG = 9;
            int MonthG = 6;
          //  Console.ReadLine(DayG);
            //Console.ReadLine(MonthG);
            bool LeapBool=true;
            Month[] MonthArray = new Month[11];
            int DayofYear = 0;
            int Sum = 0;
            MonthArray[0].month = "Январь";
            MonthArray[0].dayofMonth = 31;
            MonthArray[1].month = "Февраль";
            MonthArray[1].dayofMonth = 28;
            MonthArray[2].month = "Март";
            MonthArray[2].dayofMonth = 31;
            MonthArray[3].month = "Апрель";
            MonthArray[3].dayofMonth = 30;
            MonthArray[4].month = "Май";
            MonthArray[4].dayofMonth = 31;
            MonthArray[5].month = "Июнь";
            MonthArray[5].dayofMonth = 30;
            MonthArray[6].month = "Июль";
            MonthArray[6].dayofMonth = 31;
            MonthArray[7].month = "Август";
            MonthArray[7].dayofMonth = 31;
            MonthArray[8].month = "Сентябрь";
            MonthArray[8].dayofMonth = 30;
            MonthArray[9].month = "Октябрь";
            MonthArray[9].dayofMonth = 31;
            MonthArray[10].month = "Ноябрь";
            MonthArray[10].dayofMonth = 30;
            MonthArray[11].month = "Декабрь";
            MonthArray[11].dayofMonth = 31;
            if (LeapBool == true)
            {
                MonthArray[1].dayofMonth = 29;
            }
            for (int i = 0; i < MonthG; i++)
            {
                Sum = MonthArray[i].dayofMonth + Sum;
            }
            DayofYear = Sum + DayG;
            Console.Write(DayofYear);
        }
    }
}
