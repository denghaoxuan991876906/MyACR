using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 昏乱 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 8) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.昏乱) > 0) return (int)CheckResult.冷却中;

        if ((Data.Target.Current as IBattleChara)?.IsCasting == true) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.昏乱, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
