using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 小舞 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 15) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.小舞)) return (int)CheckResult.QT关闭;

        if (DNCHelper.HasStandardFinish) return (int)CheckResult.状态不符;

        if (DNCHelper.IsDancing)
        {
            var action = HelperRuntime.GetActionChange(DNCHelper.标准舞步);
            if (action != DNCHelper.标准舞步) return (int)action;
            return (int)CheckResult.状态不符;
        }

        return (int)DNCHelper.标准舞步;
    }

    public void Build(Slot slot)
    {
        var id = DNCHelper.IsDancing
            ? HelperRuntime.GetActionChange(DNCHelper.标准舞步)
            : DNCHelper.标准舞步;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Self, Type = SpellType.RealGcd });
    }
}
