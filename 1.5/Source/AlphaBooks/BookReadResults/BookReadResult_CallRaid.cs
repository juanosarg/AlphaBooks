using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public static class BookReadResult_CallRaid
    {

      

        public static void Notify_BookRead(Pawn pawn,Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, List<int> chargesByQuality = null,HediffDef hediffToAdd=null)
        {
            float points = StorytellerUtility.DefaultThreatPointsNow(pawn.Map);

            Faction faction = Find.FactionManager.RandomRaidableEnemyFaction(allowHidden: false, allowDefeated: false, allowNonHumanlike: true);

            IncidentParms incidentParms = new IncidentParms
            {

                target = pawn.Map,
                points = points,
                faction = faction,
                raidStrategy = RaidStrategyDefOf.ImmediateAttack,
                raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn

            };

            IncidentDefOf.RaidEnemy.Worker.TryExecute(incidentParms);

           

        }

    }
}
