using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{


    public class CompProperties_RandomRaidSpawner : CompProperties
    {


        public CompProperties_RandomRaidSpawner()
        {
            this.compClass = typeof(CompRandomRaidSpawner);
        }
    }
}
