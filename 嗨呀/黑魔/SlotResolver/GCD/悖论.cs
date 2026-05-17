using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 悖论 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 90) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (!BLMHelper.悖论指示) return (int)CheckResult.资源不足;

        if (BLMHelper.火状态 && Data.Me.Object?.CurrentMp < 2400) return (int)CheckResult.资源不足;

        return (int)BLMHelper.悖论;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.悖论, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
