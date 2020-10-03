using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oc;
using Oc.Item;
using SR;
using HarmonyLib;

namespace ListUp
{
    public static class ToStringManager
    {
        public static string Separator = "|";
        public static string Suffix = "|\n";
        public static string Prefix = "|";

        /*
        public static string Stringfy(ItemData value, List<string> header = null)
        {
            string name = "";
            StringBuilder output = new StringBuilder();
            output.Append(Prefix);

            LanguageManager.ChangeLanguage("English");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("EnglishName")) header.Add("EnglishName");

            LanguageManager.ChangeLanguage("Japanese");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("JapaneseName")) header.Add("JapaneseName");

            try
            {

            }
            catch
            {
                UnityEngine.Debug.Log("error in " + name);
                throw new Exception("error in " + name);
            }
            output.Append(Suffix);
            return output.ToString();
        }*/

        public static string ConstructHeader(List<string> header)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Prefix);

            bool first = true;
            foreach(var text in header)
            {
                if (!first)
                {
                    builder.Append(Separator);
                }
                first = false;
                builder.Append(text);
            }

            builder.Append(Suffix);
            return builder.ToString();
        }

        public static string Stringfy(ItemData value, List<string> header = null)
        {
            string name = "";
            StringBuilder output = new StringBuilder(10000);
            output.Append(Prefix);

            LanguageManager.ChangeLanguage("English");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("EnglishName")) header.Add("EnglishName");
            output.Append(Separator);

            LanguageManager.ChangeLanguage("Japanese");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("JapaneseName")) header.Add("JapaneseName");
            output.Append(Separator);

            try
            {
                name = "id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "id").ToString() + Separator);
                if (header != null && !header.Contains("id")) header.Add("id");

                name = "devPriority";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "devPriority").ToString() + Separator);
                if (header != null && !header.Contains("devPriority")) header.Add("devPriority");

                name = "status";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "status").ToString() + Separator);
                if (header != null && !header.Contains("status")) header.Add("status");

                name = "maxStack";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "maxStack").ToString() + Separator);
                if (header != null && !header.Contains("maxStack")) header.Add("maxStack");

                name = "price";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "price").ToString() + Separator);
                if (header != null && !header.Contains("price")) header.Add("price");

                name = "probInTreasureBox";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "probInTreasureBox").ToString() + Separator);
                if (header != null && !header.Contains("probInTreasureBox")) header.Add("probInTreasureBox");

                name = "rarity";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "rarity").ToString() + Separator);
                if (header != null && !header.Contains("rarity")) header.Add("rarity");

                name = "displayRarity";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "displayRarity").ToString() + Separator);
                if (header != null && !header.Contains("displayRarity")) header.Add("displayRarity");

                name = "categoryId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "categoryId").ToString() + Separator);
                if (header != null && !header.Contains("categoryId")) header.Add("categoryId");

                name = "familyId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "familyId").ToString() + Separator);
                if (header != null && !header.Contains("familyId")) header.Add("familyId");

                name = "inventoryTabId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "inventoryTabId").ToString() + Separator);
                if (header != null && !header.Contains("inventoryTabId")) header.Add("inventoryTabId");

                name = "workbenchId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "workbenchId").ToString() + Separator);
                if (header != null && !header.Contains("workbenchId")) header.Add("workbenchId");

                name = "workbenchLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "workbenchLv").ToString() + Separator);
                if (header != null && !header.Contains("workbenchLv")) header.Add("workbenchLv");

                name = "playerCraftCount";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "playerCraftCount").ToString() + Separator);
                if (header != null && !header.Contains("playerCraftCount")) header.Add("playerCraftCount");

                name = "carftTimeCost";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "carftTimeCost").ToString() + Separator);
                if (header != null && !header.Contains("carftTimeCost")) header.Add("carftTimeCost");

                name = "materialA_Id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialA_Id").ToString() + Separator);
                if (header != null && !header.Contains("materialA_Id")) header.Add("materialA_Id");

                name = "materialB_Id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialB_Id").ToString() + Separator);
                if (header != null && !header.Contains("materialB_Id")) header.Add("materialB_Id");

                name = "materialC_Id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialC_Id").ToString() + Separator);
                if (header != null && !header.Contains("materialC_Id")) header.Add("materialC_Id");

                name = "materialD_Id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialD_Id").ToString() + Separator);
                if (header != null && !header.Contains("materialD_Id")) header.Add("materialD_Id");

                name = "materialE_Id";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialE_Id").ToString() + Separator);
                if (header != null && !header.Contains("materialE_Id")) header.Add("materialE_Id");

                name = "materialA_count";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialA_count").ToString() + Separator);
                if (header != null && !header.Contains("materialA_count")) header.Add("materialA_count");

                name = "materialB_count";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialB_count").ToString() + Separator);
                if (header != null && !header.Contains("materialB_count")) header.Add("materialB_count");

                name = "materialC_count";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialC_count").ToString() + Separator);
                if (header != null && !header.Contains("materialC_count")) header.Add("materialC_count");

                name = "materialD_count";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialD_count").ToString() + Separator);
                if (header != null && !header.Contains("materialD_count")) header.Add("materialD_count");

                name = "materialE_count";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "materialE_count").ToString() + Separator);
                if (header != null && !header.Contains("materialE_count")) header.Add("materialE_count");

                name = "cooldownTime";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "cooldownTime").ToString() + Separator);
                if (header != null && !header.Contains("cooldownTime")) header.Add("cooldownTime");

                name = "effectiveTime";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "effectiveTime").ToString() + Separator);
                if (header != null && !header.Contains("effectiveTime")) header.Add("effectiveTime");

                name = "restoreHealth";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "restoreHealth").ToString() + Separator);
                if (header != null && !header.Contains("restoreHealth")) header.Add("restoreHealth");

                name = "restoreMana";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "restoreMana").ToString() + Separator);
                if (header != null && !header.Contains("restoreMana")) header.Add("restoreMana");

                name = "restoreSatiety";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "restoreSatiety").ToString() + Separator);
                if (header != null && !header.Contains("restoreSatiety")) header.Add("restoreSatiety");

                name = "addStamina";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "addStamina").ToString() + Separator);
                if (header != null && !header.Contains("addStamina")) header.Add("addStamina");

                name = "atk";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "atk").ToString() + Separator);
                if (header != null && !header.Contains("atk")) header.Add("atk");

                name = "atkIncreasePerLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "atkIncreasePerLv").ToString() + Separator);
                if (header != null && !header.Contains("atkIncreasePerLv")) header.Add("atkIncreasePerLv");

                name = "def";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "def").ToString() + Separator);
                if (header != null && !header.Contains("def")) header.Add("def");

                name = "defIncreasePerLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "defIncreasePerLv").ToString() + Separator);
                if (header != null && !header.Contains("defIncreasePerLv")) header.Add("defIncreasePerLv");

                name = "matk";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "matk").ToString() + Separator);
                if (header != null && !header.Contains("matk")) header.Add("matk");

                name = "matkIncreasePerLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "matkIncreasePerLv").ToString() + Separator);
                if (header != null && !header.Contains("matkIncreasePerLv")) header.Add("matkIncreasePerLv");

                name = "motionSpeed";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "motionSpeed").ToString() + Separator);
                if (header != null && !header.Contains("motionSpeed")) header.Add("motionSpeed");

                name = "durabilityValue";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "durabilityValue").ToString() + Separator);
                if (header != null && !header.Contains("durabilityValue")) header.Add("durabilityValue");

                name = "registFireLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "registFireLv").ToString() + Separator);
                if (header != null && !header.Contains("registFireLv")) header.Add("registFireLv");

                name = "registColdLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "registColdLv").ToString() + Separator);
                if (header != null && !header.Contains("registColdLv")) header.Add("registColdLv");

                name = "registPoisonLv";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "registPoisonLv").ToString() + Separator);
                if (header != null && !header.Contains("registPoisonLv")) header.Add("registPoisonLv");

                name = "enchantID";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "enchantID").ToString() + Separator);
                if (header != null && !header.Contains("enchantID")) header.Add("enchantID");

                name = "lootEnchantId_00";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "lootEnchantId_00").ToString() + Separator);
                if (header != null && !header.Contains("lootEnchantId_00")) header.Add("lootEnchantId_00");

                name = "lootEnchantId_01";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "lootEnchantId_01").ToString() + Separator);
                if (header != null && !header.Contains("lootEnchantId_01")) header.Add("lootEnchantId_01");

                name = "lootEnchantId_02";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "lootEnchantId_02").ToString() + Separator);
                if (header != null && !header.Contains("lootEnchantId_02")) header.Add("lootEnchantId_02");

                name = "lootEnchantId_03";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "lootEnchantId_03").ToString() + Separator);
                if (header != null && !header.Contains("lootEnchantId_03")) header.Add("lootEnchantId_03");

                name = "equipmentPassiveSkillId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "equipmentPassiveSkillId").ToString() + Separator);
                if (header != null && !header.Contains("equipmentPassiveSkillId")) header.Add("equipmentPassiveSkillId");

                name = "equipmentPassiveSkillLevel";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "equipmentPassiveSkillLevel").ToString() + Separator);
                if (header != null && !header.Contains("equipmentPassiveSkillLevel")) header.Add("equipmentPassiveSkillLevel");

                name = "equipmentActiveSkillId";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "equipmentActiveSkillId").ToString() + Separator);
                if (header != null && !header.Contains("equipmentActiveSkillId")) header.Add("equipmentActiveSkillId");

                name = "equipmentActiveSkillLevel";
                output.Append(AccessTools.FieldRefAccess<ItemData, int>(value, "equipmentActiveSkillLevel").ToString() + Separator);
                if (header != null && !header.Contains("equipmentActiveSkillLevel")) header.Add("equipmentActiveSkillLevel");

                name = "extraValue_A";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "extraValue_A").ToString() + Separator);
                if (header != null && !header.Contains("extraValue_A")) header.Add("extraValue_A");

                name = "extraValue_B";
                output.Append(AccessTools.FieldRefAccess<ItemData, float>(value, "extraValue_B").ToString() + Separator);
                if (header != null && !header.Contains("extraValue_B")) header.Add("extraValue_B");

                name = "activeSkillType";
                {
                    var field = AccessTools.FieldRefAccess<ItemData, OcPlActiveSkillType>(value, "activeSkillType");
                    try
                    {
                        int canCast = (int)field;
                        output.Append((OcPlActiveSkillType)canCast + Separator);
                        if (header != null && !header.Contains("activeSkillType")) header.Add("activeSkillType");
                    }
                    catch { }
                }

                name = "passiveSkillType";
                {
                    var field = AccessTools.FieldRefAccess<ItemData, OcPlPassiveSkillType>(value, "passiveSkillType");
                    try
                    {
                        int canCast = (int)field;
                        output.Append((OcPlPassiveSkillType)canCast);
                        if (header != null && !header.Contains("passiveSkillType")) header.Add("passiveSkillType");
                    }
                    catch { }
                }
            }
            catch
            {
                UnityEngine.Debug.Log("error in " + name);
                throw new Exception("error in " + name);
            }
            output.Append(Suffix);
            return output.ToString();
        }

        public static string Stringfy(SoEnchantment value, List<string> header = null)
        {
            string name = "";
            StringBuilder output = new StringBuilder(10000);
            output.Append(Prefix);

            LanguageManager.ChangeLanguage("English");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("EnglishName")) header.Add("EnglishName");
            output.Append(Separator);

            LanguageManager.ChangeLanguage("Japanese");
            output.Append(value.DisplayName);
            if (header != null && !header.Contains("JapaneseName")) header.Add("JapaneseName");
            output.Append(Separator);

            try
            {
                name = "id";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, int>(value, "id").ToString() + Separator);
                if (header != null && !header.Contains("id")) header.Add("id");

                name = "status";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, int>(value, "status").ToString() + Separator);
                if (header != null && !header.Contains("status")) header.Add("status");

                name = "rarity";
                {
                    var field = AccessTools.FieldRefAccess<SoEnchantment, EnchantRarity>(value, "rarity");
                    try
                    {
                        int canCast = (int)field;
                        output.Append((EnchantRarity)canCast + Separator);
                        if (header != null && !header.Contains("rarity")) header.Add("rarity");
                    }
                    catch { }
                }

                name = "limitedCategoryId";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, int>(value, "limitedCategoryId").ToString() + Separator);
                if (header != null && !header.Contains("limitedCategoryId")) header.Add("limitedCategoryId");

                name = "modify_Atk";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_Atk").ToString() + Separator);
                if (header != null && !header.Contains("modify_Atk")) header.Add("modify_Atk");

                name = "modify_AtkRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkRate")) header.Add("modify_AtkRate");

                name = "modify_Def";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_Def").ToString() + Separator);
                if (header != null && !header.Contains("modify_Def")) header.Add("modify_Def");

                name = "modify_DefRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DefRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_DefRate")) header.Add("modify_DefRate");

                name = "modify_MAtk";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MAtk").ToString() + Separator);
                if (header != null && !header.Contains("modify_MAtk")) header.Add("modify_MAtk");

                name = "modify_MAtkRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MAtkRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MAtkRate")) header.Add("modify_MAtkRate");

                name = "modify_MaxHp";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxHp").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxHp")) header.Add("modify_MaxHp");

                name = "modify_MaxHpRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxHpRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxHpRate")) header.Add("modify_MaxHpRate");

                name = "modify_MaxMp";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxMp").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxMp")) header.Add("modify_MaxMp");

                name = "modify_MaxMpRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxMpRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxMpRate")) header.Add("modify_MaxMpRate");

                name = "modify_MaxSp";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxSp").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxSp")) header.Add("modify_MaxSp");

                name = "modify_MaxSpRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxSpRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxSpRate")) header.Add("modify_MaxSpRate");

                name = "modify_MaxSt";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxSt").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxSt")) header.Add("modify_MaxSt");

                name = "modify_MaxStRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MaxStRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MaxStRate")) header.Add("modify_MaxStRate");

                name = "modify_CriticalDmgRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_CriticalDmgRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_CriticalDmgRate")) header.Add("modify_CriticalDmgRate");

                name = "modify_SpConsumeRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_SpConsumeRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_SpConsumeRate")) header.Add("modify_SpConsumeRate");

                name = "modify_StConsumeRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_StConsumeRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_StConsumeRate")) header.Add("modify_StConsumeRate");

                name = "modify_ManConsumeRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_ManConsumeRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_ManConsumeRate")) header.Add("modify_ManConsumeRate");

                name = "modify_StRecoverRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_StRecoverRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_StRecoverRate")) header.Add("modify_StRecoverRate");

                name = "modify_ManaRecoverRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_ManaRecoverRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_ManaRecoverRate")) header.Add("modify_ManaRecoverRate");

                name = "modify_SkillCoolDownRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_SkillCoolDownRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_SkillCoolDownRate")) header.Add("modify_SkillCoolDownRate");

                name = "modify_ItemCoolDownRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_ItemCoolDownRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_ItemCoolDownRate")) header.Add("modify_ItemCoolDownRate");

                name = "modify_CriticalProb";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_CriticalProb").ToString() + Separator);
                if (header != null && !header.Contains("modify_CriticalProb")) header.Add("modify_CriticalProb");

                name = "modify_ItemDropProb";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_ItemDropProb").ToString() + Separator);
                if (header != null && !header.Contains("modify_ItemDropProb")) header.Add("modify_ItemDropProb");

                name = "modify_PoisonProb";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_PoisonProb").ToString() + Separator);
                if (header != null && !header.Contains("modify_PoisonProb")) header.Add("modify_PoisonProb");

                name = "modify_FireProb";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_FireProb").ToString() + Separator);
                if (header != null && !header.Contains("modify_FireProb")) header.Add("modify_FireProb");

                name = "modify_MovementSpeedRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MovementSpeedRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MovementSpeedRate")) header.Add("modify_MovementSpeedRate");

                name = "modify_MotionSpeedRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_MotionSpeedRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_MotionSpeedRate")) header.Add("modify_MotionSpeedRate");

                name = "modify_JumpSpeedRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_JumpSpeedRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_JumpSpeedRate")) header.Add("modify_JumpSpeedRate");

                name = "modify_AtkUndead";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkUndead").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkUndead")) header.Add("modify_AtkUndead");

                name = "modify_DefUndead";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DefUndead").ToString() + Separator);
                if (header != null && !header.Contains("modify_DefUndead")) header.Add("modify_DefUndead");

                name = "modify_AtkIce";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkIce").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkIce")) header.Add("modify_AtkIce");

                name = "modify_DefIce";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DefIce").ToString() + Separator);
                if (header != null && !header.Contains("modify_DefIce")) header.Add("modify_DefIce");

                name = "modify_AtkFire";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkFire").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkFire")) header.Add("modify_AtkFire");

                name = "modify_DefFire";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DefFire").ToString() + Separator);
                if (header != null && !header.Contains("modify_DefFire")) header.Add("modify_DefFire");

                name = "modify_AtkBoss";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkBoss").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkBoss")) header.Add("modify_AtkBoss");

                name = "modify_DefBoss";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DefBoss").ToString() + Separator);
                if (header != null && !header.Contains("modify_DefBoss")) header.Add("modify_DefBoss");

                name = "modify_AtkAnimal";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_AtkAnimal").ToString() + Separator);
                if (header != null && !header.Contains("modify_AtkAnimal")) header.Add("modify_AtkAnimal");

                name = "modify_DamageCut";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_DamageCut").ToString() + Separator);
                if (header != null && !header.Contains("modify_DamageCut")) header.Add("modify_DamageCut");

                name = "modify_JumpCount";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_JumpCount").ToString() + Separator);
                if (header != null && !header.Contains("modify_JumpCount")) header.Add("modify_JumpCount");

                name = "modify_PriceRate";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "modify_PriceRate").ToString() + Separator);
                if (header != null && !header.Contains("modify_PriceRate")) header.Add("modify_PriceRate");

                name = "use_RestoreHealth";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "use_RestoreHealth").ToString() + Separator);
                if (header != null && !header.Contains("use_RestoreHealth")) header.Add("use_RestoreHealth");

                name = "use_RestoreMana";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "use_RestoreMana").ToString() + Separator);
                if (header != null && !header.Contains("use_RestoreMana")) header.Add("use_RestoreMana");

                name = "use_RestoreSatiety";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, float>(value, "use_RestoreSatiety").ToString() + Separator);
                if (header != null && !header.Contains("use_RestoreSatiety")) header.Add("use_RestoreSatiety");

                name = "equipmentPassiveSkillId";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, int>(value, "equipmentPassiveSkillId").ToString() + Separator);
                if (header != null && !header.Contains("equipmentPassiveSkillId")) header.Add("equipmentPassiveSkillId");

                name = "equipmentPassiveSkillLevel";
                output.Append(AccessTools.FieldRefAccess<SoEnchantment, int>(value, "equipmentPassiveSkillLevel").ToString());
                if (header != null && !header.Contains("equipmentPassiveSkillLevel")) header.Add("equipmentPassiveSkillLevel");
            }
            catch
            {
                UnityEngine.Debug.Log("error in " + name);
                throw new Exception("error in " + name);
            }
            output.Append(Suffix);
            return output.ToString();
        }

        public static string Stringfy(SoEnemyData value, List<string> header = null)
        {
            string name = "";
            StringBuilder output = new StringBuilder(10000);
            output.Append(Prefix);

            LanguageManager.ChangeLanguage("English");
            output.Append(value.name);
            if (header != null && !header.Contains("EnglishName")) header.Add("EnglishName");
            output.Append(Separator);

            LanguageManager.ChangeLanguage("Japanese");
            output.Append(value.name);
            if (header != null && !header.Contains("JapaneseName")) header.Add("JapaneseName");
            output.Append(Separator);

            try
            {
                name = "id";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "id").ToString() + Separator);
                if (header != null && !header.Contains("id")) header.Add("id");

                name = "poolsize";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "poolsize").ToString() + Separator);
                if (header != null && !header.Contains("poolsize")) header.Add("poolsize");

                name = "rarity";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "rarity").ToString() + Separator);
                if (header != null && !header.Contains("rarity")) header.Add("rarity");

                name = "health";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "health").ToString() + Separator);
                if (header != null && !header.Contains("health")) header.Add("health");

                name = "attack";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "attack").ToString() + Separator);
                if (header != null && !header.Contains("attack")) header.Add("attack");

                name = "defence";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "defence").ToString() + Separator);
                if (header != null && !header.Contains("defence")) header.Add("defence");

                name = "uniqueEnchantId_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "uniqueEnchantId_00").ToString() + Separator);
                if (header != null && !header.Contains("uniqueEnchantId_00")) header.Add("uniqueEnchantId_00");

                name = "uniqueEnchantId_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "uniqueEnchantId_01").ToString() + Separator);
                if (header != null && !header.Contains("uniqueEnchantId_01")) header.Add("uniqueEnchantId_01");

                name = "capturedItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "capturedItemId").ToString() + Separator);
                if (header != null && !header.Contains("capturedItemId")) header.Add("capturedItemId");

                name = "fireItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "fireItemId").ToString() + Separator);
                if (header != null && !header.Contains("fireItemId")) header.Add("fireItemId");

                name = "stockFarmItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "stockFarmItemId").ToString() + Separator);
                if (header != null && !header.Contains("stockFarmItemId")) header.Add("stockFarmItemId");

                name = "damageThresholdForDropItem";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "damageThresholdForDropItem").ToString() + Separator);
                if (header != null && !header.Contains("damageThresholdForDropItem")) header.Add("damageThresholdForDropItem");

                name = "d00_dropItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d00_dropItemId").ToString() + Separator);
                if (header != null && !header.Contains("d00_dropItemId")) header.Add("d00_dropItemId");

                name = "d00_dropItemNum";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d00_dropItemNum").ToString() + Separator);
                if (header != null && !header.Contains("d00_dropItemNum")) header.Add("d00_dropItemNum");

                name = "d00_dropRate";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d00_dropRate").ToString() + Separator);
                if (header != null && !header.Contains("d00_dropRate")) header.Add("d00_dropRate");

                name = "d00_enchantRate_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d00_enchantRate_00").ToString() + Separator);
                if (header != null && !header.Contains("d00_enchantRate_00")) header.Add("d00_enchantRate_00");

                name = "d00_enchantRate_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d00_enchantRate_01").ToString() + Separator);
                if (header != null && !header.Contains("d00_enchantRate_01")) header.Add("d00_enchantRate_01");

                name = "d01_dropItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d01_dropItemId").ToString() + Separator);
                if (header != null && !header.Contains("d01_dropItemId")) header.Add("d01_dropItemId");

                name = "d01_dropItemNum";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d01_dropItemNum").ToString() + Separator);
                if (header != null && !header.Contains("d01_dropItemNum")) header.Add("d01_dropItemNum");

                name = "d01_dropRate";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d01_dropRate").ToString() + Separator);
                if (header != null && !header.Contains("d01_dropRate")) header.Add("d01_dropRate");

                name = "d01_enchantRate_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d01_enchantRate_00").ToString() + Separator);
                if (header != null && !header.Contains("d01_enchantRate_00")) header.Add("d01_enchantRate_00");

                name = "d01_enchantRate_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d01_enchantRate_01").ToString() + Separator);
                if (header != null && !header.Contains("d01_enchantRate_01")) header.Add("d01_enchantRate_01");

                name = "d02_dropItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d02_dropItemId").ToString() + Separator);
                if (header != null && !header.Contains("d02_dropItemId")) header.Add("d02_dropItemId");

                name = "d02_dropItemNum";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d02_dropItemNum").ToString() + Separator);
                if (header != null && !header.Contains("d02_dropItemNum")) header.Add("d02_dropItemNum");

                name = "d02_dropRate";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d02_dropRate").ToString() + Separator);
                if (header != null && !header.Contains("d02_dropRate")) header.Add("d02_dropRate");

                name = "d02_enchantRate_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d02_enchantRate_00").ToString() + Separator);
                if (header != null && !header.Contains("d02_enchantRate_00")) header.Add("d02_enchantRate_00");

                name = "d02_enchantRate_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d02_enchantRate_01").ToString() + Separator);
                if (header != null && !header.Contains("d02_enchantRate_01")) header.Add("d02_enchantRate_01");

                name = "d03_dropItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d03_dropItemId").ToString() + Separator);
                if (header != null && !header.Contains("d03_dropItemId")) header.Add("d03_dropItemId");

                name = "d03_dropItemNum";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "d03_dropItemNum").ToString() + Separator);
                if (header != null && !header.Contains("d03_dropItemNum")) header.Add("d03_dropItemNum");

                name = "d03_dropRate";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d03_dropRate").ToString() + Separator);
                if (header != null && !header.Contains("d03_dropRate")) header.Add("d03_dropRate");

                name = "d03_enchantRate_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d03_enchantRate_00").ToString() + Separator);
                if (header != null && !header.Contains("d03_enchantRate_00")) header.Add("d03_enchantRate_00");

                name = "d03_enchantRate_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "d03_enchantRate_01").ToString() + Separator);
                if (header != null && !header.Contains("d03_enchantRate_01")) header.Add("d03_enchantRate_01");

                name = "produceItemId";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, int>(value, "produceItemId").ToString() + Separator);
                if (header != null && !header.Contains("produceItemId")) header.Add("produceItemId");

                name = "produce_enchantRate_00";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "produce_enchantRate_00").ToString() + Separator);
                if (header != null && !header.Contains("produce_enchantRate_00")) header.Add("produce_enchantRate_00");

                name = "produce_enchantRate_01";
                output.Append(AccessTools.FieldRefAccess<SoEnemyData, float>(value, "produce_enchantRate_01").ToString());
                if (header != null && !header.Contains("produce_enchantRate_01")) header.Add("produce_enchantRate_01");
            }
            catch
            {
                UnityEngine.Debug.Log("error in " + name);
                throw new Exception("error in " + name);
            }
            output.Append(Suffix);
            return output.ToString();
        }
    }
}
