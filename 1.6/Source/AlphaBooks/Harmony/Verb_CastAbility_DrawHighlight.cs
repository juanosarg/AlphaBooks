using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;
using System;
using UnityEngine.Analytics;
using static UnityEngine.GraphicsBuffer;
using AlphaBooks;


namespace AlphaBooks
{
    [HarmonyPatch(typeof(Verb_CastAbility))]
    [HarmonyPatch("DrawHighlight")]
    public static class AlphaBooks_Verb_CastAbility_DrawHighlight_Patch
    {
        [HarmonyPostfix]
        static void DrawExtraRing(Verb_CastAbility __instance, LocalTargetInfo target)
        {

            if (__instance.ability.def == InternalDefOf.ABooks_Cornucopia_Charges)
            {
                GenDraw.DrawRadiusRing(target.CenterVector3.ToIntVec3(), 3f);

            }
        }
    }
}
