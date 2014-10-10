using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class SetupManager
    {
        private List<PlayerInfo> _playerInfos;
        private readonly SetupManagerSettings _settings;
       
        public SetupManager() : this(new SetupManagerSettings())
        {
            
        }

        public SetupManager(SetupManagerSettings settings)
        {
            _playerInfos = new List<PlayerInfo>();
        }

        public void AddPlayer(PlayerInfo playerinfo)
        {
            _playerInfos.Add(playerinfo);
        }

        public int PlayerCount
        {
            get { return _playerInfos.Count; }
        }

        public void PrepareGame()
        {
            // Generate all Ships/Planets/Decks etc that need to be created.
            // Run off of default SetupManagerSettings for everything created.
        }
    }
}
