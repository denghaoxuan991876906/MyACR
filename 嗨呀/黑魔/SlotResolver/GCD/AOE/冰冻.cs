using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD.AOE;

public class 冰冻 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 12) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        var level = GameHelper.GetCurrentLevel();
        var iceId = level >= 94 ? BLMHelper.高冰冻 : BLMHelper.冰冻;

        if (BLMHelper.火状态 && Data.Me.Object?.CurrentMp < 800)
            return (int)iceId;

        if (BLMHelper.冰状态 && BLMHelper.冰层数 < 3)
            return (int)iceId;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态)
            return (int)iceId;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        var level = GameHelper.GetCurrentLevel();
        var id = level >= 94 ? BLMHelper.高冰冻 : BLMHelper.冰冻;
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
