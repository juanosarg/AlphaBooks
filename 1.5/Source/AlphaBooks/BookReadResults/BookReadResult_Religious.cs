using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_Religious
    {




        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, List<int> chargesByQuality = null, HediffDef hediffToAdd = null)
        {
            if (book is Book_Religious)
            {
                Book_Religious book_Religious = (Book_Religious)book;

                if (!Find.IdeoManager.classicMode)
                {
                    if (pawn.Ideo?.HasMeme(book_Religious.structure) == true)
                    {
                        pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtMaker.MakeThought(InternalDefOf.ABooks_ReligiousBookThought, 1));
                    }
                    else
                    {
                        pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtMaker.MakeThought(InternalDefOf.ABooks_ReligiousBookThought, 0));


                    }
                }
                


            }


        }

    }
}
