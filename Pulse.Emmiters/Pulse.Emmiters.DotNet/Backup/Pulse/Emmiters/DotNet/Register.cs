namespace Pulse.Emmiters.DotNet
{
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;

    public class Register
    {
        private readonly Dictionary<string, IList<Observer>> registrations = new Dictionary<string, IList<Observer>>();

        public Register Add(Observer observer, params string[] keys)
        {
            foreach (string key in keys)
            {
                if (!this.registrations.ContainsKey(key))
                {
                    List<Observer> <>g__initLocal0 = new List<Observer>();
                    <>g__initLocal0.Add(observer);
                    this.registrations.Add(key, <>g__initLocal0);
                }
                else if (!this.registrations[key].Contains(observer))
                {
                    this.registrations[key].Add(observer);
                }
            }
            return this;
        }

        public IList<Observer> For(string key)
        {
            return (!this.registrations.ContainsKey(key) ? null : this.registrations[key]);
        }
    }
}

