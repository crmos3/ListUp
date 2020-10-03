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
        static string filePath = @"d:\EnchantList.txt";
        static void Postfix(SoEnchantDataList ____enchantDataList)
        {
            bool first = true;
            List<string> header = new List<string>();
            StringBuilder output = new StringBuilder(100000);
            foreach (var enchant in ____enchantDataList.GetAll())
            {
                if (first)
                {
                    first = false;
                    var text = ToStringManager.Stringfy(enchant, header);
                    output.Append(ToStringManager.ConstructHeader(header));
                    output.Append(text);
                }
                else
                {
                    output.Append(ToStringManager.Stringfy(enchant));
                }
            }
            File.WriteAllText(filePath, output.ToString());
        }
    }
}
