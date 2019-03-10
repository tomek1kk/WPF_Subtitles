using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Subtitles
{
    class Time
    {
        private int hour, hour2;
        private int minutes, minutes2;
        private int seconds, seconds2;
        private int miliseconds, miliseconds2;
        private string line;

	    public static bool CheckIfItsTime(string line)
        {
            if (line.Length < 16)
                return false;
            if (line[2] == ':' && line[5] == ':' && line[8] == ',' && line[13] == '-' && line[14] == '-' && line[15] == '>')
                return true;
            return false;
        }
        public Time(string line)
        {
            this.line = line;
            hour = (int)(line[0] - '0') * 10 + (int)(line[1] - '0');
            minutes = (int)(line[3] - '0') * 10 + (int)(line[4] - '0');
            seconds = (int)(line[6] - '0') * 10 + (int)(line[7] - '0');
            miliseconds = (int)(line[9] - '0') * 100 + (int)(line[10] - '0') * 10 + (int)(line[11] - '0');
            hour2 = (int)(line[17] - '0') * 10 + (int)(line[18] - '0');
            minutes2 = (int)(line[20] - '0') * 10 + (int)(line[21] - '0');
            seconds2 = (int)(line[23] - '0') * 10 + (int)(line[24] - '0');
            miliseconds2 = (int)(line[26] - '0') * 100 + (int)(line[27] - '0') * 10 + (int)(line[28] - '0');
        }
        public void Move(int miliseconds)
        {
            int minutes = miliseconds / (60 * 1000);
            miliseconds -= minutes * 60000;
            int seconds = miliseconds / 1000;
            miliseconds -= seconds * 1000;

            this.miliseconds += miliseconds;
            this.seconds += seconds;
            this.minutes += minutes;
            this.miliseconds2 += miliseconds;
            this.seconds2 += seconds;
            this.minutes2 += minutes;
            this.Repair();
            this.line = this.ToString();
        }

        public override string ToString()
        {
            string wynik = "00:00:00,000 --> 00:00:00,000";

            wynik = wynik.MyReplace(0, hour);
            wynik = wynik.MyReplace(3, minutes);
            wynik = wynik.MyReplace(6, seconds);
            wynik = wynik.MyReplace2(9, miliseconds);

            wynik = wynik.MyReplace(17, hour2);
            wynik = wynik.MyReplace(20, minutes2);
            wynik = wynik.MyReplace(23, seconds2);
            wynik = wynik.MyReplace2(26, miliseconds2);

            return wynik;
        }


        private void Repair()
        {
            if (miliseconds > 999)
            {
                miliseconds -= 1000;
                seconds++;
            }
            if (miliseconds < 0)
            {
                miliseconds += 1000;
                seconds--;
            }
            if (seconds > 59)
            {
                seconds -= 60;
                minutes++;
            }
            if (seconds < 0)
            {
                seconds += 60;
                minutes--;
            }
            if (minutes > 59)
            {
                minutes -= 60;
                hour++;
            }
            if (minutes < 0)
            {
                minutes += 60;
                hour--;
            }
            if (miliseconds2 > 999)
            {
                miliseconds2 -= 1000;
                seconds2++;
            }
            if (miliseconds2 < 0)
            {
                miliseconds2 += 1000;
                seconds2--;
            }
            if (seconds2 > 59)
            {
                seconds2 -= 60;
                minutes2++;
            }
            if (seconds2 < 0)
            {
                seconds2 += 60;
                minutes2--;
            }
            if (minutes2 > 59)
            {
                minutes2 -= 60;
                hour2++;
            }
            if (minutes2 < 0)
            {
                minutes2 += 60;
                hour2--;
            }
            if (hour < 0 || minutes < 0 || seconds < 0 || miliseconds < 0 || hour2 < 0 || minutes2 < 0 || seconds2 < 0 || miliseconds2 < 0)
            {
                hour = 0; minutes = 0; seconds = 0; miliseconds = 0;
                hour2 = 0; minutes2 = 0; seconds2 = 0; miliseconds2 = 0;
            }
        }
    }
}
