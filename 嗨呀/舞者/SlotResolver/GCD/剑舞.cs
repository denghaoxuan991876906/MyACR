using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 剑舞 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 76) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.剑舞)) return (int)CheckResult.QT关闭;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (DNCHelper.EspritGauge < 50) return (int)CheckResult.资源不足;

        return (int)DNCHelper.剑舞;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.剑舞, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
