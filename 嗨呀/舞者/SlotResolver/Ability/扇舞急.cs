using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 扇舞急 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 66) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.扇舞)) return (int)CheckResult.QT关闭;

        if (DNCHelper.FeathersCount < 1) return (int)CheckResult.资源不足;

        if (!AuraHelper.HasSelfAura(DNCHelper.进攻之探戈buff)) return (int)CheckResult.状态不符;

        return (int)DNCHelper.扇舞急;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DNCHelper.扇舞急, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
