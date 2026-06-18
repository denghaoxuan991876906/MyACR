using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 秽浊 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 80) return (int)CheckResult.等级不足;
        if (!BLMHelper.三目标aoe()) return (int)CheckResult.状态不符; // 单体走异言
        if (BLMHelper.通晓数 < 1) return (int)CheckResult.资源不足;
        if (!QTHelper.IsEnabled(QTKey.通晓)) return (int)CheckResult.QT关闭;

        // 清空资源强制释放
        if (QTHelper.IsEnabled(BuiltinQt.Dump)) return 0;

        // 正常：100级时3层通晓 且 (通晓剩余<10s 或 详述快转好<1.5s)
        if (GameHelper.GetCurrentLevel() >= 100 && BLMHelper.通晓数 >= 3)
        {
            if (BLMHelper.通晓计时 < 10000) return 0;
            if (SpellHelper.GetCooldownRemaining(BLMHelper.详述) < 1500) return 0;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.秽浊, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
