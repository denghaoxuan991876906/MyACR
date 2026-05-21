using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 悖论_冰 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 90) return (int)CheckResult.等级不足;

        if (!BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (!BLMHelper.悖论指示) return (int)CheckResult.资源不足;

        if (BLMHelper.冰层数 < 3) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.高级循环))
            return 1;

        if (BLMHelper.冰针数 < 3) return (int)CheckResult.资源不足;

        if (BLM_BattleData.Instance.已回复蓝量 < 10000) return (int)CheckResult.资源不足;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.悖论, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
