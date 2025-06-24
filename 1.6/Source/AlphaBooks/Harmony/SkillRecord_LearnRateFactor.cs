using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AlphaBooks
{

    [HarmonyPatch(typeof(SkillRecord))]
    [HarmonyPatch("LearnRateFactor")]
    public static class AlphaBooks_SkillRecord_LearnRateFactor_Patch
    {
        public static Dictionary<SkillDef, StatDef> skillDefList = new Dictionary<SkillDef, StatDef>() { { SkillDefOf.Shooting, InternalDefOf.ABooks_LearningFactor_Shooting },
       { SkillDefOf.Melee, InternalDefOf.ABooks_LearningFactor_Melee },{ SkillDefOf.Construction, InternalDefOf.ABooks_LearningFactor_Construction }
       ,{ SkillDefOf.Mining, InternalDefOf.ABooks_LearningFactor_Mining },{ SkillDefOf.Cooking, InternalDefOf.ABooks_LearningFactor_Cooking }
       ,{ SkillDefOf.Plants, InternalDefOf.ABooks_LearningFactor_Plants },{ SkillDefOf.Animals, StatDefOf.AnimalsLearningFactor }
       ,{ SkillDefOf.Crafting, InternalDefOf.ABooks_LearningFactor_Crafting },{ SkillDefOf.Artistic, InternalDefOf.ABooks_LearningFactor_Artistic },
        { SkillDefOf.Medicine, InternalDefOf.ABooks_LearningFactor_Medicine },{ SkillDefOf.Social, InternalDefOf.ABooks_LearningFactor_Social },
        { SkillDefOf.Intellectual, InternalDefOf.ABooks_LearningFactor_Intellectual }
        };
        [HarmonyPostfix]
        public static void ModifyLearnFactor(SkillRecord __instance, ref float __result)
        {
           
            skillDefList.TryGetValue(__instance.def, out StatDef value);
            if (value != null)
            {
                __result *= __instance.pawn.GetStatValue(value);
            }


        }


    }













}

