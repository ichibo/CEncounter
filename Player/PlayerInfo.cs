using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class PlayerInfo
    {
        public PlayerColor Color
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public PlayerInfo(PlayerColor color, string name)
        {
            Color = color;
            Name = name;
        }
    }
}
