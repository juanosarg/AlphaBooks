
using AlphaBooks;
using RimWorld;
using Verse;
namespace AlphaBooks
{
    public class CompAbilityEffect_DeleteWhenZeroCharges : CompAbilityEffect
    {
        public new CompProperties_DeleteWhenZeroCharges Props => (CompProperties_DeleteWhenZeroCharges)props;



        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
         
            this.parent.maxCharges--;
            if (this.parent.maxCharges<=0)
            {
                this.parent.pawn.abilities.RemoveAbility(this.parent.def);
            }
           
        }




    }
}
