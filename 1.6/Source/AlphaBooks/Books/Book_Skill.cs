
using RimWorld;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Grammar;
namespace AlphaBooks
{
    public class Book_Skill : Book_NotAutoReadable
    {
        public SkillDef skill;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Defs.Look(ref skill, "skill");

        }


    }
}