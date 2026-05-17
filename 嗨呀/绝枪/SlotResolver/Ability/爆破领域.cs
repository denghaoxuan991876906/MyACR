using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.Ability;

public class 爆破领域 : ISlotResolver
{
    public int Check()
    {
        if (Data.Target.Current == null) return (int)CheckResult.目标无效;

        if (!QTHelper.IsEnabled(QTKey.爆破领域)) return (int)CheckResult.QT关闭;

        if (!Data.Combat.InCombat) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetCurrentLevel() >= 80)
        {
            if (CooldownHelper.GetCooldownRemaining(GNBHelper.爆破领域) > 0) return (int)CheckResult.冷却中;
        }
        else if (HelperRuntime.GetCurrentLevel() >= 58)
        {
            if (CooldownHelper.GetCooldownRemaining(GNBHelper.危险领域) > 0) return (int)CheckResult.冷却中;
        }
        else
        {
            return (int)CheckResult.等级不足;
        }

        if (HelperRuntime.GetGCDCooldown() > 600) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        var spellId = HelperRuntime.GetCurrentLevel() >= 80 ? GNBHelper.爆破领域 : GNBHelper.危险领域;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
