using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesToSleep = 0;// How many minutes it will wait between checking what time it is
            int currentHour = 1;//Hour of the day
            string wallPaperName1 = "city";//Base name of the wallpaper images
            //Names would be city1, city2, ... city24

            wallPaperName1 += System.DateTime.Now.AddHours(-11).Hour.ToString();
            currentHour = System.DateTime.Now.AddHours(-11).Hour;
            if (currentHour <= 0)
            {
                currentHour = 1;
                wallPaperName1 = "city" + currentHour;
            }
            Wallpaper.Set(wallPaperName1 + ".jpg", Wallpaper.Style.Stretched);


            while (true)
            {
                minutesToSleep = 10;
                int millisecondsToSleep = minutesToSleep * 10000;
                Console.WriteLine("Sleeping for " + millisecondsToSleep + " milliseconds.");
                System.Threading.Thread.Sleep(millisecondsToSleep);
                if (System.DateTime.Now.AddHours(-11).Hour != currentHour)
                {
                    string wallPaperName = "city";
                    wallPaperName += System.DateTime.Now.AddHours(-11).Hour.ToString();
                    currentHour = System.DateTime.Now.AddHours(-11).Hour;
                    if (currentHour <= 0)
                    {
                        currentHour = 1;
                        wallPaperName1 = "city" + currentHour;
                    }
                    Wallpaper.Set(wallPaperName + ".jpg", Wallpaper.Style.Stretched);
                    minutesToSleep = 0;
                }
            }
        }
    }
}
