using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 黑魔纹 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 52) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled("黑魔纹")) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(BLMHelper.黑魔纹) < 1) return (int)CheckResult.冷却中;

        if (AuraHelper.HasSelfAura(BLMHelper.魔纹存在buff)) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        if (QTHelper.IsEnabled("TTK")) return (int)CheckResult.特殊循环中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.黑魔纹, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
