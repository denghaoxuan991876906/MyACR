using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.Ability;

public class 血壤 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 68) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.血壤)) return (int)CheckResult.QT关闭;

        if (!Data.Combat.InCombat) return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(GNBHelper.血壤) > 0) return (int)CheckResult.冷却中;

        if (GNBHelper.CartridgeCount >= 2) return (int)CheckResult.资源不足;

        if (GameHelper.GetGCDCooldown() > 600) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.血壤, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
