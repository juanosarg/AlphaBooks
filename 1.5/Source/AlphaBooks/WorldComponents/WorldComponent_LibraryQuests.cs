using RimWorld;
using RimWorld.Planet;
using Verse;
using RimWorld.QuestGen;
using AlphaBooks;

namespace AlphaGenes
{



    public class WorldComponent_LibraryQuests : WorldComponent
    {
        public int tickCounter;
        public int ticksToNextQuest = 60000 * 17;


        public WorldComponent_LibraryQuests(World world) : base(world)
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();



        }

        public override void WorldComponentTick()
        {
            base.WorldComponentTick();

            if (!AlphaBooks_Mod.settings.ABooks_DisableQuests)
            {

                if (tickCounter > ticksToNextQuest)
                {

                    Slate slate = new Slate();
                    Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(InternalDefOf.Abooks_OpportunitySite_RuinedLibrary, slate);

                    QuestUtility.SendLetterQuestAvailable(quest);
                    ticksToNextQuest = (int)(60000 * Rand.RangeInclusive(15, 30) * AlphaBooks_Mod.settings.ABooks_QuestRate);
                    tickCounter = 0;




                }
                tickCounter++;
            }







        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.tickCounter, nameof(this.tickCounter));
            Scribe_Values.Look(ref this.ticksToNextQuest, nameof(this.ticksToNextQuest));
        }
    }
}
