using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 星灵移位 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 40) return (int)CheckResult.等级不足;
        if (!SpellHelper.CanUseSpell(BLMHelper.星灵移位)) return (int)CheckResult.冷却中;
        if (GameHelper.GetGCDCooldown() < 400) return (int)CheckResult.技能未就绪;

        var bd = BLM_BattleData.Instance;

        if (BLMHelper.火状态)
        {
            if (!BLM_BattleData.在转冰整理区()) return (int)CheckResult.状态不符;
            var mp = Data.Me.Object?.CurrentMp ?? 0;
            if (mp >= 800) return (int)CheckResult.状态不符;
            if (BLMHelper.耀星层数 == 6 && GameHelper.GetCurrentLevel() == 100) return (int)CheckResult.状态不符;
            if (BLM_BattleData.应先用魔泉())
                return (int)CheckResult.状态不符;

            if (BLMHelper.可瞬发) return 0;
            if (GameHelper.GetCurrentLevel() < 100) return (int)CheckResult.状态不符;

            var 即刻下个Gcd内可用 = SpellHelper.CanUseSpell(BLMHelper.即刻咏唱)
                || SpellHelper.GetCooldownRemaining(BLMHelper.即刻咏唱) < GCDHelper.GetGCDDuration();
            var 三连可用 = QTHelper.IsEnabled(QTKey.三连) && SpellHelper.GetCharges(BLMHelper.三连咏唱) >= 1;
            if (!即刻下个Gcd内可用 && !三连可用)
                return (int)CheckResult.状态不符;
            return 0;
        }

        if (BLMHelper.冰状态)
        {
            if (!BLM_BattleData.可回火()) return (int)CheckResult.状态不符;
            return 0;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.星灵移位, TargetType = SpellTargetType.Self, Type = SpellType.Ability },
            waitServerAcq: true);
    }
}
