using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;
using System.Linq;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Biome : BookOutcomeDoer
    {
        public new BookOutcomeProperties_Biome Props => (BookOutcomeProperties_Biome)props;

        public new Book_Biome Book => (Book_Biome)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {
            Book.biome = DefDatabase<BiomeDef>.AllDefsListForReading.Where(x => x.generatesNaturally && !x.impassable).RandomElement();
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_Biome".Translate(Book.biome.LabelCap);
        }

        public override IEnumerable<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings = new List<string> { "subject->" + Book.biome.LabelCap };
            return new List<RulePack> { rulepack };
        }

    }
}