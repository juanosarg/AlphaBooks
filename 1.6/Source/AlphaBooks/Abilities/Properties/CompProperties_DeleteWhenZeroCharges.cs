using RimWorld;
namespace AlphaBooks
{
    public class CompProperties_DeleteWhenZeroCharges : CompProperties_AbilityEffect
    {

        public CompProperties_DeleteWhenZeroCharges()
        {
            compClass = typeof(CompAbilityEffect_DeleteWhenZeroCharges);
        }
    }
}