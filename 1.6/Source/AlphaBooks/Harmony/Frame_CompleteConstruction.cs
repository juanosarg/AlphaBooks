using HarmonyLib;
using RimWorld;

using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;
using AlphaBooks;



namespace AlphaBooks
{


    [HarmonyPatch(typeof(Frame))]
    [HarmonyPatch("CompleteConstruction")]
    public static class AlphaBooks_Frame_CompleteConstruction_Patch
    {
        public static Pawn crafter;

        [HarmonyPrefix]
        static void StoreCrafter(Pawn worker)
        {
            crafter = worker;

        }

        [HarmonyPostfix]
        static void RemoveCrafter()
        {
            crafter = null;

        }
    }

    [HarmonyPatch(typeof(ThingMaker))]
    [HarmonyPatch("MakeThing")]
    public static class AlphaBooks_ThingMaker_MakeThing_Patch
    {
      

        [HarmonyPostfix]
        static void HandleCraftModifications(ThingDef def, Thing __result)
        {
            if(AlphaBooks_Frame_CompleteConstruction_Patch.crafter?.health?.hediffSet.HasHediff(InternalDefOf.ABooks_InstructionManual) == true)
            {
                CompQuality compQuality = __result?.TryGetComp<CompQuality>();
                if (compQuality != null)
                {
                    if (compQuality.Quality != QualityCategory.Legendary)
                    {
                        compQuality.SetQuality(compQuality.Quality + 1, ArtGenerationContext.Colony);
                    }
                }
            }
            if (AlphaBooks_Frame_CompleteConstruction_Patch.crafter?.health?.hediffSet.HasHediff(InternalDefOf.ABooks_MidasTome) == true)
            {
                if (def.MadeFromStuff == true)
                {
                    __result.SetStuffDirect(ThingDefOf.Gold);
                }
            }
            if (AlphaBooks_Frame_CompleteConstruction_Patch.crafter?.health?.hediffSet.HasHediff(InternalDefOf.ABooks_TreatiseOfStainlessSteel) == true)
            {
                if (def.MadeFromStuff == true && __result.Stuff == ThingDefOf.Steel)
                {
                    __result.SetStuffDirect(InternalDefOf.ABooks_StainlessSteel);
                }
            }
            if (AlphaBooks_Frame_CompleteConstruction_Patch.crafter?.health?.hediffSet.HasHediff(InternalDefOf.ABooks_DurathreadTechniques) == true)
            {
                if (def.MadeFromStuff == true && __result.Stuff == ThingDefOf.Cloth)
                {
                    __result.SetStuffDirect(InternalDefOf.ABooks_Durathread);
                }
            }

        }

      
    }


 





}
