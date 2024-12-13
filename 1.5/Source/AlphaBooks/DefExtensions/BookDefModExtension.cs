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


    }
}
