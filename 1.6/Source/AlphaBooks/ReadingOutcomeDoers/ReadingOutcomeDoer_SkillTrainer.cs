
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_SkillTrainer : BookOutcomeDoer
    {

        public static readonly SimpleCurve PointsByQuality = new SimpleCurve
        {
            new CurvePoint(0f, 5000f),
            new CurvePoint(1f, 10000f),
            new CurvePoint(2f, 15000f),
            new CurvePoint(3f, 25000f),
            new CurvePoint(4f, 50000f),
            new CurvePoint(5f, 75000f),
            new CurvePoint(6f, 100000f)
        };

        public new BookOutcomeProperties_SkillTrainer Props => (BookOutcomeProperties_SkillTrainer)props;



        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_SkillTrainer".Translate(PointsByQuality.Evaluate((int)base.Quality));
        }



    }
}