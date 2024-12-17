using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using static RimWorld.Planet.WorldGenStep_Roads;

namespace AlphaBooks
{

    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static StatDef ABooks_LearningFactor_Shooting;
        public static StatDef ABooks_LearningFactor_Melee;
        public static StatDef ABooks_LearningFactor_Construction;
        public static StatDef ABooks_LearningFactor_Mining;
        public static StatDef ABooks_LearningFactor_Cooking;
        public static StatDef ABooks_LearningFactor_Plants;
        public static StatDef ABooks_LearningFactor_Crafting;
        public static StatDef ABooks_LearningFactor_Artistic;
        public static StatDef ABooks_LearningFactor_Medicine;
        public static StatDef ABooks_LearningFactor_Social;
        public static StatDef ABooks_LearningFactor_Intellectual;

        public static HediffDef ABooks_Training_Shooting;
        public static HediffDef ABooks_Training_Melee;
        public static HediffDef ABooks_Training_Construction;
        public static HediffDef ABooks_Training_Mining;
        public static HediffDef ABooks_Training_Cooking;
        public static HediffDef ABooks_Training_Plants;
        public static HediffDef ABooks_Training_Animals;
        public static HediffDef ABooks_Training_Crafting;
        public static HediffDef ABooks_Training_Artistic;
        public static HediffDef ABooks_Training_Medicine;
        public static HediffDef ABooks_Training_Social;
        public static HediffDef ABooks_Training_Intellectual;

        [MayRequireIdeology]
        public static ThoughtDef ABooks_ReligiousBookThought;

        public static ThingCategoryDef Books;

        public static ThingDef ABooks_RuinedBook;
        public static ThingDef ABooks_BurnedBook;


    }
}