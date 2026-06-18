using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.Ability;

public class 掠影 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 80) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.掠影)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(DRKHelper.掠影示现) < 1) return (int)CheckResult.冷却中;

        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.掠影示现, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
