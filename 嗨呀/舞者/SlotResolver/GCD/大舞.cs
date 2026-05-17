using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 大舞 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 70) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.大舞)) return (int)CheckResult.QT关闭;

        if (DNCHelper.HasTechnicalFinish) return (int)CheckResult.状态不符;

        if (DNCHelper.IsDancing)
        {
            var action = HelperRuntime.GetActionChange(DNCHelper.技巧舞步);
            if (action != DNCHelper.技巧舞步) return (int)action;
            return (int)CheckResult.状态不符;
        }

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DNCHelper.技巧舞步) > 0) return (int)CheckResult.冷却中;

        return (int)DNCHelper.技巧舞步;
    }

    public void Build(Slot slot)
    {
        var id = DNCHelper.IsDancing
            ? HelperRuntime.GetActionChange(DNCHelper.技巧舞步)
            : DNCHelper.技巧舞步;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Self, Type = SpellType.RealGcd });
    }
}
