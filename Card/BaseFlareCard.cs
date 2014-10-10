using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseFlareCard : BaseCard
    {
        public abstract string FlareCardWildText { get; }
        public abstract string FlareCardSuperText { get; }

        public abstract ActivationContext SuperActivationContext { get; }
        public abstract ActivationContext FlareActivationContext { get; }

        // public abstract ActivationEvent ActivationEvent

        public override string FrontText
        {
            get { return String.Format("Wild{0} \n\n Flare{1}", FlareCardWildText, FlareCardSuperText); }
        }
    }
}
