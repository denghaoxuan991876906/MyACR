using 嗨呀.暗骑.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;
using HiAuRo.Helper;

namespace 嗨呀.暗骑.SlotResolver.GCD;

public class 基础连击 : ISlotResolver
{
    public int Check()
    {
        if (QTHelper.IsEnabled(QTKey.AOE) && DRKHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (DRKHelper.血乱激活) return (int)CheckResult.状态不符;

        var lastGcd = DRK_BattleData.Instance.前一gcd;

        if (lastGcd == 0 || lastGcd == DRKHelper.噬魂斩 || lastGcd is DRKHelper.释放 or DRKHelper.刚魂
            or DRKHelper.血乱裂 or DRKHelper.血乱斩 or DRKHelper.血乱灭)
            return (int)DRKHelper.重斩;

        if (lastGcd == DRKHelper.重斩)
            return (int)DRKHelper.吸收斩;

        if (lastGcd == DRKHelper.吸收斩)
            return (int)DRKHelper.噬魂斩;

        return (int)DRKHelper.重斩;
    }

    public void Build(Slot slot)
    {
        var bd = DRK_BattleData.Instance;
        var lastGcd = bd.前一gcd;

        uint id;
        if (lastGcd == DRKHelper.重斩)
            id = DRKHelper.吸收斩;
        else if (lastGcd == DRKHelper.吸收斩)
            id = DRKHelper.噬魂斩;
        else
            id = DRKHelper.重斩;

        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
