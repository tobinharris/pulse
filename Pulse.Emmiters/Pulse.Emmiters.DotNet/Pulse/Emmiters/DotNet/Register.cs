using System.Collections.Generic;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet
{
    public class Register
    {
        private readonly Dictionary<string, IList<Observer>> _registrations = new Dictionary<string, IList<Observer>>();

        public Register Add(Observer observer, params string[] keys)
        {
            foreach (string key in keys)
            {
                if (!_registrations.ContainsKey(key))
                {
                    var observations = new List<Observer> {observer};
                    _registrations.Add(key, observations);
                }
                else if (!_registrations[key].Contains(observer))
                {
                    _registrations[key].Add(observer);
                }
            }
            return this;
        }

        public IList<Observer> For(string key)
        {
            return (!_registrations.ContainsKey(key) ? null : _registrations[key]);
        }
    }
}