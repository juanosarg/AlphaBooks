using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_RandomAstronomicalIncident
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null
            , string generalPurposeText = "")
        {
            HashSet<IncidentDef> possibleIncidents = new HashSet<IncidentDef>();

            HashSet<AstronomicalIncidentWhitelistDef> allLists = DefDatabase<AstronomicalIncidentWhitelistDef>.AllDefsListForReading.ToHashSet();
            foreach (AstronomicalIncidentWhitelistDef individualList in allLists)
            {
                possibleIncidents.AddRange(individualList.whiteListedIncidents);
            }

            IncidentDef localDef = possibleIncidents.RandomElement();
            IncidentParms parms = StorytellerUtility.DefaultParmsNow(localDef.category, pawn.Map);
            localDef.Worker.TryExecute(parms);


        }

    }
}
