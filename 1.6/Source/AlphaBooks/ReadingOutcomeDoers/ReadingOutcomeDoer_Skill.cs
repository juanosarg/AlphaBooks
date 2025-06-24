
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Skill : BookOutcomeDoer
    {

        private static readonly SimpleCurve MultiplierByQuality = new SimpleCurve
    {
        new CurvePoint(0f, 1.1f),
        new CurvePoint(1f, 1.15f),
        new CurvePoint(2f, 1.3f),
        new CurvePoint(3f, 1.5f),
        new CurvePoint(4f, 1.65f),
        new CurvePoint(5f, 1.85f),
        new CurvePoint(6f, 2f)
    };

        public new BookOutcomeProperties_Skill Props => (BookOutcomeProperties_Skill)props;

        public new Book_Skill Book => (Book_Skill)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {         
            Book.skill = DefDatabase<SkillDef>.AllDefsListForReading.RandomElement();
        }
        public override string GetBenefitsString(Pawn reader = null)
        {
            return string.Format(" - {0}: {1}, x{2} {3}", "ABooks_SkillLearnFactor".Translate(), Book.skill.LabelCap, MultiplierByQuality.Evaluate((int)base.Quality), "ABooks_ForXDays".Translate(3));
        }

        public override IEnumerable<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings = new List<string> { "subject->" + Book.skill.LabelCap };
            return new List<RulePack> { rulepack };
        }

    }
}