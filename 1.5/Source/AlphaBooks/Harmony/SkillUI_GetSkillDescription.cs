using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Text;

namespace AlphaBooks
{

    [HarmonyPatch(typeof(SkillUI))]
    [HarmonyPatch("GetSkillDescription")]
    public static class AlphaBooks_SkillUI_GetSkillDescription_Patch
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
        public static void ModifySkillDescription(SkillRecord sk, ref string __result)
        {
            foreach (var item in skillDefList)
            {
                if (sk.def == item.Key)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine();
                    float num = sk.Pawn.GetStatValue(item.Value);
                    stringBuilder.AppendLine("  - " + item.Value.LabelCap +"ABooks_NotTallied".Translate()+ ": x" + num.ToStringPercent());
                    __result += stringBuilder.ToString().TrimEndNewlines();
                    break;
                }
            }
            
          

        }


    }













}

