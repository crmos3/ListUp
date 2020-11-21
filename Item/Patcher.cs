using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;

namespace ListUp
{
    [BepInPlugin("listUp", "ListUp", "2.0.0.0")]
    public class Patcher : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony("ListUp");
            harmony.PatchAll();

            // wiki
            gameObject.AddComponent<FileWriter>().Init(10000, @"d:\", ".txt", "|", "|\n", "|");

            // csv
            // gameObject.AddComponent<FileWriter>().Init(10000, @"d:\", ".csv", "", "\n", ",");
        }
    }
}
