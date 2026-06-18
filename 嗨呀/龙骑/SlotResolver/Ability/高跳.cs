using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 高跳 : ISlotResolver
{
    public int Check()
    {
        var level = GameHelper.GetCurrentLevel();

        if (level < 30) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发)) return (int)CheckResult.QT关闭;

        if (!QTHelper.IsEnabled(BuiltinQt.Burst)) return (int)CheckResult.QT关闭;

        if (level >= 74)
        {
            if (CooldownHelper.GetCooldownRemaining(DRGHelper.高跳) > 0) return (int)CheckResult.冷却中;
        }
        else
        {
            if (CooldownHelper.GetCooldownRemaining(DRGHelper.跳跃) > 0) return (int)CheckResult.冷却中;
        }

        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        var level = GameHelper.GetCurrentLevel();
        var id = level >= 74 ? DRGHelper.高跳 : DRGHelper.跳跃;

        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
