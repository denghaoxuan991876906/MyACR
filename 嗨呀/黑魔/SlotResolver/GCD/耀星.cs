using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 耀星 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 100) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (BLMHelper.耀星层数 != 6) return (int)CheckResult.资源不足;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        return (int)BLMHelper.耀星;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.耀星, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
