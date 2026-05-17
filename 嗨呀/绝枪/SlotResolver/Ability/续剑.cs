using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.Ability;

public class 续剑 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 70) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.续剑)) return (int)CheckResult.QT关闭;

        if (!GNBHelper.续剑激活) return (int)CheckResult.状态不符;

        var bd = 绝枪_BattleData.Instance;
        if (bd.AfterSpell.Count > 0 && bd.AfterSpell[^1] == GNBHelper.撕喉)
            return (int)CheckResult.最近已用;

        if (HelperRuntime.GetGCDCooldown() > 600) return (int)CheckResult.冷却中;

        return 1;
    }

    public void Build(Slot slot)
    {
        uint spellId;
        if (HelperRuntime.HasStatus(1842))
            spellId = GNBHelper.撕喉;
        else if (HelperRuntime.HasStatus(1843))
            spellId = GNBHelper.裂膛;
        else if (HelperRuntime.HasStatus(1844))
            spellId = GNBHelper.穿目;
        else if (HelperRuntime.HasStatus(3839))
            spellId = GNBHelper.命运之印;
        else if (HelperRuntime.HasStatus(2686))
            spellId = GNBHelper.超高速;
        else
            return;

        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.Ability });
    }
}
