using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD.AOE;

public class 玄冰 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 40) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (!BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (BLMHelper.冰针数 >= 3) return (int)CheckResult.资源不足;

        if (BLMHelper.冰层数 < 3) return (int)CheckResult.状态不符;

        return (int)BLMHelper.玄冰;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.玄冰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
