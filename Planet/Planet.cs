using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class Planet
    {
        private List<Ship> _ships = new List<Ship>();
        public PlayerColor Color
        {
            get;
            private set;
        }

        public IEnumerable<Ship> Ships
        {
            get { return _ships as IEnumerable<Ship>; }
        }

        public Planet(PlayerColor color) 
        {
            Color = color;
        }

        #region Ship Maintenance
        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
        }

        public void AddShip(IEnumerable<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                AddShip(ship);
            }
        }

        public void RemoveShip(Ship ship)
        {
            if (!_ships.Contains(ship)) throw new Exception("Ship isn't on this planet");

            _ships.Remove(ship);
        }

        public void RemoveShip(IEnumerable<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                RemoveShip(ship);
            }
        }
        #endregion

        public bool ContainsShipFromPlayer(BasePlayer player)
        {
            return ContainsShipOfColor(player.Color);
        }

        public bool ContainsShipOfColor(PlayerColor color)
        {
            foreach (Ship ship in _ships)
            {
                if (ship.Color == color) return true;
            }

            return false;
        }
    }
}
