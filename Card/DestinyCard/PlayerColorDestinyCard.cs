using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class PlayerColorDestinyCard : BaseDestinyCard
    {
        private BasePlayer targetedPlayer;

        private PlayerColorDestinyCard() { }
        public PlayerColorDestinyCard(BasePlayer targetedPlayer)
        {
            this.targetedPlayer = targetedPlayer;
        }

        public override string FrontText
        {
            get
            {
                return "Target the " + targetedPlayer.Color + " player.";
            }
        }

        public override BasePlayer GetTargetedPlayer()
        {
            return targetedPlayer;
        }
    }
}
