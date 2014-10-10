using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class Encounter
    {
        public Army Offense
        {
            get;
            private set;
        }

        public Army Defense
        {
            get;
            private set;
        }

        public IEnumerable<CombatUnit> OffensiveAllies
        {
            get
            {
                return Offense.Alliances;
            }
        }

        public IEnumerable<CombatUnit> DefensiveAllies
        {
            get
            {
                return Defense.Alliances;
            }
        }

        public Planet Planet
        {
            get;
            private set;
        }

        public Encounter(Army offense, Army defense, Planet planet)
        {
            Offense = offense;
            Defense = defense;
            Planet = planet;
        }

        public bool TryAddAlliance(CombatUnit alliance, EncounterSide side)
        {
            if (!ValidAlliance(alliance)) return false;

            if (side == EncounterSide.Defense)
            {
                Defense.AddAlliance(alliance);
                return true;
            }

            else if (side == EncounterSide.Offense)
            {
                Offense.AddAlliance(alliance);
                return true;
            }

            return false;
        }

        private bool ValidAlliance(CombatUnit unit)
        {
            foreach (Ship ship in unit.Ships)
            {
                if (ship.Color != unit.Owner.Color) return false;
            }

            if (PlayerAlreadyInAlliance(unit.Owner)) return false;

            // Fire ValidAlliance event for any racials.

            return true;
        }

        private bool PlayerAlreadyInAlliance(BasePlayer player)
        {
            foreach (CombatUnit alliance in OffensiveAllies)
            {
                if (player == alliance.Owner) return true;
            }

            foreach (CombatUnit alliance in DefensiveAllies)
            {
                if (player == alliance.Owner) return true;
            }

            return false;
        }

        public EncounterOutcome DetermineEncounterWinner()
        {
            //
            //
            return new EncounterOutcome(Outcome.Win,Outcome.Lose);
        }

        // public

        public class EncounterOutcome
        {
            public Outcome OffenseOutcome
            {
                get;
                private set;
            }

            public Outcome DefenseOutcome
            {
                get;
                private set;
            }

            //private EncounterOutcome() { }
            public EncounterOutcome(Outcome offenseOutcome, Outcome defenseOutcome)
            {
                OffenseOutcome = offenseOutcome;
                DefenseOutcome = defenseOutcome;
            }

            public void ReverseOutcomes()
            {
                DefenseOutcome = ReverseOutcome(DefenseOutcome);
                OffenseOutcome = ReverseOutcome(OffenseOutcome);
            }

            public Outcome ReverseOutcome(Outcome outcome)
            {
                if (outcome == Outcome.Lose) return Outcome.Win;
                else return Outcome.Lose;
            }

        }

        public enum Outcome
        {
            Win,
            Lose
        }

        public enum EncounterSide
        {
            Offense,
            Defense
        }

        public bool IsPlayerMainPlayer(BasePlayer player)
        {
            return player == Offense.MainPlayer || player == Defense.MainPlayer;
        }

        public bool IsPlayerAlly(BasePlayer player)
        {
            return IsPlayerOffensiveAlly(player) || IsPlayerDefensiveAlly(player);
        }

        public bool IsPlayerOffensiveAlly(BasePlayer player)
        {
            return Offense.AlliedPlayers.Contains(player);
        }

        public bool IsPlayerDefensiveAlly(BasePlayer player)
        {
            return Defense.AlliedPlayers.Contains(player);
        }

        public EncounterPlayerContext GetPlayerContext(BasePlayer player)
        {
            if (Offense.MainPlayer == player) return new EncounterPlayerContext(Offense.GetShipCountOfPlayer(player), EncounterInvolvementType.Main, Offense.EncounterCard);// Offense Main Player
            else if (Defense.MainPlayer == player) return new EncounterPlayerContext(Defense.GetShipCountOfPlayer(player), EncounterInvolvementType.Main, Defense.EncounterCard);// Defense Main Player
            else if (Offense.AlliedPlayers.Contains(player)) return new EncounterPlayerContext(Offense.GetShipCountOfPlayer(player), EncounterInvolvementType.Ally, null);
            else if (Defense.AlliedPlayers.Contains(player)) return new EncounterPlayerContext(Defense.GetShipCountOfPlayer(player), EncounterInvolvementType.Ally, null);
            else return new EncounterPlayerContext(0, EncounterInvolvementType.None,null);
        }
    }

    public enum EncounterInvolvementType
    {
        None,
        Ally,
        Main
    }

    public struct EncounterPlayerContext
    {
        public readonly EncounterInvolvementType Involvement;
        public readonly int ShipCount;
        public BaseEncounterCard EncounterCard;

        //private EncounterPlayerContext() { }
        public EncounterPlayerContext(int shipcount, EncounterInvolvementType involvement, BaseEncounterCard encounterCard)
        {
            ShipCount = shipcount;
            Involvement = involvement;
            EncounterCard = encounterCard;
        }
    }
}
