using System.Numerics;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 闪雷弹 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 15) return (int)CheckResult.等级不足;

        if (Data.Target.Current == null) return (int)CheckResult.目标无效;

        var pos = Data.Me.Object?.Position;
        var targetPos = Data.Target.Current?.Position;
        if (pos != null && targetPos != null && Vector3.Distance(pos.Value, targetPos.Value) <= 5)
            return (int)CheckResult.状态不符;

        return (int)GNBHelper.闪雷弹;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = GNBHelper.闪雷弹, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
