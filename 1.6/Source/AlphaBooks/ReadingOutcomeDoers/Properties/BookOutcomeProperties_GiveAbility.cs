using RimWorld;
using System;
using System.Collections.Generic;
namespace AlphaBooks
{
    public class BookOutcomeProperties_GiveAbility : BookOutcomeProperties
    {
        public List<AbilityDef> abilitiesToGive;
        public bool charges = false;
        public List<int> chargesByQuality;
        public bool propagateRulesForTitle = true;

        public override Type DoerClass => typeof(ReadingOutcomeDoer_GiveAbility);
    }
}