using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 高级循环_绝望 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 72) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.高级循环)) return (int)CheckResult.QT关闭;
        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        var bd = BLM_BattleData.Instance;
        if (!bd.高级循环_星灵已完成) return (int)CheckResult.状态不符;
        if (bd.高级循环_读条冰澈Gcd != BLMHelper.冰澈) return (int)CheckResult.状态不符;
        if (bd.前一能力技 != BLMHelper.星灵移位) return (int)CheckResult.状态不符;
        if (bd.前一gcd != bd.高级循环_读条冰澈Gcd) return (int)CheckResult.状态不符;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (mp < 800) return (int)CheckResult.资源不足;

        if (GameHelper.GetCurrentLevel() < 100 && Data.Me.IsMoving && !BLMHelper.可瞬发)
            return (int)CheckResult.移动中;

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.绝望, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
