using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class 蔑视 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 100) return (int)CheckResult.等级不足;

        if (!DRKHelper.蔑视激活) return (int)CheckResult.状态不符;

        return (int)DRKHelper.蔑视;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.蔑视, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
