using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.CustomMeasurments
{
    public class TimedActionMeasurement : Measurement
    {
        private Stopwatch _sw;

        public TimedActionMeasurement(string actionName, Action action)
            : base("Common.Custom.TimedAction")
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