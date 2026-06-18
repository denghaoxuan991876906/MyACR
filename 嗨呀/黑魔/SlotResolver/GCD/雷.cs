using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 雷 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 45) return (int)CheckResult.等级不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (!QTHelper.IsEnabled(QTKey.Dot)) return (int)CheckResult.QT关闭;

        if (QTHelper.IsEnabled(QTKey.TTK)) return (int)CheckResult.特殊循环中;

        if (!BLMHelper.补dot()) return (int)CheckResult.状态不符;

        if (!BLMHelper.Has雷云) return (int)CheckResult.资源不足;

        var level = GameHelper.GetCurrentLevel();
        uint skillId;
        if (level >= 92)
            skillId = BLMHelper.高闪雷;
        else if (level >= 45)
            skillId = BLMHelper.暴雷;
        else
            skillId = BLMHelper.闪雷;

        return (int)skillId;
    }

    public void Build(Slot slot)
    {
        var level = GameHelper.GetCurrentLevel();
        uint skillId;
        if (level >= 92)
            skillId = BLMHelper.高闪雷;
        else if (level >= 45)
            skillId = BLMHelper.暴雷;
        else
            skillId = BLMHelper.闪雷;

        slot.Add(new Spell { Id = skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
