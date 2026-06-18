using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class 暗血技能 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 35) return (int)CheckResult.等级不足;

        if (DRKHelper.血乱激活) return (int)CheckResult.状态不符;

        if (DRKHelper.BloodGauge < 50) return (int)CheckResult.资源不足;

        return (int)DRKHelper.血溅;
    }

    public void Build(Slot slot)
    {
        var id = QTHelper.IsEnabled(QTKey.AOE) && DRKHelper.群怪模式 ? DRKHelper.寂灭 : DRKHelper.血溅;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
