﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_DestroyBook
    {

      

        public static void Notify_BookRead(Pawn pawn,Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null,
            List<int> chargesByQuality = null,HediffDef hediffToAdd=null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null)
        {
            book.Destroy();
            
        }

    }
}
