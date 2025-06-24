
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_CallRaids : BookOutcomeDoer
    {

       

        public new BookOutcomeProperties_CallRaids Props => (BookOutcomeProperties_CallRaids)props;


        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }

        public override string GetBenefitsString(Pawn reader = null)
        {
           
            return "ABooks_CallRaids".Translate(Props.lengthForQualities[(int)CompQuality.qualityInt].ToString("0.##"));
            
        }



    }
}