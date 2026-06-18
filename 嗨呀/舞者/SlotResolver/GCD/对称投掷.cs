using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 对称投掷 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 20) return (int)CheckResult.等级不足;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (!AuraHelper.HasSelfAura(DNCHelper.对称投掷buff)) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标)
            return (int)DNCHelper.升风车;
        return (int)DNCHelper.逆瀑泻;
    }

    public void Build(Slot slot)
    {
        var id = QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标
            ? DNCHelper.升风车
            : DNCHelper.逆瀑泻;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
