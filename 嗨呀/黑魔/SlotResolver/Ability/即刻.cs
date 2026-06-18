using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 即刻 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 100) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.即刻)) return (int)CheckResult.QT关闭;
        if (!SpellHelper.CanUseSpell(BLMHelper.即可咏唱)) return (int)CheckResult.冷却中;
        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;
        if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;
        if (!BLMHelper.冰状态 || BLMHelper.冰层数 >= 3) return (int)CheckResult.状态不符;
        if (GameHelper.RecentlyUsedSpell(BLMHelper.冰封, 2500)) return (int)CheckResult.最近已用;
        if (GameHelper.GetGCDCooldown() < 600) return (int)CheckResult.技能未就绪;
        return 0;
    }

    public void Build(Slot slot)
    {
        BLM_BattleData.Instance.下个gcd将瞬发 = true;
        slot.Add(new Spell { Id = BLMHelper.即可咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
