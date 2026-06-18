using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class 血乱三连 : ISlotResolver
{
    public int Check()
    {
        if (!DRKHelper.血乱激活) return (int)CheckResult.状态不符;

        if (GameHelper.GetCurrentLevel() >= 96)
        {
            var lastGcd = DRK_BattleData.Instance.前一gcd;
            if (lastGcd == DRKHelper.血乱裂)
                return (int)DRKHelper.血乱斩;
            if (lastGcd == DRKHelper.血乱斩)
                return (int)DRKHelper.血乱灭;
            return (int)DRKHelper.血乱裂;
        }

        return (int)DRKHelper.血溅;
    }

    public void Build(Slot slot)
    {
        uint id;

        if (GameHelper.GetCurrentLevel() >= 96)
        {
            var lastGcd = DRK_BattleData.Instance.前一gcd;
            if (lastGcd == DRKHelper.血乱裂)
                id = DRKHelper.血乱斩;
            else if (lastGcd == DRKHelper.血乱斩)
                id = DRKHelper.血乱灭;
            else
                id = DRKHelper.血乱裂;
        }
        else
        {
            id = QTHelper.IsEnabled(QTKey.AOE) && DRKHelper.群怪模式 ? DRKHelper.寂灭 : DRKHelper.血溅;
        }

        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
