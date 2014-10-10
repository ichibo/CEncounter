using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class Ship
    {
        public PlayerColor Color
        {
            get;
            private set;
        }

        private Ship() { }

        public Ship(PlayerColor color)
        {
            Color = color;
        }
    }
}
