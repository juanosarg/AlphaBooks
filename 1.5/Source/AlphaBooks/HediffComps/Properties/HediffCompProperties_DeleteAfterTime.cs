using System.Collections.Generic;
using Verse;
namespace AlphaBooks
{
    public class HediffCompProperties_DeleteAfterTime : HediffCompProperties
    {
        public int disappearsAfterTicks;
        public bool scaleTicksPerQuality = false;
        public int ticksAwful;
        public int ticksPoor;
        public int ticksNormal;
        public int ticksGood;
        public int ticksExcellent;
        public int ticksMasterwork;
        public int ticksLegendary;


        public HediffCompProperties_DeleteAfterTime()
        {
            compClass = typeof(HediffComp_DeleteAfterTime);
        }
    }
}
