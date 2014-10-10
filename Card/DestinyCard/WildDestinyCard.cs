using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class WildDestinyCard : BaseDestinyCard
    {
        private List<BasePlayer> _players;

        private WildDestinyCard() { }
        public WildDestinyCard(List<BasePlayer> players)
        {
            _players = players;
        }

        public override string FrontText
        {
            get
            {
                return "Wild - Target the player of your choice.";
            }
        }

        public override BasePlayer GetTargetedPlayer()
        {
            // Allow selection from any in list aside from self
            return _players.First();
        }
    }
}
