


using RimWorld;
using UnityEngine;
using UnityEngine.XR;
using Verse;

namespace AlphaBooks
{
    public class HediffComp_AddCondiment : HediffComp
    {
        public ThingDef condimentDef;

        public HediffCompProperties_AddCondiment Props => (HediffCompProperties_AddCondiment)props;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Defs.Look(ref condimentDef, "condimentDef");

        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            Pawn pawn = this.parent.pawn;
            if (pawn.IsHashIntervalTick(2000) && condimentDef != null)
            {
                StaticCollections.AddPawnAndCondimentToList(this.parent.pawn, condimentDef);
            }
        }


        public override void CompPostPostAdd(DamageInfo? dinfo)
        {
            if (condimentDef != null)
            {
                StaticCollections.AddPawnAndCondimentToList(this.parent.pawn, condimentDef);

            }

        }

        public override void CompPostPostRemoved()
        {
            StaticCollections.RemovePawnAndCondimentFromList(this.parent.pawn);

        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            StaticCollections.RemovePawnAndCondimentFromList(this.parent.pawn);

        }

        public override void Notify_PawnKilled()
        {
            StaticCollections.RemovePawnAndCondimentFromList(this.parent.pawn);

        }

        public override string CompLabelInBracketsExtra
        {
            get
            {
                if (condimentDef != null)
                {
                    return condimentDef.LabelCap;
                }

                return "";

            }
        }


    }
}