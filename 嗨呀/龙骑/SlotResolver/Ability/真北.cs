using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 真北 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 50) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.真北)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(DRGHelper.真北) < 1) return (int)CheckResult.冷却中;

        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        var lastCombo = ComboHelper.LastComboSpellId;
        var willUsePositional = lastCombo == DRGHelper.直刺 || lastCombo == DRGHelper.苍穹刺 ||
                                lastCombo == DRGHelper.樱花怒放 || lastCombo == DRGHelper.樱花缭乱;

        if (!willUsePositional) return (int)CheckResult.状态不符;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.真北, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
