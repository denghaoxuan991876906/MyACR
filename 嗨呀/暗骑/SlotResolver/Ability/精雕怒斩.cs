using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.Ability;

public class 精雕怒斩 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 56) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.精雕怒斩)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DRKHelper.精雕怒斩) > 0) return (int)CheckResult.冷却中;

        if (Data.Target.Current != null && Data.Me.Object?.Distance(Data.Target.Current) > 5) return (int)CheckResult.目标无效;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRKHelper.精雕怒斩, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
