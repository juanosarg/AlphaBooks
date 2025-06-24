
using AlphaBooks;
using RimWorld;
using Verse;

namespace AlphaBooks
{

    public class Multiplier_ByBiome : StatPart
    {

        public override void TransformValue(StatRequest req, ref float val)
        {
            Pawn pawn;
            if (!req.HasThing || req.Thing == null || (pawn = (req.Thing as Pawn)) == null || !StaticCollections.pawnsAndBiomes.ContainsKey(pawn) || pawn.Map == null)
            {
                return;
            }

            if (StaticCollections.pawnsAndBiomes[pawn] == pawn.Map.Biome)
            {
                val *= 1.2f;
            }

        }

        public override string ExplanationPart(StatRequest req)
        {
            Pawn pawn;
            if (!req.HasThing || req.Thing == null || (pawn = (req.Thing as Pawn)) == null || !StaticCollections.pawnsAndBiomes.ContainsKey(pawn) || pawn.Map == null)
            {
                return null;
            }

            if (StaticCollections.pawnsAndBiomes[pawn] == pawn.Map.Biome)
            {
                return "ABooks_StatsReport_MultiplierByBiome".Translate(pawn.Map.Biome.LabelCap);
            }
            return null;
        }
    }
}