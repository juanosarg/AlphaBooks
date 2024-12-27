using RimWorld;
using RimWorld.QuestGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_MapLocations
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null)
        {
            HashSet<QuestScriptDef> possibleQuests = new HashSet<QuestScriptDef>();

            HashSet<QuestWhitelistDef> allLists = DefDatabase<QuestWhitelistDef>.AllDefsListForReading.ToHashSet();
            foreach (QuestWhitelistDef individualList in allLists)
            {
                possibleQuests.AddRange(individualList.whiteListedQuests);
            }

            CompQuality quality = book.TryGetComp<CompQuality>();
            float numberOfLocations = ReadingOutcomeDoer_MapLocations.LocationsByQuality.Evaluate((int)quality.Quality);
            for (int i = 0; i < numberOfLocations; i++) {
                Slate slate = new Slate();
                QuestScriptDef questToTrigger = possibleQuests.RandomElement();
                if (questToTrigger.CanRun(slate))
                {
                    Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(questToTrigger, slate);
                   
                    QuestUtility.SendLetterQuestAvailable(quest);

                }
               

            }


        }

    }
}
