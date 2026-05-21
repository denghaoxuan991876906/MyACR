using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 悖论_收尾 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 90) return (int)CheckResult.等级不足;

        if (!BLMHelper.火状态 || BLMHelper.火层数 < 3) return (int)CheckResult.状态不符;

        if (!BLMHelper.悖论指示) return (int)CheckResult.资源不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (QTHelper.IsEnabled(QTKey.减少火悖论)) return (int)CheckResult.QT关闭;

        if (BLMHelper.Has火苗) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (Data.Me.Object?.CurrentMp < 2400) return (int)CheckResult.资源不足;

        var bd = BLM_BattleData.Instance;

        if (BLMHelper.Has三连 && BLMHelper.耀星层数 == 6) return 1;

        if (bd.火阶段已放耀星) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.悖论, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
