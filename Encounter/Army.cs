using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class Army
    {
        public BaseEncounterCard EncounterCard
        {
            get;
            private set;
        }

        public CombatUnit MainCombatUnit
        {
            get;
            private set;
        }

        public BasePlayer MainPlayer
        {
            get { return MainCombatUnit.Owner; }
        }

        public IEnumerable<BasePlayer> AlliedPlayers
        {
            get
            {
                var players = new List<BasePlayer>();

                foreach (CombatUnit unit in _alliances)
                {
                    players.Add(unit.Owner);
                }

                return players as IEnumerable<BasePlayer>;
            }
        }

        private List<CombatUnit> _alliances = new List<CombatUnit>();

        public IEnumerable<CombatUnit> Alliances
        {
            get { return _alliances as IEnumerable<CombatUnit>; }
        }

        public void AddAlliance(CombatUnit alliance)
        {
            _alliances.Add(alliance);
        }

        public Army(CombatUnit mainCombatUnit)
        {
            MainCombatUnit = mainCombatUnit;
        }

        public IEnumerable<CombatUnit> CombatUnits
        {
            get
            {
                List<CombatUnit> units = new List<CombatUnit>(_alliances);
                units.Add(MainCombatUnit);

                return units;
            }
        }

        public int GetShipCountOfPlayer(BasePlayer player)
        {
            if (MainPlayer == player) return MainCombatUnit.Ships.Count();

            foreach (CombatUnit unit in _alliances)
            {
                if (unit.Owner == player)
                {
                    return unit.Ships.Count();
                }
            }

            return 0;
        }
    }
}
