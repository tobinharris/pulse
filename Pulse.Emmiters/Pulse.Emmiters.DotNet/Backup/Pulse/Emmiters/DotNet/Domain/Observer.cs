namespace Pulse.Emmiters.DotNet.Domain
{
    using System;
    using System.Collections.Generic;

    public abstract class Observer
    {
        protected Observer()
        {
        }

        public abstract IList<Observation> GetObservations();
        public IList<observationT> GetObservations<observationT>() where observationT: Observation
        {
            return (IList<observationT>) this.GetObservations();
        }

        public IList<Observation> GetObservations(Observation glue)
        {
            IList<Observation> observations = this.GetObservations();
            foreach (Observation observation in this.GetObservations())
            {
                observation.Glue = glue;
            }
            return observations;
        }

        public IList<observationT> GetObservations<observationT>(Observation glue) where observationT: Observation
        {
            return (IList<observationT>) this.GetObservations(glue);
        }

        public virtual bool CanRegister
        {
            get
            {
                return true;
            }
        }
    }
}

