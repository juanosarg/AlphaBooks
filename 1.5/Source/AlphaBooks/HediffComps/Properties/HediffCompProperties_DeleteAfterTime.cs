﻿using System.Collections.Generic;
using Verse;
namespace AlphaBooks
{
    public class HediffCompProperties_DeleteAfterTime : HediffCompProperties
    {
        public int disappearsAfterTicks;
       

        public HediffCompProperties_DeleteAfterTime()
        {
            compClass = typeof(HediffComp_DeleteAfterTime);
        }
    }
}
