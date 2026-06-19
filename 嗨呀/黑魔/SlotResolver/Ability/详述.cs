using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 详述 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 86) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.详述)) return (int)CheckResult.QT关闭;
        if (!SpellHelper.CanUseSpell(BLMHelper.详述)) return (int)CheckResult.冷却中;
        if (GameHelper.GetCurrentLevel() >= 98)
        {
            if (BLMHelper.通晓数 >= 3) return (int)CheckResult.状态不符;
            if (BLMHelper.通晓数 == 2 && BLMHelper.通晓计时 < 4000) return (int)CheckResult.状态不符;
        }
        else
        {
            if (BLMHelper.通晓数 >= 2) return (int)CheckResult.状态不符;
            if (BLMHelper.通晓数 == 1 && BLMHelper.通晓计时 < 4000) return (int)CheckResult.状态不符;
        }

        if (GameHelper.GetGCDCooldown() < 500) return (int)CheckResult.技能未就绪;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.详述, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}


