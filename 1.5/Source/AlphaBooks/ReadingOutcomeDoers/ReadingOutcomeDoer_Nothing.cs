
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Nothing : BookOutcomeDoer
    {



        public new BookOutcomeProperties_Nothing Props => (BookOutcomeProperties_Nothing)props;



        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_Nothing".Translate();
        }



    }
}