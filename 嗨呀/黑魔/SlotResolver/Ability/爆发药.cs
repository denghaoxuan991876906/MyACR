using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 爆发药 : ISlotResolver
{
    public int Check()
    {
        if (!QTHelper.IsEnabled("爆发药")) return (int)CheckResult.QT关闭;

        if (!ItemHelper.CheckCurrJobPotion()) return (int)CheckResult.资源不足;

        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (!BLMHelper.可瞬发) return (int)CheckResult.状态不符;

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(Spell.CreatePotion());
    }
}
