using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 秽浊 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 70) return (int)CheckResult.等级不足;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (BLMHelper.通晓数 <= 0) return (int)CheckResult.资源不足;

        var level = GameHelper.GetCurrentLevel();
        if (level >= 98)
        {
            if (BLMHelper.通晓数 >= 3) return (int)BLMHelper.秽浊;
        }
        else
        {
            if (BLMHelper.通晓数 >= 2) return (int)BLMHelper.秽浊;
        }

        return (int)CheckResult.资源不足;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.秽浊, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
