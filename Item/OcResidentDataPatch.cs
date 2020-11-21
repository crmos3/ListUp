using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Oc;
using Oc.Item;

namespace ListUp
{
    [HarmonyPatch(typeof(OcResidentData))]
    [HarmonyPatch("OnUnityAwake")]
    class OcResidentDataPatch
    {
        static void Postfix(SoEnchantDataList ____enchantDataList)
        {
            var reflector = new Reflector<SoEnchantment>();

            var header = reflector.GetHeader();
            header.Insert(0, "JapaneseName");
            header.Insert(0, "EnglishName");
            var values = new List<Dictionary<string, string>>();

            foreach (SoEnchantment enchant in ____enchantDataList.GetAll())
            {
                var value = reflector.GetTargetValues(enchant);
                LanguageUtils.English();
                value["EnglishName"] = enchant.DisplayName;
                LanguageUtils.Japanese();
                value["JapaneseName"] = enchant.DisplayName;
                values.Add(value);
            }

            SingletonMonoBehaviour<FileWriter>.Inst.Write("EnchantList", header, values);
        }
    }
}
