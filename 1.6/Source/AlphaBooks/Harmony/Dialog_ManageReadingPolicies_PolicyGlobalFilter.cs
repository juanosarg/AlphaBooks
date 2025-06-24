using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;
using AlphaBooks;



namespace AlphaBooks
{


    [HarmonyPatch(typeof(Dialog_ManageReadingPolicies))]
    [HarmonyPatch("PolicyGlobalFilter", MethodType.Getter)]
    public static class AlphaBooks_Dialog_ManageReadingPolicies_PolicyGlobalFilter_Patch
    {
        private static ThingFilter policyGlobalFilterInternal;

        [HarmonyPostfix]
        static void ModifyPolicyFilter(ref ThingFilter ___policyGlobalFilter, ref ThingFilter __result)
        {
            if (policyGlobalFilterInternal == null)
            {
                policyGlobalFilterInternal = new ThingFilter();
                foreach (ThingDef item in ___policyGlobalFilter.allowedDefs.Where((ThingDef x) => !x.defName.Contains("ABooks_")))
                {
                    policyGlobalFilterInternal.SetAllow(item, allow: true);
                   
                }
                ___policyGlobalFilter = policyGlobalFilterInternal;
            }
            __result =  policyGlobalFilterInternal;

        }
    }








}
