using System;
using System.Collections.Generic;
using RimWorld.Planet;
using RimWorld;
using Verse;


namespace AlphaBooks
{
    public class CompAbilityCornucopia : CompAbilityEffect
    {
        public new CompProperties_AbilityCornucopia Props => (CompProperties_AbilityCornucopia)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {

            base.Apply(target, dest);


            HashSet<Thing> plantsToGrow = new HashSet<Thing>();
            foreach (Thing thing in GenRadial.RadialDistinctThingsAround(target.Cell, parent.pawn.Map, Props.area, useCenter: true))
            {

                if (thing?.def.IsPlant == true)
                {
                    plantsToGrow.Add(thing);
                }
            }
            if (!plantsToGrow.NullOrEmpty())
            {
                foreach (Thing thing in plantsToGrow)
                {
                    Plant plant = thing as Plant;
                    int num = (int)((1f - plant.Growth) * plant.def.plant.growDays);
                    plant.Age += num;
                    plant.Growth = 1f;
                    plant.Map.mapDrawer.SectionAt(plant.Position).RegenerateAllLayers();

                }
                
            }





        }




    }
}
