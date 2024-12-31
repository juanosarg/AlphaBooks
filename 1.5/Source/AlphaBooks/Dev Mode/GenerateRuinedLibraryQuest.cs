using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RimWorld;
using Verse.AI.Group;
using Verse;
using RimWorld.QuestGen;
using LudeonTK;


namespace AlphaBooks
{
    public static class GenerateRuinedLibraryQuest
    {


        [DebugAction("Alpha Books", "Generate Ruined Library quest", false, false, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void GenerateLabQuest()
        {

            Slate slate = new Slate();
            Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(InternalDefOf.Abooks_OpportunitySite_RuinedLibrary, slate);

            QuestUtility.SendLetterQuestAvailable(quest);
        }




    }
}

