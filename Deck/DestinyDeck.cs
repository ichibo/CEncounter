using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public class DestinyDeck : BaseDeck<BaseDestinyCard>
    {
        public DestinyDeck()
        {
        }

        public override BaseDestinyCard TopCard()
        {
            return this.First();
        }

        public override void AddCard(BaseDestinyCard destinyCard)
        {
            this.Add(destinyCard);
        }

        public override BaseDestinyCard DrawCard()
        {
            if (this.Count == 0) throw new Exception();

            BaseDestinyCard card = this.First();
            this.Remove(card);

            return card;
        }

        public override void Shuffle()
        {

        }
    }
}
