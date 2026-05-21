using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 绝望 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 72) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发 && HelperRuntime.GetCurrentLevel() < 100) return (int)CheckResult.移动中;

        var mp = Data.Me.Object?.CurrentMp;
        if (mp < 800) return (int)CheckResult.资源不足;

        var bd = BLM_BattleData.Instance;
        if (QTHelper.IsEnabled(QTKey.高级循环) && BLMHelper.火状态
            && bd.前一gcd == BLMHelper.冰澈 && !bd.已使用瞬发)
            return (int)BLMHelper.绝望;

        if (HelperRuntime.GetCurrentLevel() >= 100 && !bd.火阶段已放耀星)
            return (int)CheckResult.状态不符;

        return (int)BLMHelper.绝望;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.绝望, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
