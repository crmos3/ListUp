using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;

namespace ListUp
{
    [BepInPlugin("com.github.craftopia.mod.listUp", "ListUp", "1.0.0.0")]
    public class Patcher : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony("ListUp");
            harmony.PatchAll();
        }
    }
}
