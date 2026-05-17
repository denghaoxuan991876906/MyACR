using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 渡星冲 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 96) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (!DRGHelper.渡星冲预备) return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(DRGHelper.渡星冲) > 0) return (int)CheckResult.冷却中;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.渡星冲, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
