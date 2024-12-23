using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using AlphaBooks;

namespace AlphaBooks
{




    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("MakeRecipeProducts")]

    public static class AlphaBooks_GenRecipe_MakeRecipeProducts_Patch
    {

        public static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, RecipeDef recipeDef, Pawn worker)
        {
            List<Thing> resultingList = values.ToList();
            if (recipeDef.products != null && worker.health.hediffSet.HasHediff(InternalDefOf.ABooks_RestaurantGuide))
            {

                foreach (Thing thing in resultingList)
                {
                    if (StaticCollections.allowedMeals.Contains(thing.def))
                    {
                         
                        if (thing.def == InternalDefOf.MealSimple)
                        {
                            thing.def = InternalDefOf.MealFine;
                        }else
                        if (thing.def == InternalDefOf.MealFine_Meat)
                        {
                            thing.def = InternalDefOf.MealLavish_Meat;
                        }
                        else
                        if (thing.def == InternalDefOf.MealFine_Veg)
                        {
                            thing.def = InternalDefOf.MealLavish_Veg;
                        }
                        else
                        if (thing.def.defName == "VCE_SimpleBake")
                        {
                            thing.def = ThingDef.Named("VCE_FineBake");
                        }
                        else
                        if (thing.def.defName == "VCE_FineBake")
                        {
                            thing.def = ThingDef.Named("VCE_LavishBake");
                        }
                        else
                        if (thing.def.defName == "VCE_SimpleGrill")
                        {
                            thing.def = ThingDef.Named("VCE_FineGrill");
                        }
                        else
                        if (thing.def.defName == "VCE_FineGrill" )
                        {
                            thing.def = ThingDef.Named("VCE_LavishGrill");
                        }
                        else thing.def = InternalDefOf.MealLavish;


                    }

                }

            }
            return resultingList;









        }

    }





}
