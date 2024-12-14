
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


        static StaticCollections()
        {

            HashSet<ChargeAbilityDef> allLists = DefDatabase<ChargeAbilityDef>.AllDefsListForReading.ToHashSet();
            foreach (ChargeAbilityDef individualList in allLists)
            {
                chargeAbilities.AddRange(individualList.chargeAbilities);
            }


        }



    }
}
