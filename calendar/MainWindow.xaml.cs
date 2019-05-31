using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int dayJulian, dayofweekJulian, dayofweekGrigorian, dayGrigorian, monthGrigorian, monthJulian, yearJulian, yearGrigorian, LeapG,LeapJ, DayOfYearJ,DayOfYearG,Diff;
        public bool LeapBoolG,LeapBoolJ;
        int diff =0;
        struct Month{
        public string month;
        public int dayofMonth;
        };
        Month[] MonthArray = new Month[12];
        public MainWindow()
        {
            InitializeComponent();
            YearGrigorian.TextChanged += YearGrigorian_TextChange;
            YearJulian.TextChanged += YearJulian_TextChange;
            Exceptions.Text = null;
        }

        private void YearJulian_TextChange(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                yearJulian = int.Parse(YearJulian.Text);
                Exceptions.Text = "работает";
            }
            catch
            {
                Exceptions.Text = "Oшибка ввода";
            }
            
        }

        private void YearGrigorian_TextChange(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                yearGrigorian = int.Parse(YearGrigorian.Text);
                Exceptions.Text = "работает";
            }
            catch
            {
                Exceptions.Text = "ошибка ввода";
            }
            
        }
        public int CountDayofYear(int DayG, int MonthG,bool LeapBool) {//сделать високосный/нет и от этого считать дни февраля и дальше уже нормально складывать
            int DayofYear;
            int Sum=0;
            
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
            for (int i=1;i<MonthG;i++) {
                Sum=MonthArray[i].dayofMonth+Sum;
            }
            DayofYear = Sum + DayG;
            //сделать массив и записать туда. 
            return DayofYear;
        }
        public int CountDateGJ(int diff,int YearG)
        {
            int DayOfChristGrigorian=0;
            DayOfChristGrigorian =(YearG-diff)*365+diff*366+DayOfYearG;
            return DayOfChristGrigorian;
        }
        public int CountDiff(int leapG,int leapJ) {
            int diff = leapJ - leapG;
            return diff;
        }
        public int CountLeapG(int yearGrigorian,bool LeapBoolG)
        {
            int leapG=0;
            for (int i=0; i<=yearGrigorian;i++) {
                if (i % 4 == 0)
                {
                    leapG = leapG + 1;
                    LeapBoolG = true;
                }
                else if ((i % 400 == 0) || (i % 100 == 0))//20 век-разница 15 дней,а должно быть 13
                {
                    leapG = leapG - 1;
                    LeapBoolG = false;
                }
                
            }
            return leapG;
        }
        public int CountLeapJ(int yearJulian,bool LeapBoolJ) {//брать из одного год и через века посчитать разницу с помощью mod  и условия
            int leapJ=0;
            for (int i = 0; i <= yearJulian; i++)
            {
                if (i % 4 == 0)
                {
                    leapJ =leapJ+ 1;
                    LeapBoolJ = true;
                }
                else
                {
                    LeapBoolJ = false;
                }
            }
            return leapJ;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dayofweekGrigorian = 1 + DayOfWeekGrigorian.SelectedIndex;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            dayGrigorian = 1 + DayGrigorian.SelectedIndex;
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            monthGrigorian = 1 + MonthGrigorian.SelectedIndex;
        }
        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            dayofweekJulian = 1 + DayOfWeekJulian.SelectedIndex;
            
        }
        private void DayJulian_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dayJulian = 1 + DayJulian.SelectedIndex;
        }
        private void MonthJulian_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            monthJulian = 1 + MonthJulian.SelectedIndex;
        }
       
        private void BtnToG_Click(object sender, RoutedEventArgs e)
        {
             DayOfYearJ = CountDayofYear(dayJulian, monthJulian, LeapBoolJ);
             LeapJ = CountLeapJ(yearJulian, LeapBoolJ);
             LeapG = CountLeapG(yearGrigorian, LeapBoolG);
             Diff = CountDiff(LeapG, LeapJ);
        }
        private void BtnToJ_Click(object sender, RoutedEventArgs e)
        {
            DayOfYearG=CountDayofYear(dayGrigorian, monthGrigorian,LeapBoolG);
            LeapG=CountLeapG(yearGrigorian,LeapBoolG);
            LeapJ = CountLeapJ(yearGrigorian, LeapBoolJ);
            Diff =CountDiff(LeapG,LeapJ);
            CountDateGJ(Diff,yearGrigorian);
        }
    }
}
