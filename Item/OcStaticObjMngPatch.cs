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
        public static void Postfix(List<OcStaticObj_Spawner> ____ObjBuff_Spawner)
        {
            var reflector = new Reflector<SoEnemyData>();

            var header = reflector.GetHeader();
            header.Insert(0, "JapaneseName");
            header.Insert(0, "EnglishName");
            var values = new List<Dictionary<string, string>>();

            List<int> IDs = new List<int>();
            foreach (OcStaticObj_Spawner ocStaticObj_Spawner in ____ObjBuff_Spawner)
            {
                var soEnemyData = ocStaticObj_Spawner.GetComponentInChildren<OcStaticObj>(true).SoEnemyData;
                if (IDs.Contains(soEnemyData.ID)) continue;
                else IDs.Add(soEnemyData.ID);

                var value = reflector.GetTargetValues(soEnemyData);
                LanguageUtils.English();
                value["EnglishName"] = soEnemyData.Name;
                LanguageUtils.Japanese();
                value["JapaneseName"] = soEnemyData.Name;
                values.Add(value);
            }

            SingletonMonoBehaviour<FileWriter>.Inst.Write("StaticObjList", header, values);
        }
    }
}
