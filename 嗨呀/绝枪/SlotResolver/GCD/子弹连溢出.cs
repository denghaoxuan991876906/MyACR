using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 子弹连溢出 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.子弹连)) return (int)CheckResult.QT关闭;

        if (!GNBHelper.Has无情) return (int)CheckResult.状态不符;

        var bd = 绝枪_BattleData.Instance;
        if (bd.子弹连步骤 != 0) return (int)CheckResult.特殊循环中;

        if (!GNBHelper.HasCartridge) return (int)CheckResult.资源不足;

        if (GameHelper.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;

        return (int)GNBHelper.烈牙;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.烈牙, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
