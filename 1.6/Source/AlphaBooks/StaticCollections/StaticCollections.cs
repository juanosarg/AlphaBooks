
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
        public static Dictionary<Pawn,BiomeDef> pawnsAndBiomes = new Dictionary<Pawn, BiomeDef>();
        public static Dictionary<Pawn, ThingDef> pawnsAndCondiments = new Dictionary<Pawn, ThingDef>();
        public static List<ThingDef> allowedMeals = new List<ThingDef>() { InternalDefOf.MealSimple, InternalDefOf.MealFine, InternalDefOf.MealFine_Meat, InternalDefOf.MealFine_Veg };
        public static HashSet<ThingDef> ruinedBooks = new HashSet<ThingDef>() { InternalDefOf.ABooks_RuinedBook, InternalDefOf.ABooks_BurnedBook };


        public static void AddMealToList(ThingDef thing)
        {

            if (!allowedMeals.Contains(thing))
            {
                allowedMeals.Add(thing);
            }
        }

        public static void AddPawnAndBiomeToList(Pawn thing, BiomeDef biome)
        {
            pawnsAndBiomes[thing] = biome;
        }

        public static void RemovePawnAndBiomeFromList(Pawn thing)
        {
            if (pawnsAndBiomes.ContainsKey(thing))
            {
                pawnsAndBiomes.Remove(thing);
            }
        }

        public static void AddPawnAndCondimentToList(Pawn thing, ThingDef condiment)
        {
            pawnsAndCondiments[thing] = condiment;
        }

        public static void RemovePawnAndCondimentFromList(Pawn thing)
        {
            if (pawnsAndCondiments.ContainsKey(thing))
            {
                pawnsAndCondiments.Remove(thing);
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
