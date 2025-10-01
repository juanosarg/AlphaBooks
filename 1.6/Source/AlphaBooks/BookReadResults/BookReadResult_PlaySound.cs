
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.Sound;

namespace AlphaBooks
{
    public static class BookReadResult_PlaySound
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality=null, SoundDef sound=null
            , string generalPurposeText = "")
        {

            sound.PlayOneShot(new TargetInfo(pawn.Position, pawn.Map));

        }

    }
}
