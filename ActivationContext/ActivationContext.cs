using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmicEncounter
{
    public enum ActivationContext
    {
        None,
        DesintyCardDrawn,
        EncounterPlanetSelected,
        AlliancesOffered,
        AlliancesSelected,
        EncounterCardSelected,
        EncounterCardRevealed, // Before victors are selected or powers are computed.
        EncounterOutcomeDetermined, // Winner/Loser determined
        EncounterCompensationStart,
        EncounterPlanetColonized,
        EncounterLoserShipsToVoid,
    }
}
