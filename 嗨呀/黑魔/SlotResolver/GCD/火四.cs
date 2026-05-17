using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火四 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (Data.Me.Object?.CurrentMp < 1600) return (int)CheckResult.资源不足;

        return (int)HelperRuntime.GetActionChange(BLMHelper.炽焰);
    }

    public void Build(Slot slot)
    {
        var spellId = HelperRuntime.GetActionChange(BLMHelper.炽焰);
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
