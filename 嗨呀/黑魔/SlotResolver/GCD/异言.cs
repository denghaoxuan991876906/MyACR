using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 异言 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 80) return (int)CheckResult.等级不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (BLMHelper.通晓数 <= 0) return (int)CheckResult.资源不足;

        var level = HelperRuntime.GetCurrentLevel();
        if (level >= 98)
        {
            if (BLMHelper.通晓数 >= 3) return (int)BLMHelper.异言;
            if (BLMHelper.通晓数 >= 2 && CooldownHelper.GetCooldownRemaining(BLMHelper.详述) < 10000)
                return (int)CheckResult.状态不符;
        }
        else
        {
            if (BLMHelper.通晓数 >= 2) return (int)BLMHelper.异言;
        }

        return (int)CheckResult.资源不足;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.异言, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
