using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.ObservationTypes;
using Pulse.Emmiters.DotNet.Core.Observers;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet
{
    public static class PulseManager
    {
        private static readonly Register RegisterInstance = new Register();
        private static string _apiKey = String.Empty;
        internal static bool IsInitialized
        {
            get { return _apiKey != String.Empty;  }
        }

        public static void Init(string apiKey)
        {
            _apiKey = apiKey;
        }

        public static void Push(Observation observation, Observation glue)
        {
            try
            {
                if (observation != null && IsInitialized)
                {
                    observation.ApiKey = _apiKey;
                    AddToQueue(JsonConvert.SerializeObject(observation));
                }
            }
            catch
            {
            }
        }
        private static void AddToQueue(string json)
        {
            var bytes = Encoding.ASCII.GetBytes(json);
            using (var fw = File.Create(@"c:\temp\observations\observation_" + DateTime.Now.Ticks))
            {
                fw.Write(Encoding.ASCII.GetBytes(json), 0, bytes.Length);
            }
            using (var fw = File.AppendText(@"c:\temp\observations\rolling.txt"))
            {
                fw.Write(json + Environment.NewLine);
            } 
        }

        public static void PushFor(string key, Observation glue)
        {
            if (RegisterInstance.For(key) == null) return;
            foreach (var observer in RegisterInstance.For(key))
            {
                foreach (var observation in observer.GetObservations())
                {
                    Push(observation, glue);
                }
            }
        }

        public static void RegisterType(ObservationType type)
        {
            AddToQueue(JsonConvert.SerializeObject(type));
        }

        public static void Register(Observer observer, params string[] keys)
        {
            RegisterInstance.Add(observer, keys);
        }

        public static void RegisterDefaults(params DefaultObservation[] defaultObs)
        {
            foreach (var defaultOb in defaultObs)
            {
                switch (defaultOb)
                {
                    case DefaultObservation.WindowsCore:
                        RegisterType(new CpuMeasurementType());
                        RegisterType(new AvaliableRAMType());
                        Register(new CpuObserver(), new[] { RegKeys.PER_MVC_ACTION_REQUEST});
                        Register(new RamObserver(), new[] { RegKeys.PER_MVC_ACTION_REQUEST });
                        break;
                    case DefaultObservation.MVC:
                        RegisterType(new ControllerTimeType());
                        break;
                }
            }
        }

        public static IList<Observer> Registrations(string key)
        {
            return RegisterInstance.For(key);
        }
    }
}