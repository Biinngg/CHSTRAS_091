using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSTRAS_091_BT.Common
{
    public class btCHSTRAS_091_Time
    {
        public String getTime(DateTime dateTime)
        {
            String time = "";
            if (dateTime.Hour < 10)
                time += "0";
            time += dateTime.Hour + ":";
            if (dateTime.Minute < 10)
                time += "0";
            time += dateTime.Minute + ":";
            if (dateTime.Second < 10)
                time += "0";
            time += dateTime.Second;
            return time;
        }
        public String getTime(TimeSpan dateTime)
        {
            String time = "";
            if (dateTime.Hours < 10)
                time += "0";
            time += dateTime.Hours + ":";
            if (dateTime.Minutes < 10)
                time += "0";
            time += dateTime.Minutes + ":";
            if (dateTime.Seconds < 10)
                time += "0";
            time += dateTime.Seconds;
            return time;
        }

        public int getAnswerTime(DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan diff = now - dateTime;
            return (int)diff.TotalSeconds;
        }
    }
}
