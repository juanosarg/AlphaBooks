using RimWorld;
using UnityEngine;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AlphaBooks
{
    public class AlphaBooks_Settings : ModSettings

    {

        public const float ABooks_QuestRateBase = 1;
        public float ABooks_QuestRate = ABooks_QuestRateBase;
        public bool ABooks_DisableQuests = false;

        public const float ABooks_UsefulBookMultiplierBase = 1;
        public float ABooks_UsefulBookMultiplier = ABooks_UsefulBookMultiplierBase;
        public bool ABooks_DisableReadRuinedBooks = false;


        private static Vector2 scrollPosition = Vector2.zero;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref ABooks_QuestRate, "ABooks_QuestRate", ABooks_QuestRateBase);
            Scribe_Values.Look(ref ABooks_DisableQuests, "ABooks_DisableQuests", false);
            Scribe_Values.Look(ref ABooks_UsefulBookMultiplier, "ABooks_UsefulBookMultiplier", ABooks_UsefulBookMultiplierBase);
            Scribe_Values.Look(ref ABooks_DisableReadRuinedBooks, "ABooks_DisableReadRuinedBooks", false);



        }
        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();

            var scrollContainer = inRect.ContractedBy(10);
            scrollContainer.height -= listingStandard.CurHeight;
            scrollContainer.y += listingStandard.CurHeight;
            Widgets.DrawBoxSolid(scrollContainer, Color.grey);
            var innerContainer = scrollContainer.ContractedBy(1);
            Widgets.DrawBoxSolid(innerContainer, new ColorInt(42, 43, 44).ToColor);
            var frameRect = innerContainer.ContractedBy(5);
            frameRect.y += 15;
            frameRect.height -= 15;
            var contentRect = frameRect;
            contentRect.x = 0;
            contentRect.y = 0;
            contentRect.width -= 20;

            contentRect.height = 950f;

            Widgets.BeginScrollView(frameRect, ref scrollPosition, contentRect, true);
            listingStandard.Begin(contentRect.AtZero());

            var QuestRateLabel = listingStandard.LabelPlusButton("ABooks_QuestRate".Translate() + ": " + ABooks_QuestRate, "ABooks_QuestRateTooltip".Translate());
            ABooks_QuestRate = (float)Math.Round(listingStandard.Slider(ABooks_QuestRate, 0.1f, 5f), 1);
            if (listingStandard.Settings_Button("ABooks_Reset".Translate(), new Rect(0f, QuestRateLabel.position.y + 35, 180f, 29f)))
            {
                ABooks_QuestRate = ABooks_QuestRateBase;
            }
            listingStandard.CheckboxLabeled("ABooks_DisableQuests".Translate(), ref ABooks_DisableQuests, "ABooks_DisableQuests_Description".Translate());

            var usefulbooksRateLabel = listingStandard.LabelPlusButton("ABooks_UsefulBookMultiplier".Translate() + ": " + ABooks_UsefulBookMultiplier, "ABooks_UsefulBookMultiplierTooltip".Translate());
            ABooks_UsefulBookMultiplier = (float)Math.Round(listingStandard.Slider(ABooks_UsefulBookMultiplier, 0.1f, 10f), 1);
            if (listingStandard.Settings_Button("ABooks_Reset".Translate(), new Rect(0f, usefulbooksRateLabel.position.y + 35, 180f, 29f)))
            {
                ABooks_UsefulBookMultiplier = ABooks_UsefulBookMultiplierBase;
            }
            listingStandard.CheckboxLabeled("ABooks_DisableReadRuinedBooks".Translate(), ref ABooks_DisableReadRuinedBooks, "ABooks_DisableReadRuinedBooksTooltip".Translate());



            listingStandard.End();
            Widgets.EndScrollView();

            base.Write();

        }

    }


}
