using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 牵制 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 22) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.自动减伤)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Mitigation)) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCooldownRemaining(DRGHelper.牵制) > 0) return (int)CheckResult.冷却中;

        if ((Data.Target.Current as IBattleChara)?.IsCasting == true) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.牵制, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
