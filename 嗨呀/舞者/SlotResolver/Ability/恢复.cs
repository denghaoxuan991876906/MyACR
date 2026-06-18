using 嗨呀.舞者.SlotResolver.DNCData;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 恢复 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 52) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(BuiltinQt.Mitigation)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DNCHelper.治疗之华尔兹) > 0) return (int)CheckResult.冷却中;

        if (!舞者_BattleData.Instance.需应急治疗) return (int)CheckResult.状态不符;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.治疗之华尔兹, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
