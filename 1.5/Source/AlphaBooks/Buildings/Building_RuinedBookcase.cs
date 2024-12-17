using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AlphaBooks
{
    public class Building_RuinedBookcase : Building_Bookcase
    {

        public HashSet<ThingDef> ruinedBooks = new HashSet<ThingDef>() { InternalDefOf.ABooks_RuinedBook,InternalDefOf.ABooks_BurnedBook};

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }
           
            if (DebugSettings.godMode)
            {
                yield return new Command_Action
                {
                    defaultLabel = "DEV: Fill Random",
                    action = delegate
                    {
                        RandomizeBooks();
                    }
                };
            }

        }
        public void RandomizeBooks()
        {
            List<ThingDef> books = DefDatabase<ThingDef>.AllDefs.Where(x => x.thingCategories?.Contains(InternalDefOf.Books) == true && !ruinedBooks.Contains(x)).ToList();

            for (int i = HeldBooks.Count; i < MaximumBooks; i++)
            {
                ThingDef bookToAdd;
                if (Rand.Chance(0.25f))
                {
                    bookToAdd = books.RandomElement();
                }
                else bookToAdd = ruinedBooks.RandomElement();

                Book item = BookUtility.MakeBook(bookToAdd, ArtGenerationContext.Outsider);
                innerContainer.TryAdd(item);
            }

        }
    }

  
}
