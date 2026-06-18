using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.Ability;

public class 无情 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 38) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.无情)) return (int)CheckResult.QT关闭;

        if (!Data.Combat.InCombat) return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(GNBHelper.无情技能) > 0) return (int)CheckResult.冷却中;

        if (GameHelper.GetGCDCooldown() > 600) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.无情技能, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
