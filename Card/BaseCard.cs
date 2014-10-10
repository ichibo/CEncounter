using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public abstract class BaseCard
    {
        private const string DefaultBackText = "Cosmic Encounter Card";
        public abstract string FrontText
        {
            get;
        }

        public virtual string BackText
        {
            get { return DefaultBackText; }
        }

        public const bool CanBeCardZapped = false;
        public const bool DiscardOnUse = true;
    }
}
