using HarmonyLib;
using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using static UnityEngine.GridBrushBase;

namespace AlphaBooks
{

    [HarmonyPatch(typeof(Toils_General))]
    [HarmonyPatch("Open")]
    public static class AlphaBooks_Toils_General_Open_Patch
    {


        [HarmonyPostfix]
        public static void CheckForHermetic(ref Toil __result)
        {
            __result.AddFinishAction(delegate
            {
               // Log.Message("Opened");

            });


        }


    }













}

