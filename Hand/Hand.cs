using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    class Hand
    {
        private List<BaseCard> _cards = new List<BaseCard>();

        public Hand() { }

        public void AddCard(BaseCard card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(BaseCard card)
        {
            _cards.Remove(card);
        }

        public IEnumerable<BaseCard> Cards
        {
            get { return _cards as IEnumerable<BaseCard>; }
        }
    }
}
