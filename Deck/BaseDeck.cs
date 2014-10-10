using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseDeck<T> : List<T>
    {
        public abstract T DrawCard();
        public abstract void Shuffle();
        public abstract T TopCard();
        public abstract void AddCard(T card);
    }
}
