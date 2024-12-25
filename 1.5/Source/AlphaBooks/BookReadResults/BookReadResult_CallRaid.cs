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
            CompQuality quality = book.TryGetComp<CompQuality>();
            ReadingOutcomeDoer_CallRaids properties = book.GetComp<CompBook>()?.doers?.OfType<ReadingOutcomeDoer_CallRaids>()?.First();
            float pointMultiplier = 1;
            if (properties != null)
            {
                pointMultiplier= properties.Props.lengthForQualities[(int)quality.qualityInt];

            }

            float points = StorytellerUtility.DefaultThreatPointsNow(pawn.Map)* pointMultiplier;

            Faction faction = Find.FactionManager.RandomRaidableEnemyFaction(allowHidden: false, allowDefeated: false, allowNonHumanlike: true);

            StorytellerComp storytellerComp = Find.Storyteller.storytellerComps.First((StorytellerComp x) => x is StorytellerComp_OnOffCycle || x is StorytellerComp_RandomMain);
            IncidentParms parms = storytellerComp.GenerateParms(IncidentCategoryDefOf.ThreatBig, Find.CurrentMap);
            parms.forced = true;
            parms.target = pawn.Map;
            parms.points = points;
            parms.faction = faction;
            List<RaidStrategyDef> source = DefDatabase<RaidStrategyDef>.AllDefs.Where((RaidStrategyDef s) => s.Worker.CanUseWith(parms, PawnGroupKindDefOf.Combat)).ToList();
            if (source.Count > 1)
            {
                parms.raidStrategy = source.RandomElement();
            }
            else
            {
                parms.raidStrategy = RaidStrategyDefOf.ImmediateAttack;
            }
            parms.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
           
            IncidentDefOf.RaidEnemy.Worker.TryExecute(parms);

            

           

        }

    }
}
