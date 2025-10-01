
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Verse;
using Verse.Noise;

namespace AlphaBooks
{
    public static class BookReadResult_SpawnThingsByQuality
    {



        public static void Notify_BookRead(Pawn pawn, Book book, ThoughtDef thought = null, List<AbilityDef> abilities = null, 
            List<int> chargesByQuality = null, HediffDef hediffToAdd = null, List<ThingAndCount> thingsToSpawnByQuality = null, SoundDef sound = null, 
            string generalPurposeText = "")
        {

            CompQuality quality = book.TryGetComp<CompQuality>();

            if (thingsToSpawnByQuality!=null)
            {
                ThingAndCount thingAndCount = thingsToSpawnByQuality[(int)quality.qualityInt];

                if (thingAndCount.thing.race != null)
                {
                    PawnKindDef kindDef = DefDatabase<PawnKindDef>.AllDefsListForReading.Where(x => x.race == thingAndCount.thing).First();
                    for(int i = 0; i < thingAndCount.count; i++)
                    {
                        Pawn p = PawnGenerator.GeneratePawn(kindDef, pawn.Faction);
                        p.ageTracker.AgeBiologicalTicks = 30000;
                        GenSpawn.Spawn(p, pawn.Position, pawn.Map);
                    }
                    
                }
                else
                {
                    Thing thing = ThingMaker.MakeThing(thingAndCount.thing);
                    thing.stackCount = thingAndCount.count;
                    GenPlace.TryPlaceThing(thing, pawn.Position, pawn.Map, ThingPlaceMode.Near);

                }
                
            }
        }

    }
}
