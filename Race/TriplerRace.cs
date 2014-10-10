using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class TriplerRace : BaseRace
    {
        public TriplerRace() {}

        private const int BaseMaximumTripleValue = 10;
        private const int FlareMaximumTripleValue = 13;

        public override string Name { get { return "The Tripler"; } }
        public override string PowerText { get { return "Attack cards 10 and under half their value tripled.  Cards 10 and over have their value divided by 3, rounded up."; } }
        public override string FlavorText { get { return "Wark wark I'm a crab man, catch me if you can."; } }
        public override bool PowerMandatory { get { return true; } }
        public override string FlareSuperText { get { return "Your triple power now works on Attack cards 13 and lower."; } }
        public override string FlareWildText { get { return "You're a crab now, what'choo gonna do foo."; } }

        public override int GetEncounterPowerContribution(BasePlayer player, Encounter encounter, EncounterPlayerContext context)
        {
            int contribution = 0;

            contribution += context.ShipCount;

            AttackEncounterCard attackCard = context.EncounterCard as AttackEncounterCard;

            if (attackCard != null)
            {
                contribution += GetTriplerAttackValue(player, encounter, attackCard);
            }

            return contribution;
        }

        private int GetTriplerAttackValue(BasePlayer player, Encounter encounter, AttackEncounterCard attackCard)
        {
            int finalAttackValue = 0;
            int tripleCardMaximum = BaseMaximumTripleValue;

            TriplerFlareCard flareCard = player.FindCardInHand<TriplerFlareCard>(typeof(TriplerFlareCard));

            /*if (flareCard && encounter.PlayerCanUseFlare(player))
            {
                if (player.AskInvokeFlare(flareCard, true))
                {
                    encounter.SetFlareUsedByPlayer(flareCard, player);
                    tripleCardMaximum = FlareMaximumTripleValue;
                }
            }

            if (attackCard.Value <= tripleCardMaximum)
            {
                finalAttackValue = attackCard.Value * 3;
            }

            else
            {
                finalAttackValue = (int)Math.Ceiling((double)attackCard.Value / 3);
            }*/

            return finalAttackValue;
        }
    }
}
