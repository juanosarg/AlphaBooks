using System.Collections.Generic;
using Verse;
namespace AlphaBooks
{
    public class HediffCompProperties_DeleteAfterTime : HediffCompProperties
    {
        public int disappearsAfterTicks;
        public bool scaleTicksPerQuality = false;
        public int ticksAwful= 15000;
        public int ticksPoor = 30000;
        public int ticksNormal = 60000;
        public int ticksGood = 90000;
        public int ticksExcellent = 120000;
        public int ticksMasterwork = 150000;
        public int ticksLegendary = 180000;

      


        public HediffCompProperties_DeleteAfterTime()
        {
            compClass = typeof(HediffComp_DeleteAfterTime);
        }
    }
}
