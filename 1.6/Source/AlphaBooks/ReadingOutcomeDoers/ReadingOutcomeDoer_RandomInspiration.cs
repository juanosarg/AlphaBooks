
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_RandomInspiration : BookOutcomeDoer
    {

   

        public new BookOutcomeProperties_RandomInspiration Props => (BookOutcomeProperties_RandomInspiration)props;

      

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
       
        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_RandomInspiration".Translate();
        }

      

    }
}