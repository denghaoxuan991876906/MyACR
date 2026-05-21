using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 三连咏唱 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 66) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled("三连")) return (int)CheckResult.QT关闭;

        if (CooldownHelper.GetCharges(BLMHelper.三连咏唱) < 1) return (int)CheckResult.冷却中;

        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled("TTK")) return 999;

        if (BLMHelper.火状态 && BLMHelper.火层数 >= 3 && BLMHelper.耀星层数 >= 5 && !BLMHelper.群怪模式)
            return 1;

        if (BLMHelper.火状态 && BLMHelper.群怪模式 && Data.Me.Object?.CurrentMp < 800 && BLMHelper.耀星层数 == 6)
            return 800;

        if (BLMHelper.冰状态 && BLMHelper.冰层数 < 3) return 1;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.三连咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
