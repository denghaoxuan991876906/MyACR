using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 详述 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 86) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.详述) > 0) return (int)CheckResult.冷却中;

        var level = HelperRuntime.GetCurrentLevel();
        if (level >= 98)
        {
            if (BLMHelper.通晓数 >= 2) return (int)CheckResult.资源不足;
        }
        else
        {
            if (BLMHelper.通晓数 >= 1) return (int)CheckResult.资源不足;
        }

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.详述, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
