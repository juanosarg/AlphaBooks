
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Text : BookOutcomeDoer
    {



        public new BookOutcomeProperties_Text Props => (BookOutcomeProperties_Text)props;



        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return Props.text.Translate();
        }



    }
}