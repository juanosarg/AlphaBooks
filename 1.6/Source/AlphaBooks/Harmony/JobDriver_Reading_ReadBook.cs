using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
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
                BookDefModExtension extension = __instance.Book.def.GetModExtension<BookDefModExtension>();

                if (extension?.readResults.NullOrEmpty() == false && __instance.pawn.jobs.curDriver.ticksLeftThisToil <= 0)
                {
                    foreach(BookReadResults result in extension.readResults)
                    {
                        result.doerClass.GetMethod("Notify_BookRead").Invoke(null, [__instance.pawn, __instance.Book, result.thoughtToGive,
                            result.abilitiesToGive,result.chargesByQuality,result.hediffToAdd,result.thingsToSpawnByQuality, result.sound,result.generalPurposeText]);
                    }
                }

            });

        }


    }













}

