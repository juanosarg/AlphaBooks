using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaBooks;
using RimWorld;
using UnityEngine;
using Verse;

namespace AlphaBooks
{

    public class CompRandomRaidSpawner : ThingComp
    {
        public CompProperties_RandomRaidSpawner Props => (CompProperties_RandomRaidSpawner)this.props;





        public override void CompTick()
        {
            base.CompTick();
            if (this.parent.IsHashIntervalTick(500))
            {

                int num = GenRadial.NumCellsInRadius(7);
                for (int i = 0; i < num; i++)
                {
                    IntVec3 current = this.parent.Position + GenRadial.RadialPattern[i];
                    if (current.InBounds(this.parent.Map))
                    {
                        Pawn pawn = current.GetFirstPawn(this.parent.Map);
                        if ((pawn != null) && (pawn.Faction == Faction.OfPlayer))
                        {
                            SpawnHostileRaid();
                            break;
                        }
                    }
                }


            }
        }

        public void SpawnHostileRaid()
        {
  


            float points = StorytellerUtility.DefaultThreatPointsNow(this.parent.Map);

            Faction faction = Find.FactionManager.RandomRaidableEnemyFaction(allowHidden: false, allowDefeated: false, allowNonHumanlike: true);

            StorytellerComp storytellerComp = Find.Storyteller.storytellerComps.First((StorytellerComp x) => x is StorytellerComp_OnOffCycle || x is StorytellerComp_RandomMain);
            IncidentParms parms = storytellerComp.GenerateParms(IncidentCategoryDefOf.ThreatBig, this.parent.Map);
            parms.forced = true;
            parms.target = this.parent.Map;
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

            foreach (Pawn pawn in this.parent.Map.mapPawns.FreeColonistsSpawned)
            {
                pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(InternalDefOf.ABooks_RaidedLibrary);
            }

            this.parent.Destroy();

        }

    }
}
