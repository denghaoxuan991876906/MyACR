using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 醒梦 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 14) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.醒梦) > 0) return (int)CheckResult.冷却中;

        if (QTHelper.IsEnabled("TTK")) return 999;

        if (Data.Me.Object?.CurrentMp < 8000) return 1;

        return (int)CheckResult.资源不足;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.醒梦, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
