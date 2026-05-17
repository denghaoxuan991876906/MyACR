using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 绝望 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 72) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        var mp = Data.Me.Object?.CurrentMp;
        if (mp < 800 || mp >= 2400) return (int)CheckResult.资源不足;

        if (HelperRuntime.GetCurrentLevel() >= 100 && BLMHelper.耀星层数 >= 5) return (int)CheckResult.资源不足;

        return (int)BLMHelper.绝望;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.绝望, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
