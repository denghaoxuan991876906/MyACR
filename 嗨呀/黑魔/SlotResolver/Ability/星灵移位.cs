using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 星灵移位 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 4) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.星灵移位) > 0) return (int)CheckResult.冷却中;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (BLMHelper.火状态)
        {
            if (CooldownHelper.GetCooldownRemaining(BLMHelper.魔泉) <= 0 && QTHelper.IsEnabled("墨泉"))
                return (int)CheckResult.状态不符;

            if (Data.Me.Object?.CurrentMp >= 800 && BLMHelper.耀星层数 < 6) return (int)CheckResult.状态不符;

            if (BLMHelper.可瞬发) return 1;

            if (CooldownHelper.GetCharges(BLMHelper.三连咏唱) >= 1 ||
                CooldownHelper.GetCooldownRemaining(BLMHelper.即可咏唱) <= 0)
                return 1;
        }

        if (BLMHelper.冰状态)
        {
            if (BLMHelper.冰层数 != 3 || BLMHelper.冰针数 < 3) return (int)CheckResult.状态不符;

            if (BLMHelper.悖论指示 && BLMHelper.可瞬发) return 1;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.星灵移位, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
