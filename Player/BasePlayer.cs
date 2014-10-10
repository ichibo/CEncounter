using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CosmicEncounter
{
    public abstract class BasePlayer
    {
        private PlayerInfo _playerInfo;
        private List<Planet> _planets;
        private List<Ship> _ships;
        private Hand _hand;

        private BasePlayer() { }

        public BasePlayer(PlayerInfo info, IEnumerable<Ship> ships, IEnumerable<Planet> planets, BaseRace race)
        {
            _playerInfo = info;
            _ships = new List<Ship>(ships);
            _planets = new List<Planet>(planets);
            _hand = new Hand();
            AlienRace = race;
        }

        public IEnumerable<Planet> HomePlanets
        {
            get { return _planets as IEnumerable<Planet>; }
        }

        public PlayerColor Color
        {
            get { return _playerInfo.Color; }
        }

        public string Name
        {
            get { return _playerInfo.Name; }
        }

        public BaseRace AlienRace
        {
            get;
            private set;
        }

        public virtual bool RacePowerEnabled
        {
            get
            {
                if (HomeColoniesControlled() >= AlienRace.RequiredColoniesForPower) return true;
                else return false;
            }
        }

        public bool AskInvokeFlare(BaseFlareCard flareCard, bool isSuperFlare)
        {
            string FlarePrompt;

            if (isSuperFlare) FlarePrompt = flareCard.FlareCardSuperPrompt;
            else FlarePrompt = flareCard.FlareCardWildPrompt;
            

            DialogResult dialogResult = MessageBox.Show(FlarePrompt, "Invoke Flare Card?", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes) return true;
            else return false;
        }

        public int HomeColoniesControlled()
        {
            int count = 0;

            foreach (Planet p in _planets)
            {
                if (p.ContainsShipFromPlayer(this)) count++;
            }

            return count;
        }

        public int ForeignColoniesControlledInPlanets(IEnumerable<Planet> planets)
        {
            int count = 0;

            foreach (Planet p in planets)
            {
                if (p.Color == Color) continue;
                if (p.ContainsShipFromPlayer(this)) count++;
            }

            return count;
        }

        public void AddCardToHand(BaseCard card)
        {
            _hand.AddCard(card);
        }

        ///<summary>
        ///Determines a player's basic encounter contribution.
        ///</summary>
        ///<param name="encounter">The current encounter.</param>
        ///<returns>Player's attack contribution.</returns>
        public virtual int GetEncounterPowerContribution(Encounter encounter)
        {
            EncounterPlayerContext context = encounter.GetPlayerContext(this);

            if (RacePowerEnabled)
            {
                return AlienRace.GetEncounterPowerContribution(this, encounter, context);
            }
            else
            {
                return context.ShipCount;
            } 
        }

        public T FindCardInHand<T>(Type targetType) where T : class
        {

            if( !typeof(BaseCard).IsAssignableFrom(targetType) ) throw new Exception("Using FindCardInHand with non-Card type.");

            foreach (BaseCard card in _hand.Cards)
            {
                if (targetType.IsAssignableFrom(card.GetType())) return card as T;
            }

            return null;
        }

        public bool HandContainsAnyCardsOfType(Type targetType)
        {
            foreach (BaseCard card in _hand.Cards)
            {
                if (targetType.IsAssignableFrom(card.GetType())) return true;
            }

            return false;
        }
    }
}
