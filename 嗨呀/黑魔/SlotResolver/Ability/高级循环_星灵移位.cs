using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 高级循环_星灵移位 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 40) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.高级循环)) return (int)CheckResult.QT关闭;
        if (!SpellHelper.CanUseSpell(BLMHelper.星灵移位)) return (int)CheckResult.冷却中;
        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        var bd = BLM_BattleData.Instance;
        if (!bd.高级循环_冰澈读条完成) return (int)CheckResult.状态不符;
        if (bd.高级循环_读条冰澈Gcd != BLMHelper.冰澈) return (int)CheckResult.状态不符;
        if (bd.前一gcd != bd.高级循环_读条冰澈Gcd) return (int)CheckResult.状态不符;
        if (!BLMHelper.冰状态) return (int)CheckResult.状态不符;

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.星灵移位, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
