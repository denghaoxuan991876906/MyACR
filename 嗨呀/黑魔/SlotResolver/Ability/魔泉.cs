using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 魔泉 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 58) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.墨泉)) return (int)CheckResult.QT关闭;
        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (!SpellHelper.CanUseSpell(BLMHelper.魔泉)) return (int)CheckResult.冷却中;
        if (mp > 800) return (int)CheckResult.状态不符;
        if (BLMHelper.耀星层数 == 6 && GameHelper.GetCurrentLevel() == 100) return (int)CheckResult.状态不符;
        if (GameHelper.GetGCDCooldown() < 500) return (int)CheckResult.技能未就绪;



        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.魔泉, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
