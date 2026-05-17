using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD.AOE;

public class 火二 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 44) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (Data.Me.Object?.CurrentMp < 800) return (int)CheckResult.资源不足;

        var level = HelperRuntime.GetCurrentLevel();
        return level >= 94 ? (int)BLMHelper.高烈炎 : (int)BLMHelper.烈炎;
    }

    public void Build(Slot slot)
    {
        var level = HelperRuntime.GetCurrentLevel();
        var id = level >= 94 ? BLMHelper.高烈炎 : BLMHelper.烈炎;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
