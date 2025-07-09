using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using static HarmonyLib.Code;

namespace AlphaBooks
{
    public static class BookReadResult_SkillTrainer
    {


        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null,
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null)
        {
            CompQuality quality = book.TryGetComp<CompQuality>();

            SkillDef skill = pawn.skills.skills.Where((SkillRecord x) => !x.TotallyDisabled).Select(x => x.def).RandomElement();
          
            pawn.skills.Learn(skill, ReadingOutcomeDoer_SkillTrainer.PointsByQuality.Evaluate((int)quality.qualityInt), direct: true);
           
        }

    }
}
