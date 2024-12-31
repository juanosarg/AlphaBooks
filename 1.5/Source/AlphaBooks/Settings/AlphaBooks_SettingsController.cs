using RimWorld;
using UnityEngine;
using Verse;


namespace AlphaBooks
{




    public class AlphaBooks_Mod : Mod
    {
        public static AlphaBooks_Settings settings;

        public AlphaBooks_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<AlphaBooks_Settings>();
        }
        public override string SettingsCategory() => "Alpha Books";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }





    }
}

