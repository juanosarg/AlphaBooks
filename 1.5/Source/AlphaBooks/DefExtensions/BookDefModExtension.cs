using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public class BookDefModExtension :DefModExtension
    {

        public List<BookReadResults> readResults;

    }

    public class BookReadResults
    {
        public Type doerClass;
        public ThoughtDef thoughtToGive;
        public List<AbilityDef> abilitiesToGive;
        public List<int> chargesByQuality;
        public HediffDef hediffToAdd;
        public List<ThingAndCount> thingsToSpawnByQuality;
        public SoundDef sound;

    }

    public class ThingAndCount
    {
        public ThingDef thing;
        public int count;

    }
}
