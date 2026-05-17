using System.Numerics;
using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.GCD;

public class 贯穿尖 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 15) return (int)CheckResult.等级不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && DRGHelper.群怪模式) return (int)CheckResult.群怪模式;

        if (CooldownHelper.GetCooldownRemaining(DRGHelper.贯穿尖) > 0) return (int)CheckResult.冷却中;

        var target = Data.Target.Current;
        if (target == null) return (int)CheckResult.目标无效;

        var me = Data.Me.Object;
        if (me == null) return (int)CheckResult.目标无效;

        var targetObj = target as IGameObject;
        var meObj = me as IGameObject;
        if (targetObj == null || meObj == null) return (int)CheckResult.目标无效;

        var distance = Vector3.Distance(meObj.Position, targetObj.Position);
        if (distance < 8) return (int)CheckResult.状态不符;

        if (distance > 20) return (int)CheckResult.状态不符;

        return (int)DRGHelper.贯穿尖;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = DRGHelper.贯穿尖, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
