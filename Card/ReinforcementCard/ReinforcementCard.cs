using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class ReinforcementCard : BaseCard
    {
        public override string FrontText
        {
            get
            {
                string sign = "";
                if (Value > 0) sign = "+";
                return String.Format("Reinforcement: {0}{1}", sign, Value);
            }
        }

        public int Value
        {
            get;
            private set;
        }

        public ReinforcementCard(int value)
        {
            Value = value;
        }
    }
}