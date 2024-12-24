


using RimWorld;
using UnityEngine;
using UnityEngine.XR;
using Verse;

namespace AlphaBooks
{
    public class HediffComp_AddBiome : HediffComp
    {
        public BiomeDef biomeDef;

        public HediffCompProperties_AddBiome Props => (HediffCompProperties_AddBiome)props;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Defs.Look(ref biomeDef, "biomeDef");

        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            Pawn pawn = this.parent.pawn;
            if (pawn.IsHashIntervalTick(200) && biomeDef!=null)
            {
                StaticCollections.AddPawnAndBiomeToList(this.parent.pawn, biomeDef);
            }
        }


        public override void CompPostPostAdd(DamageInfo? dinfo)
        {
            if(biomeDef != null)
            {
                StaticCollections.AddPawnAndBiomeToList(this.parent.pawn, biomeDef);

            }

        }

        public override void CompPostPostRemoved()
        {
            StaticCollections.RemovePawnAndBiomeFromList(this.parent.pawn);

        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            StaticCollections.RemovePawnAndBiomeFromList(this.parent.pawn);

        }

        public override void Notify_PawnKilled()
        {
            StaticCollections.RemovePawnAndBiomeFromList(this.parent.pawn);

        }

        public override string CompLabelInBracketsExtra
        {
            get {
                if (biomeDef != null)
                {
                    return biomeDef.LabelCap;
                }    
                
                return ""; 
            
            }
        }


    }
}