using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_RandomInspiration
    {

    

        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null)
        {
            InspirationDef inspiration = pawn.mindState.inspirationHandler.GetRandomAvailableInspirationDef();
            if (inspiration != null)
            {
                pawn.mindState.inspirationHandler.TryStartInspiration(inspiration);

            }




        }

    }
}
