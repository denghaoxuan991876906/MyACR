using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 冰澈 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 58) return (int)CheckResult.等级不足;

        if (!BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (BLMHelper.冰层数 < 3) return (int)CheckResult.状态不符;

        if (BLMHelper.冰针数 >= 3 && BLM_BattleData.Instance.已回复蓝量 >= 10000)
            return (int)CheckResult.资源不足;

        return (int)BLMHelper.冰澈;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.冰澈, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
