
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_ThoughtByQuality : BookOutcomeDoer
    {

        public new BookOutcomeProperties_ThoughtByQuality Props => (BookOutcomeProperties_ThoughtByQuality)props;

        public SimpleCurve MoodByQuality()
        {
            SimpleCurve curve = new SimpleCurve();

            curve.Add(new CurvePoint(0f, Props.moodByQuality[0]));
            curve.Add(new CurvePoint(1f, Props.moodByQuality[1]));
            curve.Add(new CurvePoint(2f, Props.moodByQuality[2]));
            curve.Add(new CurvePoint(3f, Props.moodByQuality[3]));
            curve.Add(new CurvePoint(4f, Props.moodByQuality[4]));
            curve.Add(new CurvePoint(5f, Props.moodByQuality[5]));
            curve.Add(new CurvePoint(6f, Props.moodByQuality[6]));
            return curve;
        } 

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_ExtraMood".Translate(MoodByQuality().Evaluate((int)base.Quality), Props.ticks.ToStringTicksToPeriod());
        }



    }
}