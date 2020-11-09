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
    [HarmonyPatch(typeof(OcStaticObjMng))]
    [HarmonyPatch("setupSpanwer")]
    class OcStaticObjMngPatch
    {

        static string filePath = @"d:\StaticObjList.txt";

        public static void Postfix(List<OcStaticObj_Spawner> ____ObjBuff_Spawner)
        {

            bool first = true;
            List<string> header = new List<string>();
            StringBuilder output = new StringBuilder(1000000);
            List<int> list = new List<int>();
            foreach (OcStaticObj_Spawner ocStaticObj_Spawner in ____ObjBuff_Spawner)
            {
                var target = ocStaticObj_Spawner.GetComponentInChildren<OcStaticObj>(true).SoEnemyData;
                if (list.Contains(target.ID)) continue;
                else list.Add(target.ID);
                if (first)
                {
                    first = false;
                    var text = ToStringManager.Stringfy(target, header);
                    output.Append(ToStringManager.ConstructHeader(header));
                    output.Append(text);
                }
                else
                {
                    output.Append(ToStringManager.Stringfy(target));
                }
            }
            File.WriteAllText(filePath, output.ToString());
        }
    }
}
