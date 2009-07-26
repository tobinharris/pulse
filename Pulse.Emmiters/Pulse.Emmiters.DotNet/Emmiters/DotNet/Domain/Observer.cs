using System.Collections.Generic;

namespace Pulse.Emmiters.DotNet.Domain
{
    public abstract class Observer
    {
        public ObserverContext Context { get; set; }


        public virtual bool CanRegister
        {
            get { return true; }
        }

        public abstract void RegisterTypes();

        public abstract IList<Observation> GetObservations();

        public IList<observationT> GetObservations<observationT>() where observationT : Observation
        {
            return (IList<observationT>) GetObservations();
        }

        public IList<Observation> GetObservations(Observation parentObservation)
        {
            IList<Observation> observations = GetObservations();
            foreach (Observation observation in GetObservations())
            {
                observation.ParentObservation = parentObservation;
            }
            return observations;
        }

        public IList<observationT> GetObservations<observationT>(Observation parentObservation) where observationT : Observation
        {
            return (IList<observationT>)GetObservations(parentObservation);
        }
    }
}