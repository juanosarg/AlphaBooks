
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.Grammar;

namespace AlphaBooks
{
    public class ReadingOutcomeDoer_GiveAbility : BookOutcomeDoer
    {

        public SimpleCurve ChargesByQuality()
        {
            SimpleCurve curve = new SimpleCurve();

            curve.Add(new CurvePoint(0f, Props.chargesByQuality[0]));
            curve.Add(new CurvePoint(1f, Props.chargesByQuality[1]));
            curve.Add(new CurvePoint(2f, Props.chargesByQuality[2]));
            curve.Add(new CurvePoint(3f, Props.chargesByQuality[3]));
            curve.Add(new CurvePoint(4f, Props.chargesByQuality[4]));
            curve.Add(new CurvePoint(5f, Props.chargesByQuality[5]));
            curve.Add(new CurvePoint(6f, Props.chargesByQuality[6]));
            return curve;
        }

        public new BookOutcomeProperties_GiveAbility Props => (BookOutcomeProperties_GiveAbility)props;

     

        public override bool DoesProvidesOutcome(Pawn reader)
        {
            return false;
        }
        
        public override string GetBenefitsString(Pawn reader = null)
        {
            if (Props.charges)
            {
                return "ABooks_Ability_Charges".Translate(Props.abilityToGive.LabelCap, ChargesByQuality().Evaluate((int)base.Quality));
            }
            else
            {
                return "ABooks_Ability".Translate(Props.abilityToGive.LabelCap);

            }

        }

        public override List<RulePack> GetTopicRulePacks()
        {
            if (Props.propagateRulesForTitle)
            {
                RulePack rulepack = new RulePack();
                rulepack.rulesStrings =
                [
                    "subject->" + (string)Props.abilityToGive.LabelCap

                ];

                return new List<RulePack> { rulepack };
            }
            return null;
        }

    }
}