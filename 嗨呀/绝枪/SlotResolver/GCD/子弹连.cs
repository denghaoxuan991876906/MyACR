using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 子弹连 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.子弹连)) return (int)CheckResult.QT关闭;

        if (!GNBHelper.Has无情 && HelperRuntime.GetCurrentLevel() >= 38) return (int)CheckResult.状态不符;

        var bd = 绝枪_BattleData.Instance;

        if (bd.子弹连步骤 == 2 && GNBHelper.续剑激活)
        {
            if (ComboHelper.LastComboSpellId == GNBHelper.猛兽爪)
                return (int)GNBHelper.凶禽爪;
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.凶禽爪;
        }

        if (bd.子弹连步骤 == 1 && GNBHelper.续剑激活)
        {
            if (ComboHelper.LastComboSpellId == GNBHelper.烈牙)
                return (int)GNBHelper.猛兽爪;
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.猛兽爪;
        }

        if (bd.子弹连步骤 == 0 && GNBHelper.HasCartridge && GNBHelper.Has无情)
        {
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.烈牙;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        var id = Check();
        if (id < 0) return;
        var spellId = (uint)id;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
