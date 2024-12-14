using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_GiveHediff
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, AbilityDef ability = null, List<int> chargesByQuality = null, HediffDef hediffToAdd = null)
        {
            CompQuality quality = book.TryGetComp<CompQuality>();
            pawn.health.AddHediff(hediffToAdd);
            Hediff addedHediff = pawn.health.hediffSet.GetFirstHediffOfDef(hediffToAdd);
            addedHediff.Severity = 0.1f * (int)quality.qualityInt;

        }

    }
}
