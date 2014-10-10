using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class NegotiateEncounterCard : BaseEncounterCard
    {
        public const int CompensationPerLostShip = 1;
        public const int CompensationBonus = 0;
        public const int PenaltyForFailedDealSelf = 3;
        public const int PenaltyForFailedDealOpponent = 3;

        public NegotiateEncounterCard() { }
        public override string FrontText
        {
            get { return "Negotiate"; }
        }
    }
}
