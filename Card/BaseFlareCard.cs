using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseFlareCard : BaseCard
    {
        public string FlareCardWildPrompt;
        public string FlareCardSuperPrompt;

        public override string FrontText
        {
            get { return String.Format("Wild{0} \n Flare{1}", FlareCardWildPrompt, FlareCardSuperPrompt); }
        }
    }
}
