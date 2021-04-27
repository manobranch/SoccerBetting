using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fotbollstips.Logic
{
    public static class InsightsLogic
    {
        static readonly Microsoft.ApplicationInsights.TelemetryClient telemetry = new Microsoft.ApplicationInsights.TelemetryClient();

        public static void TrackEvent(string eventText)
        {
            Track(LogLevel.INFO, eventText);
        }

        public static void TrackEvent(string logText, Exception e)
        {
            logText += $"The exception: {e.Message}";
            Track(LogLevel.ERROR, logText);
        }

        private static void Track(LogLevel level, string logText)
        {
            telemetry.TrackEvent($"{level}. Tracking Event: {logText}");

            telemetry.Flush();
        }

        //private static string BuildLogText(LogLevel level, string logText, Exception e)
        //{
        //    string returnString = "";
        //    returnString += $"Level {level}. Text: {logText} \n\n";

        //    if (e != null)
        //    {
        //        string inner = e.InnerException != null ? e.InnerException.ToString() : "NULL";

        //        returnString += $"Exception: {e.Message} Inner exception: {inner}";
        //    }

        //    return returnString;
        //}

        private enum LogLevel
        {
            INFO,
            ERROR
        }
    }
}