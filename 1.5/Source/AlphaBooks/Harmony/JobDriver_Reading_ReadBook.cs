using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using static UnityEngine.GridBrushBase;

namespace AlphaBooks
{

    [HarmonyPatch(typeof(JobDriver_Reading))]
    [HarmonyPatch("ReadBook")]
    public static class AlphaBooks_JobDriver_Reading_ReadBook_Patch
    {


        [HarmonyPostfix]
        public static void CommunicateFinishedReading(ref Toil __result, JobDriver_Reading __instance)
        {
            __result.AddFinishAction(delegate
            {
                __instance.Book.def.GetModExtension<BookDefModExtension>()?.doerClass.GetMethod("Notify_BookRead").Invoke(null, [__instance.pawn,__instance.Book]);
            });

        }


    }













}

