using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;
using System.Linq;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Plant : BookOutcomeDoer
    {
        public new BookOutcomeProperties_Plant Props => (BookOutcomeProperties_Plant)props;

        public new Book_Plant Book => (Book_Plant)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {
            Book.plant = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsPlant).RandomElement();
        }

       
        public override List<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings = new List<string> { "subject->" + Book.plant.label };
            return new List<RulePack> { rulepack };
        }

    }
}