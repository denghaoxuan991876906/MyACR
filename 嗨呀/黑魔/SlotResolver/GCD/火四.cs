using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火四 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态 || BLMHelper.火层数 < 3) return (int)CheckResult.状态不符;

        if (Data.Me.Object?.CurrentMp < 1600) return (int)CheckResult.资源不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (BLMHelper.耀星层数 >= 6) return (int)CheckResult.状态不符;

        if (BLM_BattleData.Instance.火阶段已放耀星) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetCurrentLevel() >= 100 && !BLM_BattleData.Instance.能六火四 && BLMHelper.耀星层数 >= 3)
        {
            var fire4Cost = BLMHelper.冰针数 > 0 ? 800 : 1600;
            if (Data.Me.Object?.CurrentMp - fire4Cost < 800)
                return (int)CheckResult.资源不足;
        }

        return (int)BLMHelper.炽焰;
    }

    public void Build(Slot slot)
    {
        var spellId = BLMHelper.炽焰;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
