using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class TriplerFlareCard : BaseFlareCard
    {
        public override string FlareCardSuperText
        {
            get { return "As a main player, after your opponent reveals an attack card of 15 or higher, you may divide that attack card’s value by 3 (rounded up) before any other effects are applied."; }
        }

        public override ActivationContext FlareActivationContext
        {
            get { return ActivationContext.EncounterCardRevealed; }
        }

        public override string FlareCardWildText
        {
            get { return "When you use your power, you may triple the value of any attacks cards that are 13 or less instead of 10 or less."; }
        }

        public override ActivationContext SuperActivationContext
        {
            get { return ActivationContext.EncounterCardRevealed; }
        }
            
    }
}
