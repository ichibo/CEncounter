using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class HumanPlayer : BasePlayer
    {
        public HumanPlayer(PlayerInfo info, IEnumerable<Ship> ships, IEnumerable<Planet> planets, BaseRace race) 
            : base(info,ships,planets,race)
        {
        }
    }
}
