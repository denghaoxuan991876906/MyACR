using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 龙剑 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 30) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(DRGHelper.龙剑) < 1) return (int)CheckResult.冷却中;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        if (DRGHelper.龙剑激活) return (int)CheckResult.状态不符;

        var lastCombo = ComboHelper.LastComboSpellId;
        var isFinisher = lastCombo == DRGHelper.直刺 || lastCombo == DRGHelper.苍穹刺 ||
                         lastCombo == DRGHelper.樱花怒放 || lastCombo == DRGHelper.樱花缭乱 ||
                         lastCombo == DRGHelper.龙牙龙爪 || lastCombo == DRGHelper.龙尾大回旋;

        if (!isFinisher) return (int)CheckResult.状态不符;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.龙剑, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
