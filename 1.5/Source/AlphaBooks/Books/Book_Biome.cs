
using RimWorld;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Grammar;
namespace AlphaBooks
{
    public class Book_Biome : Book_NotAutoReadable
    {
        public BiomeDef biome;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Defs.Look(ref biome, "biome");

        }


    }
}