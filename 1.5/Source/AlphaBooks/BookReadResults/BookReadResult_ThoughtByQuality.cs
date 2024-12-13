using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_ThoughtByQuality
    {


        public static void Notify_BookRead(Pawn pawn,Book book, ThoughtDef thought = null)
        {

            CompQuality quality = book.TryGetComp<CompQuality>();
            pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtMaker.MakeThought(thought, (int)quality.qualityInt));


        }

    }
}
