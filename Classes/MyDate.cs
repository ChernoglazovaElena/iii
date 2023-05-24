using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Classes
{
    internal class MyDate
    {
        public static string SetDays(string date, int day)
        {
            string[] dateSplit = splitDate(date);
            if (day >= 10)
            {
                dateSplit[0] = day.ToString();
            }
            else
            {
                dateSplit[0] = $"0{day}";
            }
            return unsplitDate(dateSplit);
        }
        public static string unsplitDate(string[] dateSplit)
        {
            string date = "";
            foreach (var element in dateSplit)
            {
                date += element + ".";
            }
            date = date.Remove(date.Length - 1);
            return date;
        }
        public static string[] splitDate(string Date)
        {
            string[] DMY = Date.Split(".");
            for (int i = 0; i < 3; i++)
            {
                if (DMY[i][0] == '0')
                {
                    DMY[i] = DMY[i][1].ToString();
                }
            }
            return DMY;
        }
        public static string NextDate(string Date)
        {
            string[] dateSplit = splitDate(Date);
            dateSplit[1] = (Convert.ToInt32(dateSplit[1]) + 1).ToString();
            if (Convert.ToInt32(dateSplit[1]) > 12)
            {
                dateSplit[1] = "1";
                dateSplit[2] = (Convert.ToInt32(dateSplit[2]) + 1).ToString();
            }
            return unsplitDate(dateSplit);
        }
        public static string BackDate(string Date)
        {
            string[] dateSplit = splitDate(Date);
            dateSplit[1] = (Convert.ToInt32(dateSplit[1]) - 1).ToString();
            if (Convert.ToInt32(dateSplit[1]) < 1)
            {
                dateSplit[1] = "12";
                dateSplit[2] = (Convert.ToInt32(dateSplit[2]) - 1).ToString();
            }
            return unsplitDate(dateSplit);
        }
    }
}
