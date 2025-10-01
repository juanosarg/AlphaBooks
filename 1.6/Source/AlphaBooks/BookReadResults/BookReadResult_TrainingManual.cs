using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_TrainingManual
    {

        public static Dictionary<SkillDef, HediffDef> skillDefList = new Dictionary<SkillDef, HediffDef>() { { SkillDefOf.Shooting, InternalDefOf.ABooks_Training_Shooting },
       { SkillDefOf.Melee, InternalDefOf.ABooks_Training_Melee },{ SkillDefOf.Construction, InternalDefOf.ABooks_Training_Construction }
       ,{ SkillDefOf.Mining, InternalDefOf.ABooks_Training_Mining },{ SkillDefOf.Cooking, InternalDefOf.ABooks_Training_Cooking }
       ,{ SkillDefOf.Plants, InternalDefOf.ABooks_Training_Plants },{ SkillDefOf.Animals, InternalDefOf.ABooks_Training_Animals }
       ,{ SkillDefOf.Crafting, InternalDefOf.ABooks_Training_Crafting },{ SkillDefOf.Artistic, InternalDefOf.ABooks_Training_Artistic },
        { SkillDefOf.Medicine, InternalDefOf.ABooks_Training_Medicine },{ SkillDefOf.Social, InternalDefOf.ABooks_Training_Social },
        { SkillDefOf.Intellectual, InternalDefOf.ABooks_Training_Intellectual }
        };


        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null, 
            string generalPurposeText = "")
        {
            if(book is Book_Skill book_Skill)
            {
               
                foreach(var item in skillDefList)
                {
                    if(item.Key == book_Skill.skill)
                    {
                        pawn.health.AddHediff(item.Value);
                        Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(item.Value);
                        QualityCategory quality; 
                        book_Skill.TryGetQuality(out quality);
                        hediff.Severity = (int)quality / 10f;
                    }
                }

               
            }

            
        }

    }
}
