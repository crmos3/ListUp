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
    [HarmonyPatch("SetupCraftableItems")]
    class OcItemDataMngPatch
    {

        static bool Prefix(ItemData[] ___validItemDataList)
        {
            var reflector = new Reflector<ItemData>();

            var header = reflector.GetHeader();
            header.Insert(0, "JapaneseName");
            header.Insert(0, "EnglishName");
            var values = new List<Dictionary<string, string>>();

            foreach (ItemData item in ___validItemDataList)
            {
                var value = reflector.GetTargetValues(item);
                LanguageUtils.English();
                value["EnglishName"] = item.DisplayName;
                LanguageUtils.Japanese();
                value["JapaneseName"] = item.DisplayName;
                values.Add(value);
            }

            SingletonMonoBehaviour<FileWriter>.Inst.Write("ItemList", header, values);

            return true;
        }

    }
}
