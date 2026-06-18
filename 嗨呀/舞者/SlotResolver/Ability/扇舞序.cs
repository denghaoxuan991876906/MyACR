using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.Ability;

public class 扇舞序 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 30) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.扇舞)) return (int)CheckResult.QT关闭;

        if (DNCHelper.FeathersCount < 1) return (int)CheckResult.资源不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标)
            return (int)DNCHelper.扇舞破;
        return (int)DNCHelper.扇舞序;
    }

    public void Build(Slot slot)
    {
        var id = QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标
            ? DNCHelper.扇舞破
            : DNCHelper.扇舞序;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
