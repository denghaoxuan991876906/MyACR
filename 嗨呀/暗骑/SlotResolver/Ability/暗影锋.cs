using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.Ability;

public class 暗影锋 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 74) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.暗影锋)) return (int)CheckResult.QT关闭;

        if (QTHelper.IsEnabled(QTKey.AOE) && DRKHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.Object?.CurrentMp < 3000) return (int)CheckResult.资源不足;

        if (!QTHelper.IsEnabled(QTKey.爆发) && !DRKHelper.血乱激活 && !DRKHelper.嗜血激活)
            return (int)CheckResult.状态不符;

        if (CooldownHelper.GetCooldownRemaining(DRKHelper.暗影锋) > 0) return (int)CheckResult.冷却中;

        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.暗影锋, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
