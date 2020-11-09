using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Oc;
using Oc.Item;
using System.IO;
using LibCraftopia;

namespace ListUp
{
    [HarmonyPatch(typeof(OcItemDataMng))]
    //[HarmonyPatch("SetupCraftableItems")]
    [HarmonyPatch("SetupCraftableItems")]
    class OcItemDataMngPatch
    {

        static string filePath = @"d:\ItemList.txt"; 

        static bool Prefix(ItemData[] ___validItemDataList)
        {
            bool first = true;
            List<string> header = new List<string>();
            StringBuilder output = new StringBuilder(100000); 
            foreach(var item in ___validItemDataList)
            {
                if (first)
                {
                    first = false;
                    var text = ToStringManager.Stringfy(item, header);
                    output.Append(ToStringManager.ConstructHeader(header));
                    output.Append(text);
                }
                else
                {
                    output.Append(ToStringManager.Stringfy(item));
                }
            }
            File.WriteAllText(filePath, output.ToString());
            return true;
        }

    }
}
