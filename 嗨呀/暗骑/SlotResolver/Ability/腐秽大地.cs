using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.Ability;

public class 腐秽大地 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 52) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.腐秽大地)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DRKHelper.腐秽大地) > 0) return (int)CheckResult.冷却中;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.腐秽大地, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
