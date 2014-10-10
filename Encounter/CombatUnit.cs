using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public struct CombatUnit
    {
        public readonly BasePlayer Owner;
        public readonly IEnumerable<Ship> Ships;

        public CombatUnit(BasePlayer owner, IEnumerable<Ship> ships)
        {
            Owner = owner;
            Ships = ships;
        }
    }
}
