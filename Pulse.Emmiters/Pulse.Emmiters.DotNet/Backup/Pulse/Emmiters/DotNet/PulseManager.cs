namespace Pulse.Emmiters.DotNet
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Core.Observers;
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PulseManager
    {
        private static readonly Pulse.Emmiters.DotNet.Register registerInstance = new Pulse.Emmiters.DotNet.Register();

        public static void Push(Observation observation, Observation glue)
        {
            try
            {
                if (observation != null)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(observation));
                    using (FileStream fw = File.Create(@"c:\temp\observations\observation_" + DateTime.Now.Ticks))
                    {
                        fw.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(observation)), 0, bytes.Length);
                    }
                    using (StreamWriter fw = File.AppendText(@"c:\temp\observations\rolling.txt"))
                    {
                        fw.Write(JsonConvert.SerializeObject(observation) + Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void PushFor(string key, Observation glue)
        {
            if (registerInstance.For(key) != null)
            {
                foreach (Observer observer in registerInstance.For(key))
                {
                    foreach (Observation observation in observer.GetObservations())
                    {
                        Push(observation, glue);
                    }
                }
            }
        }

        public static void Register(Observer observer, params string[] keys)
        {
            registerInstance.Add(observer, keys);
        }

        public static void RegisterDefaults(params DefaultObservation[] defaultObs)
        {
            foreach (DefaultObservation defaultOb in defaultObs)
            {
                switch (defaultOb)
                {
                    case DefaultObservation.WindowsCore:
                    {
                        Register(new CPUObserver(), new string[] { "time_based" });
                        Register(new RamObserver(), new string[] { "time_based" });
                    }
                }
            }
        }

        public static IList<Observer> Registrations(string key)
        {
            return registerInstance.For(key);
        }
    }
}

