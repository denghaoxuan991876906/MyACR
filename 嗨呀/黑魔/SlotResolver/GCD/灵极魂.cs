using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 灵极魂 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 35) return (int)CheckResult.等级不足;

        if (!BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (BLMHelper.冰层数 >= 3 && BLMHelper.冰针数 >= 3 && Data.Me.Object?.CurrentMp >= 10000)
            return (int)CheckResult.资源不足;

        if (SpellHistoryHelper.RecentlyUsed(BLMHelper.灵极魂, 3000)) return (int)CheckResult.最近已用;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.灵极魂, TargetType = SpellTargetType.Self, Type = SpellType.RealGcd });
    }
}
