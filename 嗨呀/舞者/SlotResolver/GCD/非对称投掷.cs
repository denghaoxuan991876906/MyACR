using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 非对称投掷 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 20) return (int)CheckResult.等级不足;

        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (!AuraHelper.HasSelfAura(DNCHelper.非对称投掷buff)) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标)
            return (int)DNCHelper.落血雨;
        return (int)DNCHelper.坠喷泉;
    }

    public void Build(Slot slot)
    {
        var id = QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标
            ? DNCHelper.落血雨
            : DNCHelper.坠喷泉;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
