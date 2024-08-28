
using RimWorld;
using Verse;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Alpha : BookOutcomeDoer
    {

        public new BookOutcomeProperties_Alpha Props => (BookOutcomeProperties_Alpha)props;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

      
    }
}