using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oc;
using Oc.Item;
using HarmonyLib;
using System.IO;
using Oc.Em;
namespace ListUp
{

    [HarmonyPatch(typeof(OcEmMng))]
    [HarmonyPatch("OnUnityAwake")]
    class OcEmMngPatch
    {
        static void Postfix(SoEnemyArray ____SoEnemyArray)
        {
            write(____SoEnemyArray, "EnemyList_Default", "SoEmData");
            write(____SoEnemyArray, "EnemyList_Lv30", "SoEmDataLv30");
            write(____SoEnemyArray, "EnemyList_Lv60", "SoEmDataLv60");
            write(____SoEnemyArray, "EnemyList_Lv90", "SoEmDataLv90");
        }

        static void write(SoEnemyArray ____SoEnemyArray, string fileName, string variableName)
        {
            var reflector = new Reflector<SoEnemyData>();

            var header = reflector.GetHeader();
            header.Insert(0, "JapaneseName");
            header.Insert(0, "EnglishName");
            var values = new List<Dictionary<string, string>>();

            foreach (OcEm enemy in ____SoEnemyArray.EmArray)
            {
                try
                {
                    var e = AccessTools.FieldRefAccess<OcEm, SoEnemyData>(enemy, variableName);
                    var value = reflector.GetTargetValues(e);
                    LanguageUtils.English();
                    value["EnglishName"] = e.Name;
                    LanguageUtils.Japanese();
                    value["JapaneseName"] = e.Name;
                    values.Add(value);
                }
                catch { }
            }

            SingletonMonoBehaviour<FileWriter>.Inst.Write(fileName, header, values);
        }
    }
}
