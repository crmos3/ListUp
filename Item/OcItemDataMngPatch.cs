using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Oc;
using Oc.Item;
using System.IO;

namespace Item
{
    [HarmonyPatch(typeof(OcItemDataMng))]
    [HarmonyPatch("SetupCraftableItems")]
    class OcItemDataMngPatch
    {

        static string PrefixString = "|";
        static string SuffixString = "|\n";
        static string Separator = "|";

        static string filePath = @"d:\ItemList.txt"; 

        static bool Prefix(ItemData[] ___validItemDataList)
        {
            string str = WikiHeader();
            foreach(var item in ___validItemDataList)
            {
                str += Format(item);
            }
            File.WriteAllText(filePath, str);

            return true;
        }

        static string Read<T>(ItemData item, string name)
        {
            return AccessTools.FieldRefAccess<ItemData, T>(item, name).ToString();
        }

        static string WikiHeader()
        {
            return "|DisplayName|id|status|maxStack|price|probInTreasureBox|rarity|displayRarity|categoryId|familyId|inventoryTabId|workbenchId|workbenchLv|playerCraftCount|carftTimeCost|materialA_Id|materialB_Id|materialC_Id|materialD_Id|materialE_Id|materialA_count|materialB_count|materialC_count|materialD_count|materialE_count|cooldownTime|effectiveTime|restoreHealth|restoreMana|restoreSatiety|enchantID|lootEnchantId_00|lootEnchantId_01|lootEnchantId_02|lootEnchantId_03|addStamina|atk|atkIncreasePerLv|def|defIncreasePerLv|matk|matkIncreasePerLv|motionSpeed|durabilityValue|registFireLv|registColdLv|registPoisonLv|equipmentPassiveSkillId|equipmentPassiveSkillLevel|equipmentActiveSkillId|equipmentActiveSkillLevel|extraValue_A|extraValue_B|h";
        }

        static string Format(ItemData item)
        {
            string output = (string)PrefixString.Clone();
            output += item.DisplayName + Separator;
            string name = "";
            try
            {
                name = "id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "id").ToString() + Separator;
                name = "status";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "status").ToString() + Separator;
                name = "maxStack";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "maxStack").ToString() + Separator;
                name = "price";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "price").ToString() + Separator;
                name = "probInTreasureBox";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "probInTreasureBox").ToString() + Separator;
                name = "rarity";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "rarity").ToString() + Separator;
                name = "displayRarity";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "displayRarity").ToString() + Separator;
                name = "categoryId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "categoryId").ToString() + Separator;
                name = "familyId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "familyId").ToString() + Separator;
                name = "inventoryTabId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "inventoryTabId").ToString() + Separator;
                name = "workbenchId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "workbenchId").ToString() + Separator;
                name = "workbenchLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "workbenchLv").ToString() + Separator;
                name = "playerCraftCount";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "playerCraftCount").ToString() + Separator;
                name = "carftTimeCost";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "carftTimeCost").ToString() + Separator;
                name = "materialA_Id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialA_Id").ToString() + Separator;
                name = "materialB_Id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialB_Id").ToString() + Separator;
                name = "materialC_Id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialC_Id").ToString() + Separator;
                name = "materialD_Id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialD_Id").ToString() + Separator;
                name = "materialE_Id";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialE_Id").ToString() + Separator;
                name = "materialA_count";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialA_count").ToString() + Separator;
                name = "materialB_count";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialB_count").ToString() + Separator;
                name = "materialC_count";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialC_count").ToString() + Separator;
                name = "materialD_count";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialD_count").ToString() + Separator;
                name = "materialE_count";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "materialE_count").ToString() + Separator;
                name = "cooldownTime";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "cooldownTime").ToString() + Separator;
                name = "effectiveTime";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "effectiveTime").ToString() + Separator;
                name = "restoreHealth";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "restoreHealth").ToString() + Separator;
                name = "restoreMana";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "restoreMana").ToString() + Separator;
                name = "restoreSatiety";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "restoreSatiety").ToString() + Separator;
                name = "enchantID";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "enchantID").ToString() + Separator;
                name = "lootEnchantId_00";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "lootEnchantId_00").ToString() + Separator;
                name = "lootEnchantId_01";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "lootEnchantId_01").ToString() + Separator;
                name = "lootEnchantId_02";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "lootEnchantId_02").ToString() + Separator;
                name = "lootEnchantId_03";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "lootEnchantId_03").ToString() + Separator;
                name = "addStamina";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "addStamina").ToString() + Separator;
                name = "atk";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "atk").ToString() + Separator;
                name = "atkIncreasePerLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "atkIncreasePerLv").ToString() + Separator;
                name = "def";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "def").ToString() + Separator;
                name = "defIncreasePerLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "defIncreasePerLv").ToString() + Separator;
                name = "matk";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "matk").ToString() + Separator;
                name = "matkIncreasePerLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "matkIncreasePerLv").ToString() + Separator;
                name = "motionSpeed";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "motionSpeed").ToString() + Separator;
                name = "durabilityValue";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "durabilityValue").ToString() + Separator;
                name = "registFireLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "registFireLv").ToString() + Separator;
                name = "registColdLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "registColdLv").ToString() + Separator;
                name = "registPoisonLv";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "registPoisonLv").ToString() + Separator;
                name = "equipmentPassiveSkillId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "equipmentPassiveSkillId").ToString() + Separator;
                name = "equipmentPassiveSkillLevel";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "equipmentPassiveSkillLevel").ToString() + Separator;
                name = "equipmentActiveSkillId";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "equipmentActiveSkillId").ToString() + Separator;
                name = "equipmentActiveSkillLevel";
                output += AccessTools.FieldRefAccess<ItemData, int>(item, "equipmentActiveSkillLevel").ToString() + Separator;
                name = "extraValue_A";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "extraValue_A").ToString() + Separator;
                name = "extraValue_B";
                output += AccessTools.FieldRefAccess<ItemData, float>(item, "extraValue_B").ToString();
            }
            catch(Exception e)
            {
                throw new Exception("Error in " + name);
            }

            output += SuffixString;
            return output;
        }


    }
}
