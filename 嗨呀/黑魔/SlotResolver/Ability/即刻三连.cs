using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 即刻三连 : ISlotResolver
{
    public int Check()
    {
        if (!BLM_BattleData.Instance.需要即刻) return (int)CheckResult.状态不符;

        if (BLMHelper.可瞬发)
        {
            BLM_BattleData.Instance.需要即刻 = false;
            return (int)CheckResult.状态不符;
        }

        if (CooldownHelper.GetCharges(BLMHelper.三连咏唱) >= 1) return 1;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.即可咏唱) <= 0) return 1;

        return (int)CheckResult.技能未就绪;
    }

    public void Build(Slot slot)
    {
        BLM_BattleData.Instance.需要即刻 = false;

        if (CooldownHelper.GetCharges(BLMHelper.三连咏唱) >= 1)
            slot.Add(new Spell { Id = BLMHelper.三连咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
        else
            slot.Add(new Spell { Id = BLMHelper.即可咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
