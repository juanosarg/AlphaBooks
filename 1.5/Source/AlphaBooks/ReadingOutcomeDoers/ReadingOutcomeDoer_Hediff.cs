﻿
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_Hediff : BookOutcomeDoer
    {

     

        public new BookOutcomeProperties_Hediff Props => (BookOutcomeProperties_Hediff)props;

      
        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
       
        public override string GetBenefitsString(Pawn reader = null)
        {
            if (Props.ticks != 0)
            {
                return "ABooks_Hediff".Translate(Props.descriptionForStages[(int)CompQuality.qualityInt], Props.ticks.ToStringTicksToPeriod());

            }
            else
            {
                return "ABooks_HediffNoTime".Translate(Props.descriptionForStages[(int)CompQuality.qualityInt]);
            }
        }

       

    }
}