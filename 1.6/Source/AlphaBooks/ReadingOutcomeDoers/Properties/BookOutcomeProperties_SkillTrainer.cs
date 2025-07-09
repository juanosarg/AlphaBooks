using RimWorld;
using System;
using System.Collections.Generic;
namespace AlphaBooks
{
    public class BookOutcomeProperties_SkillTrainer : BookOutcomeProperties
    {
       

        public override Type DoerClass => typeof(ReadingOutcomeDoer_SkillTrainer);
    }
}