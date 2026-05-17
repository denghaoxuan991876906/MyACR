using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.Ability;

public class 弓形冲波 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 62) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.弓形冲波)) return (int)CheckResult.QT关闭;

        if (!Data.Combat.InCombat) return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(GNBHelper.弓形冲波) > 0) return (int)CheckResult.冷却中;

        if (!GNBHelper.Has无情) return (int)CheckResult.状态不符;

        var count = HelperRuntime.GetNearbyEnemyCount(5);
        if (count < 1) return (int)CheckResult.目标无效;

        if (HelperRuntime.GetGCDCooldown() > 600) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.弓形冲波, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
