using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 即刻 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 18) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.即可咏唱) > 0) return (int)CheckResult.冷却中;

        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled("TTK")) return 999;

        if (BLMHelper.冰状态 && BLMHelper.冰层数 < 3) return 1;

        if (BLMHelper.群怪模式 && BLMHelper.火状态 && BLMHelper.耀星层数 == 6) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.即可咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
