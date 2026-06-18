using 嗨呀.舞者.SlotResolver.DNCData;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 落幕舞 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 96) return (int)CheckResult.等级不足;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (!AuraHelper.HasSelfAura(DNCHelper.落幕舞预备buff)) return (int)CheckResult.状态不符;

        return (int)DNCHelper.落幕舞;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.落幕舞, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
