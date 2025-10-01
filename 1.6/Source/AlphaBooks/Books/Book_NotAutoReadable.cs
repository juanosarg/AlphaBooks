
using RimWorld;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Grammar;
namespace AlphaBooks
{
    public class Book_NotAutoReadable : Book
    {
        public void PawnReadNowInternal(Pawn pawn)
        {
            Job job = JobMaker.MakeJob(InternalDefOf.ABooks_Reading, this);
            pawn.jobs.TryTakeOrderedJob(job, JobTag.Misc);
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            FloatMenuOption floatMenuOption = new FloatMenuOption("AssignReadNow".Translate(Label), delegate
            {
                PawnReadNowInternal(selPawn);
            });
            if (!BookUtility.CanReadBook(this, selPawn, out var reason))
            {
                floatMenuOption.Label = string.Format("{0}: {1}", "AssignCannotReadNow".Translate(Label), reason);
                floatMenuOption.Disabled = true;
            }
            Pawn pawn = selPawn.Map.reservationManager.FirstRespectedReserver(this, selPawn) ?? selPawn.Map.physicalInteractionReservationManager.FirstReserverOf(this);
            if (pawn != null)
            {
                floatMenuOption.Label += " (" + "ReservedBy".Translate(pawn.LabelShort, pawn) + ")";
            }
            floatMenuOption.iconThing = this;
            yield return floatMenuOption;
            foreach (FloatMenuOption floatMenuOption2 in base.GetFloatMenuOptions(selPawn))
            {
                if(floatMenuOption2.Label!= "AssignReadNow".Translate(Label))
                {
                    floatMenuOption2.iconThing = this;

                    yield return floatMenuOption2;
                }
                
            }
        }


    }
}