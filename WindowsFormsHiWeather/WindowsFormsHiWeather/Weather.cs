using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsHiWeather
{
    class Weather
    {
        string place;//장소
        Conditions[] day;//날짜
        Conditions[] hour;//시간

        public Weather(string place, Conditions[] conditions_day, Conditions[] conditions_hour)
        {
            this.place = place;
            day = conditions_day;
            hour = conditions_hour;
        }

        public string Place { get => place; }
        internal Conditions[] Day { get => day; }
        internal Conditions[] Hour { get => hour; }
    }
}
