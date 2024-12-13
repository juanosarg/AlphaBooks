
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_RandomInspiration : BookOutcomeDoer
    {

        private static readonly SimpleCurve MoodByQuality = new SimpleCurve
    {
        new CurvePoint(0f, -5f),
        new CurvePoint(1f, -2f),
        new CurvePoint(2f, 1f),
        new CurvePoint(3f, 5f),
        new CurvePoint(4f, 10f),
        new CurvePoint(5f, 12f),
        new CurvePoint(6f, 15f)
    };

        public new BookOutcomeProperties_RandomInspiration Props => (BookOutcomeProperties_RandomInspiration)props;

      

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
       
        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_RandomInspiration".Translate()+" "+ "ABooks_ExtraMood".Translate(MoodByQuality.Evaluate((int)base.Quality),120000.ToStringTicksToPeriod());
        }

      

    }
}