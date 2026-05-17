using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 墨泉 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 30) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled("墨泉")) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.魔泉) > 0) return (int)CheckResult.冷却中;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (Data.Me.Object?.CurrentMp > 800 || BLMHelper.耀星层数 == 6) return (int)CheckResult.资源不足;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.魔泉, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
