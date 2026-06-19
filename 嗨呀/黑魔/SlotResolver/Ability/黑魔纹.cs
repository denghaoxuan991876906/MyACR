using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 黑魔纹 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 52) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.黑魔纹)) return (int)CheckResult.QT关闭;
        if (GameHelper.RecentlyUsedSpell(BLMHelper.黑魔纹, 2000)) return (int)CheckResult.最近已用;
        if (GameHelper.GetGCDCooldown() < 500) return (int)CheckResult.技能未就绪;
        if (BLMHelper.Has魔纹存在) return (int)CheckResult.状态不符;
        if (!SpellHelper.CanUseSpell(BLMHelper.黑魔纹)) return (int)CheckResult.冷却中;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.黑魔纹, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}


