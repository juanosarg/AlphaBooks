using HarmonyLib;
using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
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
        public static void CheckForHermetic(ref Toil __result, TargetIndex openableInd)
        {
            Toil copyToil = __result;

            __result.AddFinishAction(delegate
            {
               
                if (copyToil.actor?.health?.hediffSet.HasHediff(InternalDefOf.ABooks_HermeticMysteries) == true)
                {
                    
                    if (copyToil.actor.CurJob.GetTarget(openableInd).Thing.def == ThingDefOf.AncientHermeticCrate)
                    {
                       
                        ThingSetMakerParams parms = default(ThingSetMakerParams);
                       
                        parms.totalMarketValueRange = new FloatRange(450, 550);
                        parms.minSingleItemMarketValuePct = 0;
                        parms.allowNonStackableDuplicates = true;
                        parms.countRange = new IntRange(1, 5);
                        List<Thing> list2 = InternalDefOf.ABooks_Resources.root.Generate(parms);
                        if (list2 != null)
                        {
                 
                            foreach (Thing thing in list2)
                            {
                                GenPlace.TryPlaceThing(thing, copyToil.actor.Position, copyToil.actor.Map, ThingPlaceMode.Near);

                            }

                        }
                    }


                }


                    


               

            });


        }


    }













}

