using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Time

    {
        private int currenttSec;
        private int currenttMin;
        public int Hour { get; private set; } = 0;

        public int Min { get; private set; } = 0;

        public int Sec { get; private set; } = 0;

        public Time(int hour, int min, int sec)
        {
            if ((23 >= hour && hour >= 0) && (59 >= min &&  min >= 0) && (59 >= sec && sec >= 0))
            {
                Hour = hour;
                Min = min;
                Sec = sec;
                currenttSec = Hour * 3600 + Min * 60 + Sec;
                currenttMin = Hour * 60 + Min;
                if (Sec > 29) currenttMin ++;
            }
        }
        public Time(string time)
        {   
            char[] delimiterChars = { ' ', ',', '.', ':', '/', '\t' };

            string[] times = time.Split(delimiterChars);

            if ((23 >= int.Parse(times[0]) && int.Parse(times[0]) >= 0) 
                && (59 >= int.Parse(times[1]) && int.Parse(times[1]) >= 0) 
                && (59 >= int.Parse(times[2]) && int.Parse(times[2]) >= 0))
            {
                Hour = int.Parse(times[0]);
                Min = int.Parse(times[1]);
                Sec = int.Parse(times[0]);
                currenttSec = Hour * 3600 + Min * 60 + Sec;
                currenttMin = Hour * 60 + Min;
                if (Sec > 29) currenttMin++;
            }

        }

        public Time(int sec)
        {
            if (sec>0 && sec< 86400)
            {
                currenttSec = sec;
                Hour = sec / 3600;
                sec %= 3600;
                Min = sec / 60;
                sec %= 60;
                Sec = sec;
                
                currenttMin = Hour * 60 + Min;
                if (Sec > 29) currenttMin++;
            }

        }

        public Time(TimeOnly time)
        {
            Hour = time.Hour;
            Min = time.Minute;
            Sec = time.Second;

            currenttSec = Hour * 3600 + Min * 60 + Sec;
            currenttMin = Hour * 60 + Min;
            if (Sec > 29) currenttMin++;
        }

        public void AddSecond(int sec)
        {
            if (currenttSec + sec > 86399)
            {
                currenttSec += -86400 + sec;
                currenttMin = Hour * 60 + Min;
                if (Sec > 29) currenttMin++;
                Hour = sec / 3600;
                sec %= 3600;
                Min = sec / 60;
                sec %= 60;
                Sec = sec;
                return;
            }
            else if (currenttSec + sec < 0)
            {
                currenttSec += 86400 + sec;
                currenttMin = Hour * 60 + Min;
                if (Sec > 29) currenttMin++;
                Hour = sec / 3600;
                sec %= 3600;
                Min = sec / 60;
                sec %= 60;
                Sec = sec;
                return;
            }
            currenttSec += sec;
            currenttMin = Hour * 60 + Min;
            Hour = sec / 3600;
            sec %= 3600;
            Min = sec / 60;
            sec %= 60;
            Sec = sec;
            if (Sec > 29) currenttMin++;
        }

        public int CompareTime(int h, int m = 0, int s = 0)
        {
            int temp = h * 3600 + m * 60 + s;
            int diff;

            if (temp >= currenttSec)
                diff = temp - currenttSec;
            else
                diff = 86400 - currenttSec + temp;
            return diff;
        }


        public int GetMinut()
        {
            return currenttMin;
        }

        public override string ToString()
        {
            return $"h:{this.Hour} m:{this.Min} s:{this.Sec}";
        }
    }
}
