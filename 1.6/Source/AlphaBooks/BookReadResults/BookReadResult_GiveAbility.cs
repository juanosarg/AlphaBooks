using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_GiveAbility
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null,HediffDef hediffToAdd= null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null)
        {
            AbilityDef ability = abilities.RandomElement();
            pawn.abilities.GainAbility(ability);
            if (chargesByQuality != null)
            {
                CompQuality compQuality = book.TryGetComp<CompQuality>();
                if (compQuality != null) {
                    pawn.abilities.GetAbility(ability).maxCharges = chargesByQuality[(int)compQuality.qualityInt];
                    pawn.abilities.GetAbility(ability).charges = chargesByQuality[(int)compQuality.qualityInt];
                }
                
            }
           


        }

    }
}
