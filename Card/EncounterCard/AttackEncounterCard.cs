using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class AttackEncounterCard : BaseEncounterCard
    {
        public int Value
        {
            get;
            private set;
        }

        private AttackEncounterCard() { }

        public AttackEncounterCard(int value)
        {
            Value = value;
        }

        public override string  FrontText
        {
            get { return String.Format("Attack - {0}", Value); }
        }
    }
}
