using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class GameManager
    {
        private List<BasePlayer> _players;
        private List<PlayerInfo> _playerInfos;
        private Void _void;
        private DestinyDeck _destinyDeck;
        private DestinyDeck _destinyDiscard;
        private List<Ship> _ships;
        private List<Planet> _planets;
        private SetupManager _setupManager;

        private const int DestinyCardsPerPlayer = 3;

        public GameManager()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            _players = new List<BasePlayer>();
            _playerInfos = new List<PlayerInfo>();
            _void = new Void();
            _destinyDeck = new DestinyDeck();
            _destinyDiscard = new DestinyDeck();
            _ships = new List<Ship>();
            _planets = new List<Planet>();
            _setupManager = new SetupManager();
        }

        public void StartGame()
        {
            if (_setupManager.PlayerCount == 0) throw new Exception("No players .....");

            _setupManager.PrepareGame();

            /*GenerateShips();
            GenerateEncounterDeck();
            GenerateDestinyDeck();
             Pull items from _setupManager and set up lists here.
             */
        }

        public void GenerateEncounterDeck()
        {

        }

        public void AddPlayer(PlayerInfo player)
        {
            _setupManager.AddPlayer(player);
        }

        private void GenerateDestinyDeck()
        {
            // 2 wilds 1 void 1 foreign colonies 3/player
            foreach (BasePlayer player in _players)
            {
                for (int i = 0; i < DestinyCardsPerPlayer; i++)
                {
                    _destinyDeck.Add(new PlayerColorDestinyCard(player));
                }
            }

            _destinyDeck.Add(new WildDestinyCard(_players));
            _destinyDeck.Add(new WildDestinyCard(_players));

            _destinyDeck.Add(new FewestShipsInVoidDestinyCard(_void, _players));
        }

        private void GenerateShips()
        {
            foreach (BasePlayer player in _players)
            {
                for (int i = 0; i < 20; i++)
                {
                    Ship ship = new Ship(player.Color);
                    _ships.Add(ship);
                }
            }
        }

        // This is generic because the compiler can't handle BaseDeck<BaseCard> as an argument even if it follows 
        // what should be a proper inheritance.
        private void ShuffleDecksTogether<T>(BaseDeck<T> deckOne, BaseDeck<T> deckTwo)
        {
            // fire ShuffleIn event.
            
            foreach (T card in deckOne)
            {
                deckOne.Add(deckTwo.DrawCard());
            }
            
            deckOne.Shuffle();
        }

        private BaseDestinyCard DrawDestinyCard()
        {
            if (_destinyDeck.Count <= 0) 
            { 
                // fire DestinyDeckShuffle event.
                ShuffleDecksTogether(_destinyDeck, _destinyDiscard); 
            }

            BaseDestinyCard drawnCard = _destinyDeck.DrawCard();

            return drawnCard;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in _players) 
            {
                sb.AppendLine(String.Format("Player: Name - {0}, Color - {1}", player.Name, player.Color));
            }
            foreach (var destinyCard in _destinyDeck) 
            {
                sb.AppendLine(String.Format("Destiny Card: Front - {0}, Back - {1}", destinyCard.FrontText,destinyCard.BackText));
            }
            foreach (var ship in _ships) 
            {
                sb.AppendLine(String.Format("Ship: Owner - {0}", ship.Color));
            }

            return sb.ToString();
        }
    }
}
