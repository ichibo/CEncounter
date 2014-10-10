using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class FewestShipsInVoidDestinyCard : BaseDestinyCard
    {
        private Void theVoid;
        private List<BasePlayer> playerList;

        private FewestShipsInVoidDestinyCard() { }
        public FewestShipsInVoidDestinyCard(Void theVoid, List<BasePlayer> playerList)
        {
            this.theVoid = theVoid;
            this.playerList = playerList;
            if (playerList.Count == 0) throw new Exception();
        }

        public override string FrontText
        {
            get
            {
                return "Target the player with the fewest ships in the Void.";
            }
        }

        public override BasePlayer GetTargetedPlayer()
        {
            // Does not account for a tie.  Add list of tied players and create a picker.    
            // Should we explicitly order players by when they join, and assume earlier in the list is 'to the left''?
            BasePlayer lowestCountPlayer = null;

            int? lowestShipCount = null;

            foreach (BasePlayer p in playerList)
            {
                int shipCount = theVoid.GetShipCountOfPlayer(p);

                if (lowestShipCount == null || shipCount <= lowestShipCount)
                {
                    lowestShipCount = shipCount;
                    lowestCountPlayer = p;
                }
            }

            if (lowestCountPlayer == null) lowestCountPlayer = playerList.First();

            return lowestCountPlayer;
        }
    }
}
