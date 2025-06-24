
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Religious : BookOutcomeDoer
    {

     

        public new BookOutcomeProperties_Religious Props => (BookOutcomeProperties_Religious)props;

        public new Book_Religious Book => (Book_Religious)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {
            Book.structure = DefDatabase<MemeDef>.AllDefsListForReading.Where(x => x.category==MemeCategory.Structure).RandomElement();
        }
        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_ReligiousMoodImpact".Translate();
        }

        public override IEnumerable<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings =
            [
                "subject->" + (string)Book.structure.LabelCap
               
            ];
            
            return new List<RulePack> { rulepack };
        }

    }
}