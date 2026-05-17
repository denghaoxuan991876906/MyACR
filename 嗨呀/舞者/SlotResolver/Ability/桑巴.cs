using 嗨呀.舞者.SlotResolver.DNCData;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 桑巴 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 56) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(BuiltinQt.Mitigation)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DNCHelper.防守之桑巴) > 0) return (int)CheckResult.冷却中;

        if ((Data.Target.Current as IBattleChara)?.IsCasting == true) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.防守之桑巴, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
