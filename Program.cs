// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

namespace linq // Note: actual namespace depends on the project name.
{
    class Date
    {
        private int day;
        private int month;
        private int year;
        public Date(int day, int month, int year)
        {
            if (day > 0 && day < 32)
                this.day = day;
            else
                this.day = 1;

            if (month > 0 && month < 13)
                this.month = month;
            else
                this.month = 1;

            this.year = year;
        }
        public int Day
            { get { return day; } }
        public int Month
            { get { return month; } }
        public int Year
            { get { return year; } }
    }
    internal class Program
    {
        static void Main()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            var monthsNLength =
                from m in months
                where m.Length == 5
                select m;

            Console.Write("Последовательность месяцев с длиной строки равной n (5): ");
            foreach (var m in monthsNLength)
                Console.Write($"{m} ");


            var winterAndSummerMonths =
                from m in months
                where (m == "January") || (m == "February") || (m == "June") || (m == "July") || (m == "August") || (m == "December")
                select m;

            Console.Write("\n\nЛетние и зимние месяцы: ");
            foreach (var m in winterAndSummerMonths)
                Console.Write($"{m} ");


            var monthsInAlphabetOrder =
                from m in months
                orderby m
                select m;

            Console.Write("\n\nМесяцы в алфавитном порядке: ");
            foreach (var m in monthsInAlphabetOrder)
                Console.Write($"{m} ");


            var monthsWithUChar =
                from m in months
                where m.ToUpper().Contains(Char.ToUpper('a')) && m.Length > 3
                select m;

            Console.Write("\n\nМесяцы, содержащие букву «u» и длиной имени не менее 4-х («u» - 'a'): ");
            foreach (var m in monthsWithUChar)
                Console.Write($"{m} ");


            Console.WriteLine("\n\n-------------------------------------------------------------------------------------------\n");

            var dates = new List<Date>
            {
                new Date (5, 2, 2002),
                new Date (14, 1, 2014),
                new Date (1, 9, 2007),
                new Date (30, 7,2000),
                new Date (9, 12, 2019),
                new Date (30, 4, 2008),
                new Date (5, 8, 1999),
                new Date (18, 2, 2003),
                new Date (3, 7, 2004),
                new Date (4, 8, 2005),
                new Date (5, 9, 2008),
                new Date (6, 8,2010),
                new Date (10, 9, 2015),
                new Date (11, 3, 2022),
                new Date (17, 5, 2001),
                new Date (18, 6, 2018),
                new Date (18, 6, 2022),
                new Date (19, 7, 2022),
                new Date (18, 7, 2022)
            };

            var datesByYear = dates.Where(d => d.Year == 2008);

            Console.Write("\nCписок дат для заданного года (2008): ");
            foreach (var date in datesByYear)
                Console.Write($"{date.Day}.{date.Month}.{date.Year} ");


            var datesByMonth = dates.Where(d => d.Month == 8);

            Console.Write("\n\nCписок дат в заданном месяце (Август): ");
            foreach (var date in datesByMonth)
                Console.Write($"{date.Day}.{date.Month}.{date.Year} ");


            var counter = (from d in dates
                          where d.Day > 5 && d.Day < 18 && d.Month > 2 && d.Month < 8 && d.Year > 2000 && d.Year < 2012
                          select d).Count();

            Console.Write($"\n\nКоличество дат в определённом диапазоне (день: 6-17, месяц: 3-7, год: 2001-2011): {counter}");


            var maxDate = dates.OrderByDescending(d => d.Day).OrderByDescending(d => d.Month).OrderByDescending(d => d.Year).FirstOrDefault();

            Console.Write($"\n\nМаксимальная дата: {maxDate.Day}.{maxDate.Month}.{maxDate.Year}");


            var firstDateGivenDay = dates.First(d => d.Day == 18);

            Console.Write($"\n\nПервая дата для заданного дня (18): {firstDateGivenDay.Day}.{firstDateGivenDay.Month}.{firstDateGivenDay.Year}");


            var sortedDates = from d in dates
                              orderby d.Year, d.Month, d.Day
                              select d;

            Console.Write("\n\nУпорядоченный список дат (хронологически):\n");
            foreach (var date in sortedDates)
                Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
        }

    }
}