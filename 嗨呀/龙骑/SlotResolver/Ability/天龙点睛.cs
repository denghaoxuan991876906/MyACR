using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 天龙点睛 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 70) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(DRGHelper.天龙点睛) < 1) return (int)CheckResult.冷却中;

        if (HelperRuntime.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        if (!DRGHelper.龙威激活) return (int)CheckResult.状态不符;

        var lastCombo = ComboHelper.LastComboSpellId;
        if (lastCombo == DRGHelper.云蒸龙变) return 1;

        if (DRGHelper.猛枪激活) return 2;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.天龙点睛, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
