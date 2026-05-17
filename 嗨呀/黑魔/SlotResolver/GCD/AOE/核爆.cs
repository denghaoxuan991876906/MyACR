using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD.AOE;

public class 核爆 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 50) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (Data.Me.Object?.CurrentMp < 800)
        {
            if (BLMHelper.耀星层数 == 6) return (int)BLMHelper.核爆;

            if (BLMHelper.冰状态) return (int)CheckResult.状态不符;

            return (int)CheckResult.资源不足;
        }

        return (int)BLMHelper.核爆;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.核爆, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
