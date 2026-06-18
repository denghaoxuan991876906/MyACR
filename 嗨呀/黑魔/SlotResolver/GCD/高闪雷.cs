using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 高闪雷 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 92) return (int)CheckResult.等级不足;
        if (!BLMHelper.Has雷云) return (int)CheckResult.状态不符;
        if (!QTHelper.IsEnabled(QTKey.Dot)) return (int)CheckResult.QT关闭;
        if (!BLMHelper.补dot()) return (int)CheckResult.状态不符;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.高闪雷, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
