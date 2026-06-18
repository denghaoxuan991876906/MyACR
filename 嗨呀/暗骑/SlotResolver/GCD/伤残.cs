using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class 伤残 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 15) return (int)CheckResult.等级不足;

        if (Data.Me.Object?.IsDead == true) return (int)CheckResult.目标无效;

        if (Data.Target.Current == null) return (int)CheckResult.目标无效;

        var distance = Data.Me.Object?.Distance(Data.Target.Current) ?? 99;
        if (distance <= 6) return (int)CheckResult.状态不符;

        return (int)DRKHelper.伤残;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.伤残, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
