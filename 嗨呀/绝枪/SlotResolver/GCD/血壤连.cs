using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 血壤连 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 86) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.血壤连)) return (int)CheckResult.QT关闭;

        var bd = 绝枪_BattleData.Instance;

        if (bd.血壤连步骤 == 2 && HelperRuntime.HasStatus(3840))
        {
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.终结之心;
        }

        if (bd.血壤连步骤 == 1 && HelperRuntime.HasStatus(3840))
        {
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.支配之心;
        }

        if (bd.血壤连步骤 == 0 && GNBHelper.血壤激活)
        {
            if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;
            return (int)GNBHelper.崛起之心;
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
