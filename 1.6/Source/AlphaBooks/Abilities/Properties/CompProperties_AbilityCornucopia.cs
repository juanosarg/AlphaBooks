using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace AlphaBooks
{
    public class CompProperties_AbilityCornucopia : CompProperties_AbilityEffect
    {


        public float area;

        public CompProperties_AbilityCornucopia()
        {
            this.compClass = typeof(CompAbilityCornucopia);
        }


    }
}
