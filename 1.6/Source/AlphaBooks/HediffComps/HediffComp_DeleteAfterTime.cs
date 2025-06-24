using System.Collections.Generic;
using System;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI.Group;




namespace AlphaBooks
{
    public class HediffComp_DeleteAfterTime : HediffComp
    {

        public HediffCompProperties_DeleteAfterTime Props => (HediffCompProperties_DeleteAfterTime)props;

        public int timer;

        public int ticksByQuality = 0;

        public override void CompExposeData()
        {
            Scribe_Values.Look(ref timer, "timer", 0);
            Scribe_Values.Look(ref ticksByQuality, "ticksByQuality", 0);
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            timer++;

            if (Props.scaleTicksPerQuality)
            {
                if(ticksByQuality == 0)
                {
                    if (this.parent.Severity <= 0.06f)
                    {
                        ticksByQuality = Props.ticksAwful;
                    }else if (this.parent.Severity == 0.16f)
                    {
                        ticksByQuality = Props.ticksPoor;
                    }
                    else
                    if (this.parent.Severity <= 0.26f)
                    {
                        ticksByQuality = Props.ticksNormal;
                    }
                    else
                    if (this.parent.Severity <= 0.36f)
                    {
                        ticksByQuality = Props.ticksGood;
                    }
                    else
                    if (this.parent.Severity <= 0.46f)
                    {
                        ticksByQuality = Props.ticksExcellent;
                    }
                    else
                    if (this.parent.Severity <= 0.56f)
                    {
                        ticksByQuality = Props.ticksMasterwork;
                    }
                    else
                    
                        ticksByQuality = Props.ticksLegendary;
                    

                }

                if (timer > ticksByQuality)
                {
                    this.parent.pawn.health.RemoveHediff(parent);
                }
            }
            else
            {
                if (timer > Props.disappearsAfterTicks)
                {
                    this.parent.pawn.health.RemoveHediff(parent);
                }
            }
            


        }



        public override string CompLabelInBracketsExtra
        {
            get
            {
                if (Props.scaleTicksPerQuality)
                {
                    return (ticksByQuality - timer).ToStringTicksToPeriod(allowSeconds: true, shortForm: true, canUseDecimals: true, allowYears: true, true);


                }
                else
                    return (Props.disappearsAfterTicks - timer).ToStringTicksToPeriod(allowSeconds: true, shortForm: true, canUseDecimals: true, allowYears: true, true);
            }
        }


    }
}
