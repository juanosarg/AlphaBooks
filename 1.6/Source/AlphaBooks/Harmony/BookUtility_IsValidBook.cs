using HarmonyLib;
using RimWorld;
using System;
using Verse;
using Verse.AI;
using static UnityEngine.GridBrushBase;

namespace AlphaBooks
{

    [HarmonyPatch(typeof(BookUtility))]
    [HarmonyPatch("IsValidBook")]
    public static class AlphaBooks_BookUtility_IsValidBook_Patch
    {


        [HarmonyPostfix]
        public static void RemoveBooks(ref bool __result, Thing thing)
        {
            if (thing is Book_NotAutoReadable)
            {
                __result = false;
            }

            if (StaticCollections.ruinedBooks.Contains(thing.def) && AlphaBooks_Mod.settings.ABooks_DisableReadRuinedBooks)
            {
                __result = false;
            }

        }


    }













}

