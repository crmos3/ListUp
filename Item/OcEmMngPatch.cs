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
            write(____SoEnemyArray, @"d:\EnemyList_Default.txt", "SoEmData");
            write(____SoEnemyArray, @"d:\EnemyList_Lv30.txt", "SoEmDataLv30");
            write(____SoEnemyArray, @"d:\EnemyList_Lv60.txt", "SoEmDataLv60");
            write(____SoEnemyArray, @"d:\EnemyList_Lv90.txt", "SoEmDataLv90");

        }

        static void write(SoEnemyArray ____SoEnemyArray, string filePath, string variableName)
        {
            bool first = true;
            List<string> header = new List<string>();
            StringBuilder output = new StringBuilder(100000);
            foreach (var enemy in ____SoEnemyArray.EmArray)
            {
                try
                {
                    var e = AccessTools.FieldRefAccess<OcEm, SoEnemyData>(enemy, variableName);
                    if (first)
                    {
                        first = false;
                        var text = ToStringManager.Stringfy(e, header);
                        output.Append(ToStringManager.ConstructHeader(header));
                        output.Append(text);
                    }
                    else
                    {
                        output.Append(ToStringManager.Stringfy(e));
                    }
                }
                catch { }

            }
            File.WriteAllText(filePath, output.ToString());
        }
    }
}
