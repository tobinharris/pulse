namespace Pulse.Emmiters.DotNet.Domain
{
    using System;
    using System.Collections.Generic;

    public class Event : Observation<Dictionary<string, object>>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Unit
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Dictionary<string, object> Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

