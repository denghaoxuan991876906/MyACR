using 嗨呀.舞者.SlotResolver.DNCData;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 提拉纳 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 90) return (int)CheckResult.等级不足;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (!AuraHelper.HasSelfAura(DNCHelper.百花争艳buff)) return (int)CheckResult.状态不符;

        return (int)DNCHelper.提拉纳;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.提拉纳, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
