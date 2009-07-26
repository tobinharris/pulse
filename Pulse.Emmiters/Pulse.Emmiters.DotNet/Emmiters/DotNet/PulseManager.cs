using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.Observers;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet
{
    public static class PulseManager
    {
        private static readonly Register RegisterInstance = new Register();
        private static string _apiKey = String.Empty;
        private static ISimpleQueue _queue;

        internal static bool IsInitialized
        {
            get { return _apiKey != String.Empty;  }
        }

        public static void Init(string apiKey, ISimpleQueue queueImpl)
        {
            _apiKey = apiKey;
            _queue = queueImpl;
            RegisterType(new ObservationType("Common.Custom.TimedAction", "Time taken for a custom action to occur", "Custom Action Time", "ms"));
        }

        public static void Push(Observation observation, Observation glue)
        {
            try
            {
                if (observation != null && IsInitialized)
                {
                    observation.ApiKey = _apiKey;
                    _queue.AddToQueue(JsonConvert.SerializeObject(observation));
                }
            }
            catch
            {
            }
        }

        public static void PushFor(string key, Observation glue, ObserverContext context)
        {
            if (RegisterInstance.For(key) == null) return;
            foreach (var observer in RegisterInstance.For(key))
            {
                observer.Context = context;
                foreach (var observation in observer.GetObservations(glue))
                {
                    Push(observation, glue);
                }
            }
        }

        public static void RegisterType(ObservationType type)
        {
            _queue.AddToQueue(JsonConvert.SerializeObject(type));
        }

        public static void Register(Observer observer, params string[] keys)
        {
            observer.RegisterTypes();
            RegisterInstance.Add(observer, keys);
        }

        public static void RegisterDefaults(params DefaultObservation[] defaultObs)
        {
            foreach (var defaultOb in defaultObs)
            {
                switch (defaultOb)
                {
                    case DefaultObservation.WindowsCore:
                        Register(new SysObserver(), new[] { RegKeys.PER_MVC_ACTION_REQUEST});
                        break;
                    case DefaultObservation.MVC:
                        RegisterType(new ObservationType("MVC.Controller.Time", "Time taken for a controller action to load", "Controller Time", "ms"));
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