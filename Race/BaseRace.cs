using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseRace
    {
        public virtual int RequiredColoniesForPower { get { return 3; } }
        public virtual int StartingShips { get { return 20; } }
        public virtual int MaxShipsForOffense { get { return 4; } }
        public virtual int MaxShipsForAlliance { get { return 4; } }

        public abstract string Name { get; }
        public abstract string PowerText { get; }
        public abstract string FlavorText { get; }
        public abstract bool PowerMandatory { get; }
        public abstract string FlareSuperText { get; }
        public abstract string FlareWildText { get; }

        /*
         * public static abstract PowerTriggerPoint RaceAbilityTriggerPoint;
        public static abstract PowerTriggerPoint FlareSuperTriggerPoint;
        public static abstract PowerTriggerPoint FlareWildTriggerPoint;
         */

        //public GamePhase ValidPhasesForPower;

        public virtual int GetEncounterPowerContribution(BasePlayer player, Encounter encounter, EncounterPlayerContext context)
        {
            int contribution = 0;

            //EncounterPlayerContext context = encounter.GetPlayerContext(player);

            contribution += context.ShipCount;

            if (context.EncounterCard is AttackEncounterCard)
            {
                contribution += ((AttackEncounterCard)context.EncounterCard).Value;
            }

            return contribution;
        }
    }
}