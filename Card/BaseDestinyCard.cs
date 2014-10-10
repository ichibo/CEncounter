using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseDestinyCard : BaseCard
    {
        public abstract BasePlayer GetTargetedPlayer();

        public override string BackText
        {
            get
            {
                return "A Destiny Card";
            }
        }
    }
}
