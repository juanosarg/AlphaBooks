using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;
using System.Reflection;

namespace AlphaBooks
{

    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.alphabooks");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }

}
