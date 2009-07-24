using System.Collections.Generic;

namespace Pulse.Emmiters.DotNet.Domain
{
    public abstract class Observer
    {
        protected Observer()
        {
        }

        public virtual bool CanRegister
        {
            get { return true; }
        }

        public abstract IList<Observation> GetObservations();

        public IList<observationT> GetObservations<observationT>() where observationT : Observation
        {
            return (IList<observationT>) GetObservations();
        }

        public IList<Observation> GetObservations(Observation glue)
        {
            IList<Observation> observations = GetObservations();
            foreach (Observation observation in GetObservations())
            {
                observation.Glue = glue;
            }
            return observations;
        }

        public IList<observationT> GetObservations<observationT>(Observation glue) where observationT : Observation
        {
            return (IList<observationT>) GetObservations(glue);
        }
    }
}