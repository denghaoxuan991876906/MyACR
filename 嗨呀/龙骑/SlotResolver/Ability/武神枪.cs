using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 武神枪 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (!DRGHelper.龙威激活) return (int)CheckResult.状态不符;

        if (!DRGHelper.武神枪预备) return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(DRGHelper.武神枪) > 0) return (int)CheckResult.冷却中;

        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.武神枪, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
