
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_MapLocations : BookOutcomeDoer
    {

        public static readonly SimpleCurve LocationsByQuality = new SimpleCurve
        {
            new CurvePoint(0f, 1f),
            new CurvePoint(1f, 1f),
            new CurvePoint(2f, 1f),
            new CurvePoint(3f, 2f),
            new CurvePoint(4f, 2f),
            new CurvePoint(5f, 2f),
            new CurvePoint(6f, 3f)
        };

        public new BookOutcomeProperties_MapLocations Props => (BookOutcomeProperties_MapLocations)props;

      

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
       
        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_NewMapLocations".Translate(LocationsByQuality.Evaluate((int)base.Quality)); 
        }

        

    }
}