using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class MorphEncounterCard : BaseEncounterCard
    {
        public MorphEncounterCard() { }
        public override string FrontText
        {
            get { return "Morph - Takes value of opposing card"; }
        }
    }
}
