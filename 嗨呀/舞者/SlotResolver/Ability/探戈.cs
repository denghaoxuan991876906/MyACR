using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 探戈 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 62) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.探戈)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DNCHelper.进攻之探戈) > 0) return (int)CheckResult.冷却中;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (!DNCHelper.HasTechnicalFinish) return (int)CheckResult.状态不符;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.进攻之探戈, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
