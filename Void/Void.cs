using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class Void
    {
        private List<Ship> _ships = new List<Ship>();

        public Void()
        {
        }

        public int GetShipCountOfPlayer(BasePlayer player)
        {
            int count = 0;

            foreach (Ship ship in _ships)
            {
                if (ship.Color == player.Color) count++;
            }

            return count;
        }

        public int TotalShips
        {
            get { return _ships.Count; }
        }
    }
}
