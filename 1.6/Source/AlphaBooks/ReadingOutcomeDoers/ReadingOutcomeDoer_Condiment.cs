using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;
using System.Linq;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Condiment : BookOutcomeDoer
    {
        public new BookOutcomeProperties_Condiment Props => (BookOutcomeProperties_Condiment)props;

        public new Book_Condiment Book => (Book_Condiment)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {
            Book.condiment = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.thingCategories?.Contains(InternalDefOf.VCE_Condiments)==true
            && x != InternalDefOf.VCE_DigestibleResurrectorNanites).RandomElement();
        }


        public override IEnumerable<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings = new List<string> { "subject->" + Book.condiment.label };
            return new List<RulePack> { rulepack };
        }

    }
}