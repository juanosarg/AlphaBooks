using RimWorld;
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

      

        public static void Notify_BookRead(Pawn pawn,Book book, ThoughtDef thought = null, AbilityDef ability = null, List<int> chargesByQuality = null,HediffDef hediffToAdd=null)
        {
            book.Destroy();
            
        }

    }
}
