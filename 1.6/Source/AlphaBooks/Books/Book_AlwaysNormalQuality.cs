
using RimWorld;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Grammar;
namespace AlphaBooks
{
    public class Book_AlwaysNormalQuality : Book_NotAutoReadable
    {
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            GetComp<CompQuality>()?.SetQuality(QualityCategory.Normal,null);
        }


    }
}