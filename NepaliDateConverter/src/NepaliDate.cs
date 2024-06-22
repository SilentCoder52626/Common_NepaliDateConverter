using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NepaliDateConverter
{
    public class NepaliDate
    {
        public int Year;
        public string Month;
        public string Day;
        public string WeekDayName;
        public string MonthName;
        public int WeekDay;
        static Dictionary<int, string> _charactermapping = new Dictionary<int, string>() {
            {0, "०"},
            {1, "१"},
            {2, "२"},
            {3, "३"},
            {4, "४"},
            {5, "५"},
            {6, "६"},
            {7, "७"},
            {8, "८"},
            {9, "९"}
            };
        static Dictionary<string, string> _daysMapping = new Dictionary<string, string>() {
            {"Sunday", "आइतवार"},
            {"Monday", "सोमवार"},
            {"Tuesday", "मंगलवार"},
            {"Wednesday", "बुधवार"},
            {"Thursday", "बिहीवार"},
            {"Friday", "शुक्रवार"},
            {"Saturday", "शनिवार"},
            };
        public NepaliDate()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Year, Month, Day);

        }
        public string ToStringNepali()
        {
            return string.Format("{0}/{1}/{2}", ConvertNepaliDigitToUnicode(Year), ConvertNepaliDigitToUnicode(Convert.ToInt32(Month)), ConvertNepaliDigitToUnicode(Convert.ToInt32(Day)));
        }
        public string ToStringNepaliWithEnglishCharacter()
        {
            return string.Format("{0}/{1}/{2}", Year, Month, Day);
        }

        public string ToLongDateString()
        {
            return string.Format("{0}, {1} {2}, {3}", WeekDayName, MonthName, ConvertNepaliDigitToUnicode(Convert.ToInt32(Day)), ConvertNepaliDigitToUnicode(Year));
        }
        public string ToLongDateStringItiSambat()
        {
            return string.Format("{0} साल {1} महिना {2} गते रोज {3}", ConvertNepaliDigitToUnicode(Year), MonthName, ConvertNepaliDigitToUnicode(Convert.ToInt32(Day)), WeekDayName);
        }

        public string ConvertNepaliDigitToUnicode(int number)
        {
            StringBuilder nepali = new StringBuilder();
            do
            {
                var num = number % 10;
                nepali = nepali.Insert(0, _charactermapping[num]);
                number = number / 10;
            } while (number > 0);
            return nepali.ToString();
        }

    }
}
