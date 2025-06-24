
using AlphaBooks;
using RimWorld;
using Verse;

namespace AlphaBooks
{

    public class TempMax_ByBiome : StatPart
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
                val += 20;
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
                return "ABooks_StatsReport_TempMaxByBiome".Translate(pawn.Map.Biome.LabelCap);
            }
            return null;
        }
    }
}