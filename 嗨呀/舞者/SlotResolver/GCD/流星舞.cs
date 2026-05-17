using 嗨呀.舞者.SlotResolver.DNCData;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 流星舞 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 92) return (int)CheckResult.等级不足;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (!AuraHelper.HasSelfAura(DNCHelper.流星舞预备buff)) return (int)CheckResult.状态不符;

        return (int)DNCHelper.流星舞;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.流星舞, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
