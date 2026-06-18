using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class AOE连击 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 40) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE) || !DRKHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (DRKHelper.血乱激活) return (int)CheckResult.状态不符;

        var lastGcd = DRK_BattleData.Instance.前一gcd;

        if (lastGcd == DRKHelper.释放)
            return (int)DRKHelper.刚魂;

        return (int)DRKHelper.释放;
    }

    public void Build(Slot slot)
    {
        var lastGcd = DRK_BattleData.Instance.前一gcd;
        var id = lastGcd == DRKHelper.释放 ? DRKHelper.刚魂 : DRKHelper.释放;

        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
