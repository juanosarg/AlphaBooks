
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_Condiment
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null,
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null,
            string generalPurposeText = "")
        {
            if (book is Book_Condiment book_condiment)
            {

                CompQuality quality = book_condiment.TryGetComp<CompQuality>();
                Hediff addedHediff = pawn.health.hediffSet.GetFirstHediffOfDef(hediffToAdd);

                if (addedHediff != null)
                {
                    pawn.health.RemoveHediff(addedHediff);
                }
                pawn.health.AddHediff(hediffToAdd);
                addedHediff = pawn.health.hediffSet.GetFirstHediffOfDef(hediffToAdd);
                addedHediff.Severity = 0.1f * (int)quality.qualityInt + 0.05f;
                HediffComp_AddCondiment comp = addedHediff.TryGetComp<HediffComp_AddCondiment>();
                if (comp != null)
                {
                    comp.condimentDef = book_condiment.condiment;
                }

            }

        }

    }
}
