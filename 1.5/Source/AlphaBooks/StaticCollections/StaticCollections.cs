
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;


namespace AlphaBooks
{
    [StaticConstructorOnStartup]
    public static class StaticCollections
    {

        public static HashSet<AbilityDef> chargeAbilities = new HashSet<AbilityDef>();

        public static List<ThingDef> allowedMeals = new List<ThingDef>() { InternalDefOf.MealSimple, InternalDefOf.MealFine, InternalDefOf.MealFine_Meat, InternalDefOf.MealFine_Veg };

        public static void AddMealToList(ThingDef thing)
        {

            if (!allowedMeals.Contains(thing))
            {
                allowedMeals.Add(thing);
            }
        }


        static StaticCollections()
        {

            HashSet<ChargeAbilityDef> allLists = DefDatabase<ChargeAbilityDef>.AllDefsListForReading.ToHashSet();
            foreach (ChargeAbilityDef individualList in allLists)
            {
                chargeAbilities.AddRange(individualList.chargeAbilities);
            }

            if (ModLister.HasActiveModWithName("Vanilla Cooking Expanded"))
            {
                AddMealToList(ThingDef.Named("VCE_SimpleBake"));
                AddMealToList(ThingDef.Named("VCE_FineBake"));
                AddMealToList(ThingDef.Named("VCE_SimpleGrill"));
                AddMealToList(ThingDef.Named("VCE_FineGrill"));
            }


        }



    }
}
