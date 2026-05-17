using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 百花 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 20) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.百花)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DNCHelper.百花争艳) > 0) return (int)CheckResult.冷却中;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.百花争艳, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
