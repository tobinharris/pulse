using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Pulse.Domain;

namespace Pulse.Observers.Common.Measurments
{
    public class TimedActionMeasurement : Measurement
    {
        private Stopwatch _sw;

        public TimedActionMeasurement(string actionName, Action action)
            : base("Common.TimedAction")
        {
            _sw = new Stopwatch();
            _sw.Start();
            ActionName = actionName;
            action.Invoke();
            Value =  _sw.ElapsedMilliseconds;
            _sw.Stop();
        }

        [JsonProperty]
        public string ActionName { get; set; }


    }
}