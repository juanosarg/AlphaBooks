using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;
using System.Linq;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_GainPsycast : BookOutcomeDoer
    {

     

        public new BookOutcomeProperties_GainPsycast Props => (BookOutcomeProperties_GainPsycast)props;

        public new Book_Psycast Book => (Book_Psycast)base.Parent;

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        public override void OnBookGenerated(Pawn author = null)
        {
            Book.psycast = DefDatabase<AbilityDef>.AllDefsListForReading.Where(x => x.IsPsycast).RandomElement();
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
            return "ABooks_UnlockPsycast".Translate(Book.psycast.LabelCap, Book.psycast.level);
        }

        public override List<RulePack> GetTopicRulePacks()
        {
            RulePack rulepack = new RulePack();
            rulepack.rulesStrings = new List<string> { "subject->" + Book.psycast.LabelCap };
            return new List<RulePack> { rulepack };
        }

    }
}