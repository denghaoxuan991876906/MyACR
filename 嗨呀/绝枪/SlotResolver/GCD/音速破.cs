using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 音速破 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 58) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.音速破)) return (int)CheckResult.QT关闭;

        if (!GNBHelper.Has无情) return (int)CheckResult.状态不符;

        if (HelperRuntime.HasStatusOnTarget(3161)) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;

        return (int)GNBHelper.音速破;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.音速破, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
