using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.Ability;

public class 血乱 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 68) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.血乱)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DRKHelper.血乱) > 0) return (int)CheckResult.冷却中;

        if (DRKHelper.血乱激活) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.血乱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
